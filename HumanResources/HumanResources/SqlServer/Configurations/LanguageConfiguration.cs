using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(language => language.Id);
            builder.Property(language => language.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasIndex(language => new { language.Name, language.Status }).IsUnique();
            builder.Property(language => language.Name).IsRequired();
        }
    }
}
