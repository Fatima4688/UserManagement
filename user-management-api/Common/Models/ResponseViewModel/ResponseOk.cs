namespace Common.Models.ResponseViewModel
{
    public class ResponseOk : Response
    {
        public dynamic? Data { get; set; }

        public ResponseOk(dynamic? data = null, string message = "") : base(message)
        {
            Success = true;
            Data = data;
        }
    }
}