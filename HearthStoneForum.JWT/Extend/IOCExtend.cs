using HearthStoneForum.Service;
using HearthStoneForum.Repository;
using HearthStoneForum.IRepository;
using HearthStoneForum.IService;

namespace HearthStoneForum.JWT.Extend
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            return services;
        }
    }
}
