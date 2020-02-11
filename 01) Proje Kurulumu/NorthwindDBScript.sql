/****** Object:  Table [dbo].[Order]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerCode] [nchar](5) NULL,
	[EmployeeId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[ShipperId] [int] NULL,
	[Freight] [money] NULL,
	[ShipName] [nvarchar](40) NULL,
	[ShipAddress] [nvarchar](60) NULL,
	[ShipCity] [nvarchar](15) NULL,
	[ShipRegion] [nvarchar](15) NULL,
	[ShipPostalCode] [nvarchar](10) NULL,
	[ShipCountry] [nvarchar](15) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Discount] [real] NOT NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[SupplierId] [int] NULL,
	[CategoryId] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
	[Discontinued] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
	[Description] [ntext] NULL,
	[Picture] [varbinary](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewProductSalesFfor1997]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewProductSalesFfor1997] AS

SELECT Category.CategoryName, Product.ProductName, 
Sum(CONVERT(money,(OrderDetail.UnitPrice* OrderDetail.Quantity*(1-OrderDetail.Discount)/100))*100) AS ProductSales
FROM (Category INNER JOIN Product ON Category.Id = Product.CategoryID) 
	INNER JOIN ([Order]
		INNER JOIN OrderDetail ON [Order].Id = OrderDetail.Id) 
	ON Product.Id = OrderDetail.ProductID
WHERE ((([Order].ShippedDate) Between '19970101' And '19971231'))
GROUP BY Category.CategoryName, Product.ProductName



GO
/****** Object:  View [dbo].[ViewCategorySalesFor1997]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewCategorySalesFor1997] AS
SELECT ViewProductSalesFfor1997.CategoryName, Sum(ViewProductSalesFfor1997.ProductSales) AS CategorySales
FROM ViewProductSalesFfor1997
GROUP BY ViewProductSalesFfor1997.CategoryName



GO
/****** Object:  View [dbo].[ViewOrderDetailsExtended]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewOrderDetailsExtended] AS

SELECT OrderDetail.Id, OrderDetail.ProductID, Product.ProductName, 
	OrderDetail.UnitPrice, OrderDetail.Quantity, OrderDetail.Discount, 
	(CONVERT(money,(OrderDetail.UnitPrice*Quantity*(1-Discount)/100))*100) AS ExtendedPrice
FROM Product INNER JOIN OrderDetail ON Product.Id = OrderDetail.ProductID
--ORDER BY "Order Details".OrderID



GO
/****** Object:  View [dbo].[ViewSalesByCategory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewSalesByCategory] AS


SELECT Category.Id, Category.CategoryName, Product.ProductName, 
	Sum(ViewOrderDetailsExtended.ExtendedPrice) AS ProductSales
FROM 	Category INNER JOIN 
		(Product INNER JOIN 
			([Order] INNER JOIN ViewOrderDetailsExtended ON [Order].Id = ViewOrderDetailsExtended.Id) 
		ON Product.Id = ViewOrderDetailsExtended.ProductID) 
	ON Category.Id = Product.CategoryID
WHERE [Order].OrderDate BETWEEN '19970101' And '19971231'
GROUP BY Category.Id, Category.CategoryName, Product.ProductName
--ORDER BY Products.ProductName



GO
/****** Object:  View [dbo].[ViewOrderSubtotals]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewOrderSubtotals] AS

SELECT OrderDetail.Id, Sum(CONVERT(money,(OrderDetail.UnitPrice*Quantity*(1-Discount)/100))*100) AS Subtotal
FROM OrderDetail
GROUP BY OrderDetail.Id



GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nchar](5) NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewSalesTotalsByAmount]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewSalesTotalsByAmount] AS
SELECT ViewOrderSubtotals.Subtotal AS SaleAmount, [Order].Id, Customer.CompanyName, [Order].ShippedDate
FROM 	Customer INNER JOIN 
		([Order] INNER JOIN ViewOrderSubtotals ON [Order].Id = ViewOrderSubtotals.Id) 
	ON Customer.Id = [Order].CustomerId
WHERE (ViewOrderSubtotals.Subtotal >2500) AND ([Order].ShippedDate BETWEEN '19970101' And '19971231')



GO
/****** Object:  View [dbo].[ViewSummaryOfSalesByQuarter]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewSummaryOfSalesByQuarter] AS

SELECT [Order].ShippedDate, [Order].Id, ViewOrderSubtotals.Subtotal
FROM [Order] INNER JOIN ViewOrderSubtotals ON [Order].Id = ViewOrderSubtotals.Id
WHERE [Order].ShippedDate IS NOT NULL
--ORDER BY Orders.ShippedDate



GO
/****** Object:  View [dbo].[ViewSummaryOfSalesByYear]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewSummaryOfSalesByYear] AS

SELECT [Order].ShippedDate, [Order].Id, ViewOrderSubtotals.Subtotal
FROM [Order] INNER JOIN ViewOrderSubtotals ON [Order].Id = ViewOrderSubtotals.Id
WHERE [Order].ShippedDate IS NOT NULL
--ORDER BY Orders.ShippedDate



GO
/****** Object:  View [dbo].[ViewAlphabeticalListOfProducts]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewAlphabeticalListOfProducts] AS
SELECT Product.*, Category.CategoryName
FROM Category INNER JOIN Product ON Category.Id = Product.CategoryID
WHERE (((Product.Discontinued)=0))



GO
/****** Object:  View [dbo].[ViewCurrentProductList]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewCurrentProductList] AS
SELECT Product_List.Id, Product_List.ProductName
FROM Product AS Product_List
WHERE (((Product_List.Discontinued)=0))
--ORDER BY Product_List.ProductName



GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[HomePage] [ntext] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewCustomerAndSuppliersByCity]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewCustomerAndSuppliersByCity] AS

SELECT City, CompanyName, ContactName, 'Customers' AS Relationship 
FROM Customer
UNION SELECT City, CompanyName, ContactName, 'Suppliers'
FROM Supplier
--ORDER BY City, CompanyName



GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[HomePhone] [nvarchar](24) NULL,
	[Extension] [nvarchar](4) NULL,
	[Photo] [image] NULL,
	[Notes] [ntext] NULL,
	[ReportsTo] [int] NULL,
	[PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewInvoices]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewInvoices] AS

SELECT [Order].ShipName, [Order].ShipAddress, [Order].ShipCity, [Order].ShipRegion, [Order].ShipPostalCode, 
	[Order].ShipCountry, [Order].CustomerID, Customer.CompanyName AS CustomerName, Customer.Address, Customer.City, 
	Customer.Region, Customer.PostalCode, Customer.Country, 
	(FirstName + ' ' + LastName) AS Salesperson, 
	[Order].Id, [Order].OrderDate, [Order].RequiredDate, [Order].ShippedDate, Shipper.CompanyName As ShipperName, 
	OrderDetail.ProductID, Product.ProductName, OrderDetail.UnitPrice, OrderDetail.Quantity, 
	OrderDetail.Discount, 
	(CONVERT(money,(OrderDetail.UnitPrice*Quantity*(1-Discount)/100))*100) AS ExtendedPrice, [Order].Freight
FROM 	Shipper INNER JOIN 
		(Product INNER JOIN 
			(
				(Employee INNER JOIN 
					(Customer INNER JOIN [Order] ON Customer.Id = [Order].Id) 
				ON Employee.Id = [Order].EmployeeId) 
			INNER JOIN OrderDetail ON [Order].Id = OrderDetail.Id) 
		ON Product.Id = OrderDetail.ProductID) 
	ON Shipper.Id = [Order].ShipperId



GO
/****** Object:  View [dbo].[ViewOrdersQry]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewOrdersQry] AS

SELECT [Order].Id, [Order].CustomerID, [Order].EmployeeID, [Order].OrderDate, [Order].RequiredDate, 
	[Order].ShippedDate, [Order].ShipperId, [Order].Freight, [Order].ShipName, [Order].ShipAddress, [Order].ShipCity, 
	[Order].ShipRegion, [Order].ShipPostalCode, [Order].ShipCountry, 
	Customer.CompanyName, Customer.Address, Customer.City, Customer.Region, Customer.PostalCode, Customer.Country
FROM Customer INNER JOIN [Order] ON Customer.Id = [Order].CustomerId



GO
/****** Object:  View [dbo].[ViewProductsAboveAveragePrice]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewProductsAboveAveragePrice] AS
SELECT Product.ProductName, Product.UnitPrice
FROM Product
WHERE Product.UnitPrice>(SELECT AVG(UnitPrice) From Product)
--ORDER BY Products.UnitPrice DESC



GO
/****** Object:  View [dbo].[ViewProductsByCategory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewProductsByCategory] AS

SELECT Category.CategoryName, Product.ProductName, Product.QuantityPerUnit, Product.UnitsInStock, Product.Discontinued
FROM Category INNER JOIN Product ON Category.Id = Product.CategoryId
WHERE Product.Discontinued <> 1
--ORDER BY Categories.CategoryName, Products.ProductName



GO
/****** Object:  View [dbo].[ViewQuarterlyOrders]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ViewQuarterlyOrders] AS

SELECT DISTINCT Customer.Id, Customer.CompanyName, Customer.City, Customer.Country
FROM Customer RIGHT JOIN [Order] ON Customer.Id = [Order].CustomerID
WHERE [Order].OrderDate BETWEEN '19970101' And '19971231'



GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerCustomerDemo]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCustomerDemo](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerDemographicId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerCustomerDemo] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[CustomerDemographicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDemographic]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDemographic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerDesc] [ntext] NULL,
	[Code] [nchar](10) NULL,
 CONSTRAINT [PK_CustomerDemographic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeFiles]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FileUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_EmployeeFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTerritory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTerritory](
	[EmployeeId] [int] NOT NULL,
	[TerritoryId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeTerritory] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[TerritoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hasta]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hasta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdiSoyadi] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Hasta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeopleBicycle]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeopleBicycle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[Bicycle] [nchar](10) NULL,
	[BuyDate] [smalldatetime] NULL,
 CONSTRAINT [PK_PeopleBicycle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Randevu]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Randevu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HastaId] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Location] [nvarchar](200) NULL,
	[AllDay] [bit] NULL,
	[Type] [int] NULL,
	[Subject] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
 CONSTRAINT [PK_Randevu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegionDescription] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Territory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Territory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TerritoryCode] [nvarchar](20) NOT NULL,
	[TerritoryDescription] [nchar](50) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Territory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CategoryName]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CategoryName] ON [dbo].[Category]
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [City]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [City] ON [dbo].[Customer]
(
	[City] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CompanyName]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CompanyName] ON [dbo].[Customer]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PostalCode]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [PostalCode] ON [dbo].[Customer]
(
	[PostalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Region]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [Region] ON [dbo].[Customer]
(
	[Region] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [LastName]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [LastName] ON [dbo].[Employee]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PostalCode]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [PostalCode] ON [dbo].[Employee]
(
	[PostalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CustomerID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CustomerID] ON [dbo].[Order]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CustomersOrders]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CustomersOrders] ON [dbo].[Order]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EmployeeID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [EmployeeID] ON [dbo].[Order]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EmployeesOrders]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [EmployeesOrders] ON [dbo].[Order]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [OrderDate]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [OrderDate] ON [dbo].[Order]
(
	[OrderDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ShippedDate]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ShippedDate] ON [dbo].[Order]
(
	[ShippedDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ShippersOrders]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ShippersOrders] ON [dbo].[Order]
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ShipPostalCode]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ShipPostalCode] ON [dbo].[Order]
(
	[ShipPostalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetail]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderDetail] ON [dbo].[OrderDetail]
(
	[OrderId] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [OrderID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [OrderID] ON [dbo].[OrderDetail]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [OrdersOrder_Details]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [OrdersOrder_Details] ON [dbo].[OrderDetail]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ProductID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ProductID] ON [dbo].[OrderDetail]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ProductsOrder_Details]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ProductsOrder_Details] ON [dbo].[OrderDetail]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CategoriesProducts]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CategoriesProducts] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CategoryID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CategoryID] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ProductName]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [ProductName] ON [dbo].[Product]
(
	[ProductName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SupplierID]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [SupplierID] ON [dbo].[Product]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SuppliersProducts]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [SuppliersProducts] ON [dbo].[Product]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CompanyName]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [CompanyName] ON [dbo].[Supplier]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PostalCode]    Script Date: 2/11/2020 7:11:31 AM ******/
