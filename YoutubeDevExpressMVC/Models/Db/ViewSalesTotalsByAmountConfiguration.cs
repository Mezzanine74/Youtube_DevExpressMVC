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

    // ViewSalesTotalsByAmount
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class ViewSalesTotalsByAmountConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ViewSalesTotalsByAmount>
    {
        public ViewSalesTotalsByAmountConfiguration()
            : this("dbo")
        {
        }

        public ViewSalesTotalsByAmountConfiguration(string schema)
        {
            ToTable("ViewSalesTotalsByAmount", schema);
            HasKey(x => new { x.Id, x.CompanyName });

            Property(x => x.SaleAmount).HasColumnName(@"SaleAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ShippedDate).HasColumnName(@"ShippedDate").HasColumnType("datetime").IsOptional();
        }
    }

}
// </auto-generated>
