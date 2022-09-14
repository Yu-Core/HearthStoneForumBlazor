using AutoMapper;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTOView;
using HearthStoneForum.WebApi.Utility._MD5;

namespace HearthStoneForum.WebApi.Utility.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserInfo, UserInfoDTOView>();
            CreateMap<AreaDTOAdd, Area>().ForMember(des => des.CreatedTime, source => source.MapFrom(src => DateTime.Now))
                .ForMember(des => des.Sort, source => source.MapFrom(src => DateTimeUtil.DateTimeToLongTimeStamp(DateTime.Now)));
            CreateMap<UserInfoDTOAdd, UserInfo>().ForMember(des=>des.Password,source=>source.Ignore())
                .ConstructUsing(dto => new UserInfo
                {
                    Password = MD5Helper.MD5Encrytp32(dto.Password ?? "PassWord"),
                    Email = dto.Email,
                    Sex = Sex.未知,
                    CreatedTime = DateTime.Now,
                    LastLogin = DateTime.Now,
                    Name = "用户" + dto.UserName,
                    HeadId = 0,
                    Phone = String.Empty
                });

            //CreateMap<PreachDTOCreate, Preach>().ConstructUsing(dto => new Preach
            //{
            //    IsCancel = false,
            //    IsHeld = false
            //});
            //CreateMap<PreachDTOEdit, Preach>();
            //CreateMap<UserInfoDTOCreate, UserInfo>().ForMember(des => des.UserPwd, source => source.Ignore())
            //    .ConstructUsing(dto => new UserInfo
            //    {
            //        UserName = dto.UserName,
            //        UserPwd = MD5Helper.MD5Encrytp32(dto.UserPwd ?? "PassWord"),
            //        Name = "无名小鬼",
            //        Email = string.Empty,
            //        Brithday = new DateTime(),
            //        HeadImageUrl = string.Empty,
            //        Sex = string.Empty,
            //        LastLogin = DateTime.Now
            //    });
            //CreateMap<UserInfoDTOEdit, UserInfo>().ForMember(des => des.UserPwd, source => source.MapFrom(src => MD5Helper.MD5Encrytp32(src.UserPwd ?? "PassWord")));
            //CreateMap<TicketDTOCreate, Ticket>();
        }
    }
}
