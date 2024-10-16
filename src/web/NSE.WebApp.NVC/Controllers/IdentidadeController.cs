﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Controllers;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.WebApp.NVC.Controllers
{
    public class IdentidadeController : MainController
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro) 
        {
            if (!ModelState.IsValid) return View(usuarioRegistro); 
            
            var resposta =await _autenticacaoService.Registro(usuarioRegistro);

            if (ResponsePossuiErros(resposta.ResponseResult))
            {
                return View(usuarioRegistro);
            }

            await Realizarlogin(resposta);

            //if (false) return View(usuarioRegistro);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult login(string returnurl = null) 
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin, string returnUrl = null) 
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(usuarioLogin);

            var resposta = await _autenticacaoService.Login(usuarioLogin);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLogin);

            await Realizarlogin(resposta);
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            return LocalRedirect(returnUrl);    

        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        private async Task Realizarlogin(UsuarioRespostaLogin resposta)
        {
            var token = ObterTokenFomatado(resposta.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT",resposta.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken ObterTokenFomatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(jwtToken) as JwtSecurityToken;
        }

    }
}
