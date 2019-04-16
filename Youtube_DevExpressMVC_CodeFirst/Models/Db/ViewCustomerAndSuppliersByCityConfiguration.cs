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

    // ViewCustomerAndSuppliersByCity
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class ViewCustomerAndSuppliersByCityConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ViewCustomerAndSuppliersByCity>
    {
        public ViewCustomerAndSuppliersByCityConfiguration()
            : this("dbo")
        {
        }

        public ViewCustomerAndSuppliersByCityConfiguration(string schema)
        {
            ToTable("ViewCustomerAndSuppliersByCity", schema);
            HasKey(x => new { x.CompanyName, x.Relationship });

            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ContactName).HasColumnName(@"ContactName").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.Relationship).HasColumnName(@"Relationship").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(9).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }

}
// </auto-generated>
