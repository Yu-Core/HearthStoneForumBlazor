namespace HearthStoneForum.Client.Utility
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public string? Msg { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }

    }
}
