using AutoMapper;
using FluentValidation.Results;
using Placely.Application.Common.Models;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class ValidationFailureMapperProfile : Profile
{
    public ValidationFailureMapperProfile()
    {
        CreateMap<ValidationFailure, ValidationErrorModel>();
    }
}