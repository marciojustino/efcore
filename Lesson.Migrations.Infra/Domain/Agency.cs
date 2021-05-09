namespace Lesson.Migrations.Infra.Domain
{
    using System.Collections.Generic;

    public class Agency
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Bank Bank { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public long BankId { get; set; }
    }
}
