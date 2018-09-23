using System;
using HumanResources.Enums;

namespace HumanResources.SqlServer.Models
{
    public sealed class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LanguageStatus Status { get; set; }
    }
}
