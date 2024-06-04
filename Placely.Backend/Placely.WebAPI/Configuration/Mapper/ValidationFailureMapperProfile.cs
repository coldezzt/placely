using AutoMapper;
using FluentValidation.Results;
using Placely.WebAPI.Models;

namespace Placely.WebAPI.Configuration.Mapper;

public class ValidationFailureMapperProfile : Profile
{
    public ValidationFailureMapperProfile()
    {
        CreateMap<ValidationFailure, ValidationError>();
    }
}