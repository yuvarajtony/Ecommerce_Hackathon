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

CREATE TABLE Orders
(
	[Order_ID] INT,
	[Customer_Email] VARCHAR(900),
	[Order_Date] VARCHAR(50),
	[Delivery_Date] VARCHAR(50),
	[Shipment_City] VARCHAR(255),
	[Shipment_Status] INT,
	CONSTRAINT [order_id_pk] PRIMARY KEY(Order_ID),
	CONSTRAINT [order_id_customer_fk] FOREIGN KEY(Customer_Email) REFERENCES Customer_Details(Customer_Email)
);

CREATE TABLE Products
(
	[Product_ID] INT,
	[Product_Name] VARCHAR(255),
	[Price] VARCHAR(50),
	CONSTRAINT [product_id_pk] PRIMARY KEY(Product_ID)
);

CREATE TABLE Order_Items
(
	[OrderItem_ID] INT,
	[Order_ID] INT,
	[Product_ID] INT,
	[Quantity] INT,
	[UnitPrice] VARCHAR(50),
	[TotalPrice] VARCHAR(50),
	CONSTRAINT [orderitem_id_pk] PRIMARY KEY(OrderItem_ID),
	CONSTRAINT [orderitem_orderid_fk] FOREIGN KEY(Order_ID) REFERENCES Orders(Order_ID) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [orderitem_productid_fk] FOREIGN KEY(Product_ID) REFERENCES Products(Product_ID)
);










