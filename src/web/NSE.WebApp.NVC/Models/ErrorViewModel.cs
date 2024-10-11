namespace NSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMenssages Errors { get; set; }
    }

    public class ResponseErrorMenssages
    {
        public List<string> Mensagens { get; set; }
    }
}
