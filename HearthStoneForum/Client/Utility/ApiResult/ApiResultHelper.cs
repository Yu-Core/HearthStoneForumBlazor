namespace HearthStoneForum.Client.Utility
{
    public static class ApiResultHelper
    {
        //成功后返回数据
        public static ApiResult<T> Success<T>(T data)
        {
            return new ApiResult<T>
            {
                Successful = true,
                Msg = "操作成功",
                Data = data,
                Total = 0
            };
        }
        public static ApiResult<T> Error<T>(string msg)
        {
            return new ApiResult<T>
            {
                Successful = false,
                Msg = msg,
                Data = default(T),
                Total = 0
            };
        }
    }
}
