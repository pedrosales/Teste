using AutoMapper;
using Knewin.API.ViewModels.CidadeViewModel;
using Knewin.Domain.Entities;

namespace Knewin.API.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<Cidade, CidadeViewModel>();
        }
    }
}