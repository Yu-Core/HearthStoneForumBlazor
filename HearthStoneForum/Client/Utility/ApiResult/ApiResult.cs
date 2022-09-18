namespace HearthStoneForum.Client.Utility
{
    public class ApiResult<T>
    {
        public bool Successful { get; set; }
        public string? Msg { get; set; }
        public int Total { get; set; }
        public T? Data { get; set; }

    }
    public class ApiResult
    {
        public bool Successful { get; set; }
        public string? Msg { get; set; }
        public int Total { get; set; }
        public dynamic? Data { get; set; }

    }
}
