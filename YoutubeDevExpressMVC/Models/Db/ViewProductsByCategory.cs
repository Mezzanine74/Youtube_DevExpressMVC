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

    // ViewProductsByCategory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class ViewProductsByCategory
    {
        public string CategoryName { get; set; } // CategoryName (Primary key) (length: 15)
        public string ProductName { get; set; } // ProductName (Primary key) (length: 40)
        public string QuantityPerUnit { get; set; } // QuantityPerUnit (length: 20)
        public short? UnitsInStock { get; set; } // UnitsInStock
        public bool Discontinued { get; set; } // Discontinued (Primary key)
    }

}
// </auto-generated>