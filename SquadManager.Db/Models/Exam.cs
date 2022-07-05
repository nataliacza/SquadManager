using SquadManager.Db.Enums;

namespace SquadManager.Db.Models;

public class Exam
{
    public Guid Id { get; set; }
    public ExamType ExamType { get; set; }
    public DateTime ExamDate { get; set; }
    public DateTime ExamExpiration { get; set; }

    public Dog DogId { get; set; } = null!;
    public virtual Dog Dog { get; set; } = null!;

    public Member MemberId { get; set; } = null!;
    public virtual Member Member { get; set; } = null!;
}
