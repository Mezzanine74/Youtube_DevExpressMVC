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

    // Shipper
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class ShipperConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
            : this("dbo")
        {
        }

        public ShipperConfiguration(string schema)
        {
            ToTable("Shipper", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar").IsOptional().HasMaxLength(24);
        }
    }

}
// </auto-generated>