CREATE NONCLUSTERED INDEX [PostalCode] ON [dbo].[Supplier]
(
	[PostalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Orders_Freight]  DEFAULT ((0)) FOR [Freight]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_Order_Details_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_Order_Details_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_Order_Details_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_UnitsInStock]  DEFAULT ((0)) FOR [UnitsInStock]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_UnitsOnOrder]  DEFAULT ((0)) FOR [UnitsOnOrder]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_ReorderLevel]  DEFAULT ((0)) FOR [ReorderLevel]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_Discontinued]  DEFAULT ((0)) FOR [Discontinued]
GO
ALTER TABLE [dbo].[CustomerCustomerDemo]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCustomerDemo_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerCustomerDemo] CHECK CONSTRAINT [FK_CustomerCustomerDemo_Customer]
GO
ALTER TABLE [dbo].[CustomerCustomerDemo]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCustomerDemo_CustomerDemographic] FOREIGN KEY([CustomerDemographicId])
REFERENCES [dbo].[CustomerDemographic] ([Id])
GO
ALTER TABLE [dbo].[CustomerCustomerDemo] CHECK CONSTRAINT [FK_CustomerCustomerDemo_CustomerDemographic]
GO
ALTER TABLE [dbo].[EmployeeFiles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeFiles_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeFiles] CHECK CONSTRAINT [FK_EmployeeFiles_Employee]
GO
ALTER TABLE [dbo].[EmployeeTerritory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTerritories_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeTerritory] CHECK CONSTRAINT [FK_EmployeeTerritories_Employees]
GO
ALTER TABLE [dbo].[EmployeeTerritory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTerritory_Territory] FOREIGN KEY([TerritoryId])
REFERENCES [dbo].[Territory] ([Id])
GO
ALTER TABLE [dbo].[EmployeeTerritory] CHECK CONSTRAINT [FK_EmployeeTerritory_Territory]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[Shipper] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Shippers]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Details_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_Order_Details_Products]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Hasta] FOREIGN KEY([HastaId])
REFERENCES [dbo].[Hasta] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Hasta]
GO
ALTER TABLE [dbo].[Territory]  WITH CHECK ADD  CONSTRAINT [FK_Territories_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Territory] CHECK CONSTRAINT [FK_Territories_Region]
GO
ALTER TABLE [dbo].[Employee]  WITH NOCHECK ADD  CONSTRAINT [CK_Birthdate] CHECK  (([BirthDate]<getdate()))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_Birthdate]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [CK_Discount] CHECK  (([Discount]>=(0) AND [Discount]<=(1)))
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_Discount]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [CK_Quantity] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_Quantity]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_UnitPrice]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [CK_Products_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_Products_UnitPrice]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [CK_ReorderLevel] CHECK  (([ReorderLevel]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_ReorderLevel]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsInStock] CHECK  (([UnitsInStock]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_UnitsInStock]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsOnOrder] CHECK  (([UnitsOnOrder]>=(0)))
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CK_UnitsOnOrder]
GO
/****** Object:  StoredProcedure [dbo].[CustOrderHist]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustOrderHist] @CustomerID nchar(5)
AS
SELECT ProductName, Total=SUM(Quantity)
FROM Products P, [Order Details] OD, Orders O, Customers C
WHERE C.CustomerID = @CustomerID
AND C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID AND OD.ProductID = P.ProductID
GROUP BY ProductName


GO
/****** Object:  StoredProcedure [dbo].[CustOrdersDetail]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustOrdersDetail] @OrderID int
AS
SELECT ProductName,
    UnitPrice=ROUND(Od.UnitPrice, 2),
    Quantity,
    Discount=CONVERT(int, Discount * 100), 
    ExtendedPrice=ROUND(CONVERT(money, Quantity * (1 - Discount) * Od.UnitPrice), 2)
FROM Products P, [Order Details] Od
WHERE Od.ProductID = P.ProductID and Od.OrderID = @OrderID


GO
/****** Object:  StoredProcedure [dbo].[CustOrdersOrders]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustOrdersOrders] @CustomerID nchar(5)
AS
SELECT OrderID, 
	OrderDate,
	RequiredDate,
	ShippedDate
FROM Orders
WHERE CustomerID = @CustomerID
ORDER BY OrderID


GO
/****** Object:  StoredProcedure [dbo].[Employee Sales by Country]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Employee Sales by Country] 
@Beginning_Date DateTime, @Ending_Date DateTime AS
SELECT Employees.Country, Employees.LastName, Employees.FirstName, Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal AS SaleAmount
FROM Employees INNER JOIN 
	(Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID) 
	ON Employees.EmployeeID = Orders.EmployeeID
WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date


GO
/****** Object:  StoredProcedure [dbo].[Sales by Year]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sales by Year] 
	@Beginning_Date DateTime, @Ending_Date DateTime AS
SELECT Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal, DATENAME(yy,ShippedDate) AS Year
FROM Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID
WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date


GO
/****** Object:  StoredProcedure [dbo].[SalesByCategory]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesByCategory]
    @CategoryName nvarchar(15), @OrdYear nvarchar(4) = '1998'
AS
IF @OrdYear != '1996' AND @OrdYear != '1997' AND @OrdYear != '1998' 
BEGIN
	SELECT @OrdYear = '1998'
END

SELECT ProductName,
	TotalPurchase=ROUND(SUM(CONVERT(decimal(14,2), OD.Quantity * (1-OD.Discount) * OD.UnitPrice)), 0)
FROM [Order Details] OD, Orders O, Products P, Categories C
WHERE OD.OrderID = O.OrderID 
	AND OD.ProductID = P.ProductID 
	AND P.CategoryID = C.CategoryID
	AND C.CategoryName = @CategoryName
	AND SUBSTRING(CONVERT(nvarchar(22), O.OrderDate, 111), 1, 4) = @OrdYear
GROUP BY ProductName
ORDER BY ProductName


GO
/****** Object:  StoredProcedure [dbo].[Ten Most Expensive Products]    Script Date: 2/11/2020 7:11:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Ten Most Expensive Products] AS
SET ROWCOUNT 10
SELECT Products.ProductName AS TenMostExpensiveProducts, Products.UnitPrice
FROM Products
ORDER BY Products.UnitPrice DESC
GO
ALTER DATABASE [NorthwindRev] SET  READ_WRITE 
GO
