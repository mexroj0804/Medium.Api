namespace Medium.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Bio {  get; set; }
    public string? PhotoPath { get; set; }
    public int FollowersCount { get; set; }

    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public DateTimeOffset JoinDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset ModifiedDate { get; set; }
    public DateTimeOffset DeletedDate { get; set; }

    public bool IsDeleted { get; set; } = false;
}