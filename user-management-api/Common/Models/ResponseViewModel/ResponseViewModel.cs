namespace Common.ViewModels
{
    public class ResponseViewModel
    {
        public int Status { get; set; }
        public dynamic Response { get; set; }

        public ResponseViewModel() { }
        public ResponseViewModel(int statusCode, dynamic response)
        {
            Status = statusCode;
            Response = response;
        }
    }
}
