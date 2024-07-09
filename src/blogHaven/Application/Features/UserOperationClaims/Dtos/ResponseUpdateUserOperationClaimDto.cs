namespace Application.Features.UserOperationClaims.Dtos
{
    public class ResponseUpdateUserOperationClaimDto : IDto
    {
        public int Id { get; set; }

        public int OperationClaimId { get; set; }

        public int UserId { get; set; }
    }
}
