namespace YoutubeDevExpressMVC.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Category",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        Description = c.String(storeType: "ntext"),
            //        Picture = c.Binary(),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Product",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        SupplierId = c.Int(),
            //        CategoryId = c.Int(),
            //        QuantityPerUnit = c.String(maxLength: 20),
            //        UnitPrice = c.Decimal(storeType: "money"),
            //        UnitsInStock = c.Short(),
            //        UnitsOnOrder = c.Short(),
            //        ReorderLevel = c.Short(),
            //        Discontinued = c.Boolean(nullable: false),
            //    })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Category", t => t.CategoryId)
            //    .ForeignKey("dbo.Supplier", t => t.SupplierId)
            //    .Index(t => t.SupplierId)
            //    .Index(t => t.CategoryId);

            //CreateTable(
            //    "dbo.OrderDetail",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        OrderId = c.Int(nullable: false),
            //        ProductID = c.Int(nullable: false),
            //        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
            //        Quantity = c.Short(nullable: false),
            //        Discount = c.Single(nullable: false),
            //    })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Order", t => t.OrderId)
            //    .ForeignKey("dbo.Product", t => t.ProductID)
            //    .Index(t => t.OrderId)
            //    .Index(t => t.ProductID);

            //CreateTable(
            //    "dbo.Order",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CustomerId = c.Int(nullable: false),
            //        CustomerCode = c.String(maxLength: 5, fixedLength: true),
            //        EmployeeId = c.Int(),
            //        OrderDate = c.DateTime(),
            //        RequiredDate = c.DateTime(),
            //        ShippedDate = c.DateTime(),
            //        ShipperId = c.Int(),
            //        Freight = c.Decimal(storeType: "money"),
            //        ShipName = c.String(maxLength: 40),
            //        ShipAddress = c.String(maxLength: 60),
            //        ShipCity = c.String(maxLength: 15),
            //        ShipRegion = c.String(maxLength: 15),
            //        ShipPostalCode = c.String(maxLength: 10),
            //        ShipCountry = c.String(maxLength: 15),
            //    })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Customer", t => t.CustomerId)
            //    .ForeignKey("dbo.Employee", t => t.EmployeeId)
            //    .ForeignKey("dbo.Shipper", t => t.ShipperId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.EmployeeId)
            //    .Index(t => t.ShipperId);

            //CreateTable(
            //    "dbo.Customer",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CustomerCode = c.String(maxLength: 5, fixedLength: true),
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        ContactName = c.String(maxLength: 30),
            //        ContactTitle = c.String(maxLength: 30),
            //        Address = c.String(maxLength: 60),
            //        City = c.String(maxLength: 15),
            //        Region = c.String(maxLength: 15),
            //        PostalCode = c.String(maxLength: 10),
            //        Country = c.String(maxLength: 15),
            //        Phone = c.String(maxLength: 24),
            //        Fax = c.String(maxLength: 24),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.CustomerCustomerDemo",
            //    c => new
            //    {
            //        CustomerId = c.Int(nullable: false, identity: true),
            //        CustomerDemographicId = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => new { t.CustomerId, t.CustomerDemographicId })
            //    .ForeignKey("dbo.Customer", t => t.CustomerId)
            //    .ForeignKey("dbo.CustomerDemographic", t => t.CustomerDemographicId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.CustomerDemographicId);

            //CreateTable(
            //    "dbo.CustomerDemographic",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CustomerDesc = c.String(storeType: "ntext"),
            //        Code = c.String(maxLength: 10, fixedLength: true),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Employee",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        LastName = c.String(nullable: false, maxLength: 20),
            //        FirstName = c.String(nullable: false, maxLength: 10),
            //        Title = c.String(maxLength: 30),
            //        TitleOfCourtesy = c.String(maxLength: 25),
            //        BirthDate = c.DateTime(),
            //        HireDate = c.DateTime(),
            //        Address = c.String(maxLength: 60),
            //        City = c.String(maxLength: 15),
            //        Region = c.String(maxLength: 15),
            //        PostalCode = c.String(maxLength: 10),
            //        Country = c.String(maxLength: 15),
            //        HomePhone = c.String(maxLength: 24),
            //        Extension = c.String(maxLength: 4),
            //        Photo = c.Binary(storeType: "image"),
            //        Notes = c.String(storeType: "ntext"),
            //        ReportsTo = c.Int(),
            //        PhotoPath = c.String(maxLength: 255),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Territory",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        TerritoryCode = c.String(nullable: false, maxLength: 20),
            //        TerritoryDescription = c.String(nullable: false, maxLength: 50, fixedLength: true),
            //        RegionId = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Region", t => t.RegionId)
            //    .Index(t => t.RegionId);

            //CreateTable(
            //    "dbo.Region",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        RegionDescription = c.String(nullable: false, maxLength: 50, fixedLength: true),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Shipper",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        Phone = c.String(maxLength: 24),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Supplier",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        ContactName = c.String(maxLength: 30),
            //        ContactTitle = c.String(maxLength: 30),
            //        Address = c.String(maxLength: 60),
            //        City = c.String(maxLength: 15),
            //        Region = c.String(maxLength: 15),
            //        PostalCode = c.String(maxLength: 10),
            //        Country = c.String(maxLength: 15),
            //        Phone = c.String(maxLength: 24),
            //        Fax = c.String(maxLength: 24),
            //        HomePage = c.String(storeType: "ntext"),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.ViewAlphabeticalListOfProducts",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        Discontinued = c.Boolean(nullable: false),
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        SupplierId = c.Int(),
            //        CategoryId = c.Int(),
            //        QuantityPerUnit = c.String(maxLength: 20),
            //        UnitPrice = c.Decimal(storeType: "money"),
            //        UnitsInStock = c.Short(),
            //        UnitsOnOrder = c.Short(),
            //        ReorderLevel = c.Short(),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.ProductName, t.Discontinued, t.CategoryName });

            //CreateTable(
            //    "dbo.ViewCategorySalesFor1997",
            //    c => new
            //    {
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        CategorySales = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => t.CategoryName);

            //CreateTable(
            //    "dbo.ViewCurrentProductList",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.ProductName });

            //CreateTable(
            //    "dbo.ViewCustomerAndSuppliersByCity",
            //    c => new
            //    {
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        Relationship = c.String(nullable: false, maxLength: 9, unicode: false),
            //        City = c.String(maxLength: 15),
            //        ContactName = c.String(maxLength: 30),
            //    })
            //    .PrimaryKey(t => new { t.CompanyName, t.Relationship });

            //CreateTable(
            //    "dbo.ViewInvoices",
            //    c => new
            //    {
            //        CustomerID = c.Int(nullable: false),
            //        CustomerName = c.String(nullable: false, maxLength: 40),
            //        Salesperson = c.String(nullable: false, maxLength: 31),
            //        Id = c.Int(nullable: false),
            //        ShipperName = c.String(nullable: false, maxLength: 40),
            //        ProductID = c.Int(nullable: false),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
            //        Quantity = c.Short(nullable: false),
            //        Discount = c.Single(nullable: false),
            //        ShipName = c.String(maxLength: 40),
            //        ShipAddress = c.String(maxLength: 60),
            //        ShipCity = c.String(maxLength: 15),
            //        ShipRegion = c.String(maxLength: 15),
            //        ShipPostalCode = c.String(maxLength: 10),
            //        ShipCountry = c.String(maxLength: 15),
            //        Address = c.String(maxLength: 60),
            //        City = c.String(maxLength: 15),
            //        Region = c.String(maxLength: 15),
            //        PostalCode = c.String(maxLength: 10),
            //        Country = c.String(maxLength: 15),
            //        OrderDate = c.DateTime(),
            //        RequiredDate = c.DateTime(),
            //        ShippedDate = c.DateTime(),
            //        ExtendedPrice = c.Decimal(storeType: "money"),
            //        Freight = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => new { t.CustomerID, t.CustomerName, t.Salesperson, t.Id, t.ShipperName, t.ProductID, t.ProductName, t.UnitPrice, t.Quantity, t.Discount });

            //CreateTable(
            //    "dbo.ViewOrderDetailsExtended",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        ProductID = c.Int(nullable: false),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
            //        Quantity = c.Short(nullable: false),
            //        Discount = c.Single(nullable: false),
            //        ExtendedPrice = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.ProductID, t.ProductName, t.UnitPrice, t.Quantity, t.Discount });

            //CreateTable(
            //    "dbo.ViewOrdersQry",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        CustomerID = c.Int(nullable: false),
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        EmployeeID = c.Int(),
            //        OrderDate = c.DateTime(),
            //        RequiredDate = c.DateTime(),
            //        ShippedDate = c.DateTime(),
            //        ShipperId = c.Int(),
            //        Freight = c.Decimal(storeType: "money"),
            //        ShipName = c.String(maxLength: 40),
            //        ShipAddress = c.String(maxLength: 60),
            //        ShipCity = c.String(maxLength: 15),
            //        ShipRegion = c.String(maxLength: 15),
            //        ShipPostalCode = c.String(maxLength: 10),
            //        ShipCountry = c.String(maxLength: 15),
            //        Address = c.String(maxLength: 60),
            //        City = c.String(maxLength: 15),
            //        Region = c.String(maxLength: 15),
            //        PostalCode = c.String(maxLength: 10),
            //        Country = c.String(maxLength: 15),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.CustomerID, t.CompanyName });

            //CreateTable(
            //    "dbo.ViewOrderSubtotals",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        Subtotal = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.ViewProductsAboveAveragePrice",
            //    c => new
            //    {
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        UnitPrice = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => t.ProductName);

            //CreateTable(
            //    "dbo.ViewProductSalesFfor1997",
            //    c => new
            //    {
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        ProductSales = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => new { t.CategoryName, t.ProductName });

            //CreateTable(
            //    "dbo.ViewProductsByCategory",
            //    c => new
            //    {
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        Discontinued = c.Boolean(nullable: false),
            //        QuantityPerUnit = c.String(maxLength: 20),
            //        UnitsInStock = c.Short(),
            //    })
            //    .PrimaryKey(t => new { t.CategoryName, t.ProductName, t.Discontinued });

            //CreateTable(
            //    "dbo.ViewSalesByCategory",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        CategoryName = c.String(nullable: false, maxLength: 15),
            //        ProductName = c.String(nullable: false, maxLength: 40),
            //        ProductSales = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.CategoryName, t.ProductName });

            //CreateTable(
            //    "dbo.ViewSalesTotalsByAmount",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        CompanyName = c.String(nullable: false, maxLength: 40),
            //        SaleAmount = c.Decimal(storeType: "money"),
            //        ShippedDate = c.DateTime(),
            //    })
            //    .PrimaryKey(t => new { t.Id, t.CompanyName });

            //CreateTable(
            //    "dbo.ViewSummaryOfSalesByQuarter",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        ShippedDate = c.DateTime(),
            //        Subtotal = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.ViewSummaryOfSalesByYear",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false),
            //        ShippedDate = c.DateTime(),
            //        Subtotal = c.Decimal(storeType: "money"),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.EmployeeTerritory",
            //    c => new
            //    {
            //        EmployeeId = c.Int(nullable: false),
            //        TerritoryId = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => new { t.EmployeeId, t.TerritoryId })
            //    .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Territory", t => t.TerritoryId, cascadeDelete: true)
            //    .Index(t => t.EmployeeId)
            //    .Index(t => t.TerritoryId);

        }

        public override void Down()
        {
            //DropForeignKey("dbo.Product", "SupplierId", "dbo.Supplier");
            //DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            //DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            //DropForeignKey("dbo.Order", "ShipperId", "dbo.Shipper");
            //DropForeignKey("dbo.Order", "EmployeeId", "dbo.Employee");
            //DropForeignKey("dbo.EmployeeTerritory", "TerritoryId", "dbo.Territory");
            //DropForeignKey("dbo.EmployeeTerritory", "EmployeeId", "dbo.Employee");
            //DropForeignKey("dbo.Territory", "RegionId", "dbo.Region");
            //DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            //DropForeignKey("dbo.CustomerCustomerDemo", "CustomerDemographicId", "dbo.CustomerDemographic");
            //DropForeignKey("dbo.CustomerCustomerDemo", "CustomerId", "dbo.Customer");
            //DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            //DropIndex("dbo.EmployeeTerritory", new[] { "TerritoryId" });
            //DropIndex("dbo.EmployeeTerritory", new[] { "EmployeeId" });
            //DropIndex("dbo.Territory", new[] { "RegionId" });
            //DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerDemographicId" });
            //DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerId" });
            //DropIndex("dbo.Order", new[] { "ShipperId" });
            //DropIndex("dbo.Order", new[] { "EmployeeId" });
            //DropIndex("dbo.Order", new[] { "CustomerId" });
            //DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            //DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            //DropIndex("dbo.Product", new[] { "CategoryId" });
            //DropIndex("dbo.Product", new[] { "SupplierId" });
            //DropTable("dbo.EmployeeTerritory");
            //DropTable("dbo.ViewSummaryOfSalesByYear");
            //DropTable("dbo.ViewSummaryOfSalesByQuarter");
            //DropTable("dbo.ViewSalesTotalsByAmount");
            //DropTable("dbo.ViewSalesByCategory");
            //DropTable("dbo.ViewProductsByCategory");
            //DropTable("dbo.ViewProductSalesFfor1997");
            //DropTable("dbo.ViewProductsAboveAveragePrice");
            //DropTable("dbo.ViewOrderSubtotals");
            //DropTable("dbo.ViewOrdersQry");
            //DropTable("dbo.ViewOrderDetailsExtended");
            //DropTable("dbo.ViewInvoices");
            //DropTable("dbo.ViewCustomerAndSuppliersByCity");
            //DropTable("dbo.ViewCurrentProductList");
            //DropTable("dbo.ViewCategorySalesFor1997");
            //DropTable("dbo.ViewAlphabeticalListOfProducts");
            //DropTable("dbo.Supplier");
            //DropTable("dbo.Shipper");
            //DropTable("dbo.Region");
            //DropTable("dbo.Territory");
            //DropTable("dbo.Employee");
            //DropTable("dbo.CustomerDemographic");
            //DropTable("dbo.CustomerCustomerDemo");
            //DropTable("dbo.Customer");
            //DropTable("dbo.Order");
            //DropTable("dbo.OrderDetail");
            //DropTable("dbo.Product");
            //DropTable("dbo.Category");
        }
    }
}
