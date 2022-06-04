namespace SquadManager.Database.Models;
public class MemberExam
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member Member { get; set; } = null!;

    public Guid ExamId { get; set; }
    public virtual Exam Exam { get; set; } = null!;
}
