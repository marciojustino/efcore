namespace Lesson.Migrations.Infra.Domain
{
    using System;
    using System.Collections.Generic;
    using ValueObjects;

    public class Account
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Agency Agency { get; set; }
        public Bank Bank { get; set; }
        public StatusAccount Status { get; set; }
        public long BankId { get; set; }
        public long AgencyId { get; set; }
        public IList<AccountClient> Owners { get; set; }
    }
}