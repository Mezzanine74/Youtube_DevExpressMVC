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

using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace YoutubeDevExpressMVC.Web.Models.Db
{
    // Order
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class Order : IEntity
    {
        public int Id { get; set; } // Id (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public string CustomerCode { get; set; } // CustomerCode (length: 5)
        public int? EmployeeId { get; set; } // EmployeeId
        [DataType(DataType.DateTime)]
        public System.DateTime? OrderDate { get; set; } // OrderDate
        public System.DateTime? RequiredDate { get; set; } // RequiredDate
        public System.DateTime? ShippedDate { get; set; } // ShippedDate
        public int? ShipperId { get; set; } // ShipperId
        public decimal? Freight { get; set; } // Freight

        [DataType(DataType.MultilineText)]
        public string ShipName { get; set; } // ShipName (length: 40)
        public string ShipAddress { get; set; } // ShipAddress (length: 60)
        public string ShipCity { get; set; } // ShipCity (length: 15)
        public string ShipRegion { get; set; } // ShipRegion (length: 15)
        public string ShipPostalCode { get; set; } // ShipPostalCode (length: 10)
        public string ShipCountry { get; set; } // ShipCountry (length: 15)

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetail].[OrderId] point to this entity (FK_Order_Details_Orders)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.FK_Order_Details_Orders

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Order].([CustomerId]) (FK_Order_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Order_Customer

        /// <summary>
        /// Parent Employee pointed by [Order].([EmployeeId]) (FK_Orders_Employees)
        /// </summary>
        public virtual Employee Employee { get; set; } // FK_Orders_Employees

        /// <summary>
        /// Parent Shipper pointed by [Order].([ShipperId]) (FK_Orders_Shippers)
        /// </summary>
        public virtual Shipper Shipper { get; set; } // FK_Orders_Shippers

        public Order()
        {
            Freight = 0m;
            OrderDetails = new System.Collections.Generic.List<OrderDetail>();
        }
    }

}
// </auto-generated>
