using System;
using AutoMapper;
using DomainModels = StudentAdminPortal.API.DomainModels;
using DataModels = StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<DataModels.Student, DomainModels.Student>()
				.ReverseMap();

			CreateMap<DataModels.Gender, DomainModels.Gender>()
				.ReverseMap();

			CreateMap<DataModels.Address, DomainModels.Address>()
				.ReverseMap();
		}
	}
}

