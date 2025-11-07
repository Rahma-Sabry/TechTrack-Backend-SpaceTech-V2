using TechTrack.Domain.DTOs.UserTechnologyReview;
using TechTrack.Domain.Models;
using TechTrack.DTOs;

namespace TechTrack.Infrastructure.Extensions
{
    public static class UserTechnologyReviewMappingExtensions
    {
        public static UserTechnologyReviewGetDto ToGetDto(this UserTechnologyReview review)
        {
            if (review == null) return null!;
            return new UserTechnologyReviewGetDto
            {
                ReviewId = review.ReviewId,
                UserId = review.UserId,
                TechnologyId = review.TechnologyId,
                Rating = review.Rating,
                ReviewText = review.ReviewText
            };
        }

        public static UserTechnologyReview ToModel(this UserTechnologyReviewCreateDto dto)
        {
            if (dto == null) return null!;
            return new UserTechnologyReview
            {
                UserId = dto.UserId,
                TechnologyId = dto.TechnologyId,
                Rating = dto.Rating,
                ReviewText = dto.ReviewText
            };
        }

        public static UserTechnologyReview ToModel(this UserTechnologyReviewUpdateDto dto, UserTechnologyReview existing)
        {
            if (dto == null || existing == null) return existing;

            existing.UserId = dto.UserId;
            existing.TechnologyId = dto.TechnologyId;
            existing.Rating = dto.Rating;
            existing.ReviewText = dto.ReviewText;

            return existing;
        }
    }
}
