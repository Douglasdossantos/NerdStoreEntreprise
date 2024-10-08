﻿using NSE.Identidade.API.Models;
using System.Text;
using System.Text.Json;

namespace NSE.Identidade.API.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(usuarioLogin),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44338/api/identidade/autenticar", loginContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44338/api/identidade/nova-conta", registroContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
