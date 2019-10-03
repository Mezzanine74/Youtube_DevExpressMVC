// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace YoutubeDevExpressMVC.Web.Models.Db
{

    // Employee
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class EmployeeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
            : this("dbo")
        {
        }

        public EmployeeConfiguration(string schema)
        {
            ToTable("Employee", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.TitleOfCourtesy).HasColumnName(@"TitleOfCourtesy").HasColumnType("nvarchar").IsOptional().HasMaxLength(25);
            Property(x => x.BirthDate).HasColumnName(@"BirthDate").HasColumnType("datetime").IsOptional();
            Property(x => x.HireDate).HasColumnName(@"HireDate").HasColumnType("datetime").IsOptional();
            Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.HomePhone).HasColumnName(@"HomePhone").HasColumnType("nvarchar").IsOptional().HasMaxLength(24);
            Property(x => x.Extension).HasColumnName(@"Extension").HasColumnType("nvarchar").IsOptional().HasMaxLength(4);
            Property(x => x.Photo).HasColumnName(@"Photo").HasColumnType("image").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("ntext").IsOptional().IsMaxLength();
            Property(x => x.ReportsTo).HasColumnName(@"ReportsTo").HasColumnType("int").IsOptional();
            Property(x => x.PhotoPath).HasColumnName(@"PhotoPath").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            HasMany(t => t.Territories).WithMany(t => t.Employees).Map(m =>
            {
                m.ToTable("EmployeeTerritory", "dbo");
                m.MapLeftKey("EmployeeId");
                m.MapRightKey("TerritoryId");
            });
        }
    }

}
// </auto-generated>
