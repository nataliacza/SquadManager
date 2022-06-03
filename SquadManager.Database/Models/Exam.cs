using SquadManager.Database.Enums;

namespace SquadManager.Database.Models;

public class Exam
{
    public Guid Id { get; set; }
    public ExamType ExamType { get; set; }
    public DateTime ExamDate { get; set; }
    public DateTime ExamExpiration { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member Member { get; set; } = null!;

    public Guid DogId { get; set; }
    public virtual Dog Dog { get; set; } = null!;
}
