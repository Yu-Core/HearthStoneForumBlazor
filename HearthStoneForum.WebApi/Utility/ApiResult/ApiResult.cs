namespace HearthStoneForum.WebApi.Utility.ApiResult
{
    public class ApiResult
    {
        public bool Successful { get; set; }
        public string? Msg { get; set; }
        public int Total { get; set; }
        public dynamic? Data { get; set; }

    }
}
