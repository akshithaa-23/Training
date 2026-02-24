namespace Application.DTOs
{
    public record UserListDto(
        int Id,
        string FullName,
        string Email,
        string Role,
        bool IsActive
    );

    public record AddUserDto(
        string FullName,
        string Email,
        string Password,
        string Role
    );

    public record EditUserDto(
        string FullName,
        string Email,
        string Role
    );

    public record StatsDto(
        int TotalStudents,
        int TotalTrainers,
        int TotalAdmins,
        int ActiveUsers
    );
}