namespace HearthStoneForum.JWT.Utility.ApiResult
{
    public static class ApiResultHelper
    {
        //成功后返回数据
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Code = 200,
                Msg = "操作成功",
                Data = data,
                Total = 0
            };
        }
        public static ApiResult Success(dynamic data,int total)
        {
            return new ApiResult
            {
                Code = 200,
                Msg = "操作成功",
                Data = data,
                Total = total
            };
        }
        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Code = 500,
                Msg = msg,
                Data = null,
                Total = 0
            };
        }
    }
}
