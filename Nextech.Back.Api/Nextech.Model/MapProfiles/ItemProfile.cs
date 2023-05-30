using AutoMapper;
using Nextech.Core.DTO;
using Nextech.Core.DTO.Enums;
using Nextech.Core.Model;

namespace Nextech.Core.MapProfiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDTO>()
            .ForMember(des => des.ID, src => src.MapFrom(src => src.id))
            .ForMember(des => des.Title, src => src.MapFrom(src => src.title))
            .ForMember(des => des.Type, src => src.MapFrom(src => MapType(src.type)))
            .ForMember(des => des.Date, src => src.MapFrom(s => MapDate(s.time)))
            .ForMember(des => des.Text, src => src.MapFrom(src => src.text))
            .ForMember(des => des.Url, src => src.MapFrom(src => src.url))
            .ForMember(des => des.By, src => src.MapFrom(src => src.by))
            .ForMember(des => des.IsDeleted, src => src.MapFrom(src => src.deleted))
            .ForMember(des => des.IsDead, src => src.MapFrom(src => src.dead))
            .ForMember(des => des.Parent, src => src.MapFrom(src => src.parent))
            .ForMember(des => des.Poll, src => src.MapFrom(src => src.poll))
            .ForMember(des => des.Kids, src => src.MapFrom(src => src.kids))
            .ForMember(des => des.Score, src => src.MapFrom(src => src.score))
            .ForMember(des => des.Parts, src => src.MapFrom(src => src.parts))
            .ForMember(des => des.Descendants, src => src.MapFrom(src => src.descendants));
    }
    private eItemType MapType(string type)
    {
        switch(type)
        {
            case "story": return eItemType.Story;
            case "comment": return eItemType.Comment;
            case "job": return eItemType.Job;
            case "poll": return eItemType.Poll;
            case "pollop": return eItemType.Pollopt;
            default: return eItemType.Other;
        }
    }
    private DateTime MapDate(int time)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(time).ToLocalTime();
    }
}
