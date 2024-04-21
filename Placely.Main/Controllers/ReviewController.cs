using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Main.Controllers;

// TODO: нужно ли разделить методы начинающиеся с Review и с Property?
[Route("api")]
public class ReviewController(
    IReviewService service,
    IMapper mapper,
    IValidator<ReviewDto> validator) : ControllerBase
{
    [HttpGet("[controller]/{reviewId:long}")]
    public async Task<IActionResult> GetById(long reviewId)
    {
        var result = await service.GetById(reviewId);
        var responseDto = mapper.Map<ReviewDto>(result);
        return Ok(responseDto);
    }

    [HttpGet("property/{propertyId:long}/reviews/{page:int}")]
    public async Task<IActionResult> GetListByPropertyId(long propertyId, int page)
    {
        var result = await service.GetListByPropertyIdAsync(propertyId, page);
        var responseDtoList = result.Select(mapper.Map<ReviewDto>);
        return Ok(responseDtoList);
    }
    
    [Authorize]
    [HttpPost("[controller]")]
    public async Task<IActionResult> Add([FromBody] ReviewDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        dto.AuthorId = long.Parse(GetClaim(CustomClaimTypes.UserId)!);
        var review = mapper.Map<Review>(dto);
        var result = await service.AddAsync(review);
        var responseDto = mapper.Map<ReviewDto>(result);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpDelete("[controller]/{reviewId:long}")]
    public async Task<IActionResult> Delete(long reviewId)
    {
        var id = long.Parse(GetClaim(CustomClaimTypes.UserId)!);
        var dbReview = await service.GetById(reviewId);
        if (dbReview.AuthorId != id)
            return Forbid();

        var result = await service.DeleteAsync(reviewId);
        var responseDto = mapper.Map<ReviewDto>(result);
        return Ok(responseDto);
    }
    
    private string? GetClaim(string type)
    {
        return User.Claims.FirstOrDefault(c => c.Type == type)?.Value;
    }
}