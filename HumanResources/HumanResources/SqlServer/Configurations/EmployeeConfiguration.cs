using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.Property(employee => employee.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(employee => employee.AdmissionDate).HasDefaultValueSql("GetDate()");
            builder.Property(employee => employee.Department).IsRequired();
            builder.Property(employee => employee.PositionId).IsRequired();
            builder.Property(employee => employee.PositionId).IsRequired();
            builder.Property(employee => employee.UserId).IsRequired();
        }
    }
}
