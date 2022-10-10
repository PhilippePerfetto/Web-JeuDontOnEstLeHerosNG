namespace JeuDontOnEstLeHeros.Core.BackOffice.Web.UI.Helpers;

using AutoMapper;
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Web.ViewModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ARequest, AModel>();
        CreateMap<AModel, ARequest>();
        /*
                // UpdateRequest -> User
                CreateMap<ARequest, Aventure>()
                    .ForAllMembers(x => x.Condition(
                        (src, dest, prop) =>
                        {
                            // ignore both null & empty string properties
                            if (prop == null) return false;
                            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                            // ignore null role
                            // if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                            return true;
                        }
                    ));
        */
    }

    public static IMapper GetInstance()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        return mapper;
    }
}
