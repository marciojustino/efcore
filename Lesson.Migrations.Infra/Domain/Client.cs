namespace Lesson.Migrations.Infra.Domain
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public long Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<AccountClient> Accounts { get; set; }
    }
}
