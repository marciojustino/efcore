namespace Lesson.Migrations.Infra.Domain
{
    using System.Collections.Generic;

    public class Bank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<Account> Accounts { get; set; }
        public IList<Agency> Agencies { get; set; }
    }
}
