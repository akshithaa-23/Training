namespace Application.DTOs
{
    public record StudyMaterialDto(
        int Id,
        string Title,
        string? Description,
        string? FileUrl,
        DateTime UploadedAt,
        string UploadedByName
    );

    public record AddStudyMaterialDto(
        string Title,
        string? Description,
        string? FileUrl,
        int UploadedById
    );
}