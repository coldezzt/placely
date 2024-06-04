using AutoMapper;
using FluentValidation.Results;
using Placely.Data.Models;

namespace Placely.Data.Configurations.Mapper;

public class ValidationFailureMapperProfile : Profile
{
    public ValidationFailureMapperProfile()
    {
        CreateMap<ValidationFailure, ValidationError>();
    }
}