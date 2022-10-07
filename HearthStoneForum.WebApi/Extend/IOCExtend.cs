using HearthStoneForum.Service;
using HearthStoneForum.Repository;
using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;

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
            services.AddScoped<INoticeRepository, NoticeRepository>();
            services.AddScoped<INoticeService, NoticeService>();
            services.AddScoped<ISignRepository, SignRepository>();
            services.AddScoped<ISignService, SignService>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreaService,AreaService>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<IInvitationService, InvitationService>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<ILikesService, LikesService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<IRankService, RankService>();
            services.AddScoped<IDownloadRepository, DownloadRepository>();
            services.AddScoped<IDownloadService, DownloadService>();
            services.AddScoped<IRaceYearRepository, RaceYearRepository>();
            services.AddScoped<IRaceYearService, RaceYearService>();
            services.AddScoped<IExpansionRepository, ExpansionRepository>();
            services.AddScoped<IExpansionService, ExpansionService>();
            services.AddScoped<IPortraitRepository, PortraitRepository>();
            services.AddScoped<IPortraitService, PortraitService>();
            services.AddScoped<IViewRecordRepository, ViewRecordRepository>();
            services.AddScoped<IViewRecordService, ViewRecordService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            return services;
        }
    }
}
