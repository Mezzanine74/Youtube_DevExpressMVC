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
    public class Employee : IEntity
    {
        public int Id { get; set; } // Id (Primary key)
        public string LastName { get; set; } // LastName (length: 20)
        public string FirstName { get; set; } // FirstName (length: 10)
        public string Title { get; set; } // Title (length: 30)
        public string TitleOfCourtesy { get; set; } // TitleOfCourtesy (length: 25)
        public System.DateTime? BirthDate { get; set; } // BirthDate
        public System.DateTime? HireDate { get; set; } // HireDate
        public string Address { get; set; } // Address (length: 60)
        public string City { get; set; } // City (length: 15)
        public string Region { get; set; } // Region (length: 15)
        public string PostalCode { get; set; } // PostalCode (length: 10)
        public string Country { get; set; } // Country (length: 15)
        public string HomePhone { get; set; } // HomePhone (length: 24)
        public string Extension { get; set; } // Extension (length: 4)
        public byte[] Photo { get; set; } // Photo (length: 2147483647)
        public string Notes { get; set; } // Notes (length: 1073741823)
        public int? ReportsTo { get; set; } // ReportsTo
        public string PhotoPath { get; set; } // PhotoPath (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Orders where [Order].[EmployeeId] point to this entity (FK_Orders_Employees)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Order> Orders { get; set; } // Order.FK_Orders_Employees
        /// <summary>
        /// Child Territories (Many-to-Many) mapped by table [EmployeeTerritory]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Territory> Territories { get; set; } // Many to many mapping

        public Employee()
        {
            Orders = new System.Collections.Generic.List<Order>();
            Territories = new System.Collections.Generic.List<Territory>();
        }
    }

}
// </auto-generated>
