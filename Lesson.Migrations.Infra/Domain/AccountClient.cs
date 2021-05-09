namespace Lesson.Migrations.Infra.Domain
{
    public class AccountClient
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long ClientId { get; set; }
        public Account Account { get; set; }
        public Client Client { get; set; }
    }
}