namespace Lesson.Migrations.Infra.Domain
{
    using System;

    public class Contract
    {
        public long Id { get; set; }
        public Account Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SignedAt { get; set; }
        public long AccountId { get; set; }
    }
}