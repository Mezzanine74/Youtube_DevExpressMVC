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

    // ViewOrdersQry
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class ViewOrdersQryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ViewOrdersQry>
    {
        public ViewOrdersQryConfiguration()
            : this("dbo")
        {
        }

        public ViewOrdersQryConfiguration(string schema)
        {
            ToTable("ViewOrdersQry", schema);
            HasKey(x => new { x.Id, x.CustomerId, x.CompanyName });

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CustomerId).HasColumnName(@"CustomerID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.EmployeeId).HasColumnName(@"EmployeeID").HasColumnType("int").IsOptional();
            Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsOptional();
            Property(x => x.RequiredDate).HasColumnName(@"RequiredDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShippedDate).HasColumnName(@"ShippedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShipperId).HasColumnName(@"ShipperId").HasColumnType("int").IsOptional();
            Property(x => x.Freight).HasColumnName(@"Freight").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ShipName).HasColumnName(@"ShipName").HasColumnType("nvarchar").IsOptional().HasMaxLength(40);
            Property(x => x.ShipAddress).HasColumnName(@"ShipAddress").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.ShipCity).HasColumnName(@"ShipCity").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipRegion).HasColumnName(@"ShipRegion").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipPostalCode).HasColumnName(@"ShipPostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.ShipCountry).HasColumnName(@"ShipCountry").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
        }
    }

}
// </auto-generated>