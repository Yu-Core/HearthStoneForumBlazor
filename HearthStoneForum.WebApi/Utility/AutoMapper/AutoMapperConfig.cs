﻿using AutoMapper;
using HearthStoneForum.Model;
using HearthStoneForum.Model.DTOAdd;
using HearthStoneForum.Model.DTOEdit;
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
                    Portrait = string.Empty,
                    Phone = String.Empty
                });
            CreateMap<UserInfoDTOEdit, UserInfo>();
            CreateMap<InvitationDTOAdd, Invitation>()
                .ConstructUsing(dto => new()
                {
                    Views = 0,
                    CreatedTime = DateTime.Now
                });
            CreateMap<CommentDTOAdd, Comment>()
                .ConstructUsing(dto => new()
                {
                    CreatedTime = DateTime.Now
                });
            CreateMap<ReportDTOAdd, Report>()
                .ConstructUsing(dto => new()
                {
                    CreatedTime = DateTime.Now
                });
        }
    }
}
