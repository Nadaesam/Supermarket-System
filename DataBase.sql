CREATE TABLE Product
(
  Name varchar (50) NOT NULL,
  ProductID INT NOT NULL,
  Category varchar (50)  NOT NULL,
  Price float NOT NULL,
  Quantity INT NOT NULL,
  PRIMARY KEY (ProductID)
);



CREATE TABLE Customer
( 
  UserID INT,
  Email Varchar(50) ,
  Acc_Password INT NOT NULL,
  FirstName Varchar(50) NOT NULL,
  LastName Varchar(50) NOT NULL,
  UserName Varchar(50) NOT NULL,
  Address Varchar(100) NOT NULL,
  UNIQUE (Email),
  PRIMARY KEY (UserID)
);

CREATE TABLE Admin
(	
  UserID INT,
  Email Varchar(50) not null ,
  Acc_Password INT NOT NULL,
  FirstName Varchar(50) NOT NULL,
  LastName Varchar(50) NOT NULL,
  UserName Varchar(50) NOT NULL,
  UNIQUE (Email),
  PRIMARY KEY (UserID)
  
);

CREATE TABLE Orders
(
  OrderID INT ,
  Amount INT,
  Day INT,
  Month INT ,
  Year INT ,
  CustomerID int,
  PRIMARY KEY (OrderID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(UserID)
  ON UPDATE CASCADE
  ON DELETE CASCADE
);

CREATE TABLE OrderDetails
(
  TotalPrice float ,
  OrderID INT ,
  ProductID INT ,
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON UPDATE CASCADE
  ON DELETE CASCADE,
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON UPDATE CASCADE
  ON DELETE CASCADE
);


CREATE TABLE PhoneNumber
(
  Phone INT ,
  UserID INT NOT NULL,
  FOREIGN KEY (UserID) REFERENCES Customer(UserID) ON UPDATE CASCADE
  ON DELETE CASCADE
);



Select p.Name from Product p, OrderDetails o where p.productID = (Select o.productID
from OrderDetails o
group by o.productID having count(o.productID)=2) group by p.Name;


Select p.Name from Product p where p.productID Not In (Select o.productID from OrderDetails o);


Select c.FirstName from Customer c , Orders o where c.UserID=o.CustomerID and (
o.year in ('2020', '2021' ) and (o.Month <= '5') and o.year
<> '2022' )
group by c.FirstName ;



select top 1 TotalPrice, Customer.FirstName, Customer.LastName
From Customer, Orders, OrderDetails
where Customer.UserID= Orders.CustomerID
and   Orders.OrderID= OrderDetails.OrderID
and Orders.Month = 5
and Orders.Year = 2022;

select count( Category ) as NumberOfPurchase,Category from product, orderdetails,Orders,customer
where orders.OrderID=OrderDetails.OrderID
and product.ProductID=OrderDetails.ProductID
and Customer.UserID=Orders.CustomerID
group by category  
order by category desc;

select count ( Customer.UserID) as NumberOfCustomers, product.Name, product.ProductID, product.Category,Product.price,Product.Quantity from product,   Customer ,orders,OrderDetails
	where Product.ProductID=OrderDetails.ProductID
	and Customer.UserID=Orders.CustomerID
	and OrderDetails.OrderID=Orders.OrderID 
	group by  product.Name , product.Category,Product.price,product.ProductID,Product.Quantity
	order by NumberOfCustomers desc;