using SqlSugar;

namespace HearthStoneForum.WebApi.Utility.ApiResult
{
    public static class ApiResultHelper
    {
        //成功后返回数据
        public static ApiResult Success(dynamic? data)
        {
            return new ApiResult
            {
                Successful = true,
                Msg = "操作成功",
                Data = data,
                Total = 0
            };
        }
        public static ApiResult Success(dynamic data,RefAsync<int> total)
        {
            return new ApiResult
            {
                Successful = true,
                Msg = "操作成功",
                Data = data,
                Total = total
            };
        }
        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Successful = false,
                Msg = msg,
                Data = null,
                Total = 0
            };
        }
    }
}
