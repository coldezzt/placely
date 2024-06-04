using AutoMapper;
using FluentValidation.Results;
using Placely.Application.Models;

namespace Placely.WebAPI.Configuration.Mapper;

public class ValidationFailureMapperProfile : Profile
{
    public ValidationFailureMapperProfile()
    {
        CreateMap<ValidationFailure, ValidationError>();
    }
}