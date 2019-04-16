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

    // Territory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class Territory : IEntity
    {
        public int Id { get; set; } // Id (Primary key)
        public string TerritoryCode { get; set; } // TerritoryCode (length: 20)
        public string TerritoryDescription { get; set; } // TerritoryDescription (length: 50)
        public int RegionId { get; set; } // RegionId

        // Reverse navigation

        /// <summary>
        /// Child Employees (Many-to-Many) mapped by table [EmployeeTerritory]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Employee> Employees { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Region pointed by [Territory].([RegionId]) (FK_Territories_Region)
        /// </summary>
        public virtual Region Region { get; set; } // FK_Territories_Region

        public Territory()
        {
            Employees = new System.Collections.Generic.List<Employee>();
        }
    }

}
// </auto-generated>
