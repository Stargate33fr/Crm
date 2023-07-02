using AutoMapper;
using Crm.Api.Infrastructure.Entities;
using Crm.Api.Queries.Recherche;
using Crm.Api.ViewModel.Contacts;
using Crm.Api.ViewModel.Habilitations;
using Crm.Api.ViewModels.Habilitations;
using IDSoft.TopInvestV6.Domain.ViewModels;

namespace IDSoft.CrmWelcome.Api.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapUtilisateur();
            MapContact();
            MapAdresse();
            MapVille();
            MapDepartement();
            MapRegion();
            MapPays();
            MapCivility();
            MapSearch();
        }

        private void MapSearch()
        {
            CreateMap<Crm.Api.Domain.Search.Pagination, Crm.Api.Queries.Recherche.Pagination>().ReverseMap();
            CreateMap<Crm.Api.Domain.Search.Tri, Tri>().ReverseMap();
        }

        private void MapContact()
        {
            CreateMap<ContactEntity, ContactViewModel>()
                 .ForMember(u => u.ConseillerId, _ => _.MapFrom(ug => ug.Conseiller.Id))
                 .ForMember(u => u.FirstNameConseiller, _ => _.MapFrom(ug => ug.Conseiller.FirstName))
                 .ForMember(u => u.LastNameConseiller, _ => _.MapFrom(ug => ug.Conseiller.LastName));
        }

        private void MapCivility()
        {
            CreateMap<CivilityEntity, CivilityViewModel>();
        }

        private void MapUtilisateur()
        {
            CreateMap<UserEntity, UserViewModel>()
                 .ForMember(u => u.CivilityId, _ => _.MapFrom(ug => ug.Civility.Id));

            CreateMap<UserEntity, UserSimplifieeViewModel>()
           .ForMember(u => u.Id, _ => _.MapFrom(ug => ug.Id))
            .ForMember(u => u.LastName, _ => _.MapFrom(ug => ug.LastName))
             .ForMember(u => u.FirstName, _ => _.MapFrom(ug => ug.FirstName));
        }

        private void MapAdresse()
        {
            CreateMap<AddressEntity, AddressViewModel>()
                .ForMember(u => u.StreetComplement, _ => _.MapFrom(ug => ug.ComplementStreet))
                 .ForMember(u => u.City, _ => _.MapFrom(ug => ug.City.Name))
                 .ForMember(u => u.Department, _ => _.MapFrom(ug => ug.City.Department.Name))
                 .ForMember(u => u.Country, _ => _.MapFrom(ug => ug.City.Department.Region.Country.Name))
                 .ForMember(u => u.PostalCode, _ => _.MapFrom(ug => ug.City.PostalCode))
                 .ForMember(u => u.Region, _ => _.MapFrom(ug => ug.City.Department.Region.Name))
                 .ForMember(u => u.CodeDepartement, _ => _.MapFrom(ug => ug.City.Department.Code))
                 .ForMember(u => u.DepartmentId, _ => _.MapFrom(ug => ug.City.Department.Id))
                 .ForMember(u => u.RegionId, _ => _.MapFrom(ug => ug.City.Department.RegionId))
                 .ForMember(u => u.CountryId, _ => _.MapFrom(ug => ug.City.Department.Region.CountryId));
        }

        private void MapVille()
        {
            CreateMap<CityEntity, CityViewModel>();
        }

        private void MapDepartement()
        {
            CreateMap<DepartmentEntity, DepartmentViewModel>();
        }

        private void MapRegion()
        {
            CreateMap<RegionEntity, RegionViewModel>();
        }

        private void MapPays()
        {
            CreateMap<CountryEntity, CountryViewModel>();
        }
    }
}
