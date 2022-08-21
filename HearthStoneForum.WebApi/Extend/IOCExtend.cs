using HearthStoneForum.Service;
using HearthStoneForum.Repository;
using HearthStoneForum.IRepository;
using HearthStoneForum.IService;

namespace HearthStoneForum.WebApi.Extend
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<ICarouselRepository, CarouselRepository>();
            services.AddScoped<ICarouselService, CarouselService>();
            return services;
        }
    }
}
