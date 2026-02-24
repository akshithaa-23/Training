namespace Application.DTOs
{
    public record FeedbackDto(
        int Id,
        string Message,
        DateTime SubmittedAt,
        string SubmittedByName,
        string SubmittedByRole
    );

    public record AddFeedbackDto(
        string Message
    );
}