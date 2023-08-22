-- create database ecommerceDB


CREATE TABLE Customer_Details
(
	[Customer_Email] VARCHAR(900),
	[Customer_Name] VARCHAR(255),
	[Customer_MobileNo] VARCHAR(50),
	[Customer_AddressLine_1] VARCHAR(255),
	[Customer_AddressLine_2] VARCHAR(255),
	[Customer_City] VARCHAR(255),
	CONSTRAINT [customer_id_pk] PRIMARY KEY(Customer_Email)
);

--insert into Customer_Details(Customer_Email, Customer_Name, Customer_MobileNo, Customer_AddressLine_1, Customer_AddressLine_2, Customer_City)
--values('dummymail@gmail.com', 'dummy', '8754893764', 'No,290', 'xyz street', 'chennai')

select * from Customer_Details

delete from Customer_Details
where Customer_Email = 'rmanikandan102000@gmail.com'

-------------------------------------------------------------------------------------------------------------

CREATE TABLE Orders
(
	[Order_ID] INT IDENTITY(1,1),
	[Customer_Email] VARCHAR(900),
	[Order_Date] VARCHAR(50),
	[Delivery_Date] VARCHAR(50),
	[Shipment_City] VARCHAR(255),
	[Shipment_Status] INT,
	CONSTRAINT [order_id_pk] PRIMARY KEY(Order_ID),
	CONSTRAINT [order_id_customer_fk] FOREIGN KEY(Customer_Email) REFERENCES Customer_Details(Customer_Email)
);

--insert into Orders(Customer_Email, Order_Date, Delivery_Date, Shipment_City, Shipment_Status)
--values('dummymail@gmail.com', '04/08/2023', '07/08/2023', 'Chennai', 1)

select * from products
select * from Orders
select * from Order_Items

delete from Orders
where Order_ID = 7;

-------------------------------------------------------------------------------------------------------------

CREATE TABLE Products
(
	[Product_ID] INT IDENTITY(1,1),
	[Product_Name] VARCHAR(255),
	[Price] VARCHAR(50),
	CONSTRAINT [product_id_pk] PRIMARY KEY(Product_ID)
);

--insert into Products(Product_Name, Price)
--values('laptop', '50000')

select * from Products

-------------------------------------------------------------------------------------------------------------

CREATE TABLE Order_Items
(
	[OrderItem_ID] INT IDENTITY(1,1),
	[Order_ID] INT,
	[Product_ID] INT,
	[Quantity] INT,
	[UnitPrice] VARCHAR(50),
	[TotalPrice] VARCHAR(50),
	CONSTRAINT [orderitem_id_pk] PRIMARY KEY(OrderItem_ID),
	CONSTRAINT [orderitem_orderid_fk] FOREIGN KEY(Order_ID) REFERENCES Orders(Order_ID) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [orderitem_productid_fk] FOREIGN KEY(Product_ID) REFERENCES Products(Product_ID)
);

--insert into Order_Items(Order_ID, Product_ID, Quantity, UnitPrice, TotalPrice)
--values(1, 1, 1, '50000', '50000')

select * from Order_Items

delete from Order_Items
where OrderItem_ID = 5









