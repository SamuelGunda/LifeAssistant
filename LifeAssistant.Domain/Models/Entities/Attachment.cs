namespace LifeAssistant.Domain.Models.Entities;

public sealed class Attachment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FileName { get; set; }
    public required string StorageUrl { get; set; }
    public DateTimeOffset UploadedAt { get; set; } = DateTimeOffset.UtcNow;
}
