
-- Restaurant Management System Database Create

CREATE DATABASE RestaurantManagementSystem

USE RestaurantManagementSystem

-- Table Creation (Supplier, Chefs, Material, Supplies, Dish, Customer, Cooks, Waiter, Serve, Takes, Delivery_service, Order_dish)

---- Supplier_01 Table Create

CREATE TABLE Supplier_01(
    S_name VARCHAR(10), 
	City VARCHAR(10), 
	Quantity_KG DECIMAL(18,2), 
	Item_name VARCHAR(10)
)

---- Chefs Table Create

CREATE TABLE Chefs(
    C_id INT,
    Speciality VARCHAR(10),
    City VARCHAR(10),
    C_Phone_no NUMERIC(11)
)

---- Material Table Create

CREATE TABLE Material(
     M_id INT,
     Price_TK NUMERIC(5),
     Quantity_Used_Kg DECIMAL(18,2),
     Item_Name VARCHAR(10),
     C_id INT
)

---- Dish Table Create

CREATE TABLE Dish(
     Dish_Name VARCHAR(10),
     Price_Tk NUMERIC(5),
     C_id INT
)

---- Customer Table Create

CREATE TABLE Customer(
     Invoice_no INT,
     Phone_no NUMERIC(11)
)

---- Waiter Table Create

CREATE TABLE Waiter(
     E_id INT NOT NULL,
     Table_no VARCHAR(5),
     City VARCHAR(10),
     E_Phone_no NUMERIC(11)
)

---- Delivery_service Table Create

CREATE TABLE Delivery_service(
     D_id INT NOT NULL,
     Location VARCHAR(10),
     D_Phone_no NUMERIC(11)
)

---- Creating Sequences for Rest of the Table

CREATE SEQUENCE Table_1
       START WITH 1
       INCREMENT BY 1
       MINVALUE 0
       MAXVALUE 5
       CYCLE;

---- Supplies Table Create

CREATE TABLE Supplies(
     Tb_1 NUMERIC(5),
     S_Name VARCHAR(10),
     M_id INT
)

---- Cooks Table Create

CREATE TABLE Cooks(
     Tb_2 NUMERIC(2),
     Dish_Name VARCHAR(10),
     Invoice_no INT
)

---- Serve Table Create

CREATE TABLE Serve(
     Tb_3 NUMERIC(5) NOT NULL,
     Dish_Name VARCHAR(10),
     E_id INT
)

---- Takes Table Create

CREATE TABLE Takes(
     Tb_4 INT NOT NULL,
     E_id INT,
     Invoice_no INT
)

---- Order_dish Table Create

CREATE TABLE Order_dish(
     Tb_5 INT NOT NULL,
     Invoice_no INT,
     D_id INT
)

-- Inserting Values into (Supplier, Chefs, Material, Supplies, Dish, Customer, Cooks, Waiter, Serve, Takes, Delivery_service, Order_dish)

---- Inserting Values into Supplier Table

INSERT INTO Supplier_01 VALUES('Rasel','Dhaka',20,'Potato')
INSERT INTO Supplier_01 VALUES('Tanvir','Barishal',5,'Pepper')
INSERT INTO Supplier_01 VALUES('Rony','Comilla',40,'Onion')
INSERT INTO Supplier_01 VALUES('Mahadi','Dhaka',50,'Chicken')
INSERT INTO Supplier_01 VALUES('Rahman','Dhaka',100,'Rice')

SELECT * FROM Supplier_01

---- Inserting Values into Chefs Table

INSERT INTO Chefs VALUES(0101,'Chinese','Dhaka',01902405706)
INSERT INTO Chefs VALUES(0102,'Deshi Dish','Dhaka',01915682141)
INSERT INTO Chefs VALUES(0103,'Biriyany','Dhaka',01712014961)
INSERT INTO Chefs VALUES(0104,'Momos','Comilla',01615616771)
INSERT INTO Chefs VALUES(0105,'Tehari','Dhaka',01995616771)

SELECT * FROM Chefs

---- Inserting Values into Material Table

INSERT INTO Material VALUES(110,500,12,'Potato',0101)
INSERT INTO Material VALUES(210,375,3,'Pepper',0104)
INSERT INTO Material VALUES(351,4800,30,'Onion',0102)
INSERT INTO Material VALUES(411,12000,40,'Chicken',0103)
INSERT INTO Material VALUES(501,5000,50,'Rice',0105)

SELECT * FROM Material

---- Inserting Values into Supplies Table

INSERT INTO supplies VALUES(NEXT VALUE FOR Table_1,'Rasel',110)
INSERT INTO supplies VALUES(NEXT VALUE FOR Table_1,'Tanvir',210)
INSERT INTO supplies VALUES(NEXT VALUE FOR Table_1,'Rony',351)
INSERT INTO supplies VALUES(NEXT VALUE FOR Table_1,'Mahadi',411)
INSERT INTO supplies VALUES(NEXT VALUE FOR Table_1,'Rahman',501)

SELECT * FROM Supplies

---- Inserting Values into Dish Table

INSERT INTO Dish VALUES('Chinese',1200,0101)
INSERT INTO Dish VALUES('Deshi Dish',200,0102)
INSERT INTO Dish VALUES('Biriyani',500,0103)
INSERT INTO Dish VALUES('Momos',120,0104)
INSERT INTO Dish VALUES('Tehari',350,0105)

SELECT * FROM Dish

---- Inserting Values into Customer Table

INSERT INTO Customer VALUES(111,01912626515)
INSERT INTO Customer VALUES(222,01812131717)
INSERT INTO Customer VALUES(333,01715682141)
INSERT INTO Customer VALUES(444,01902505607)
INSERT INTO Customer VALUES(555,01911156111)

SELECT * FROM Customer

---- Inserting Values into Cooks Table

INSERT INTO Cooks VALUES(NEXT VALUE FOR Table_1,'Chinese',111)
INSERT INTO Cooks VALUES(NEXT VALUE FOR Table_1,'Biriyani',222)
INSERT INTO Cooks VALUES(NEXT VALUE FOR Table_1,'Biriyani',333)
INSERT INTO Cooks VALUES(NEXT VALUE FOR Table_1,'Deshi Dish',444)
INSERT INTO Cooks VALUES(NEXT VALUE FOR Table_1,'Chinese',555)

SELECT * FROM Cooks

---- Inserting Values into Waiter Table

INSERT INTO Waiter VALUES(12101,'1a','Chittagong',01711115671)
INSERT INTO Waiter VALUES(11101,'2b','Dhaka',01915682515)
INSERT INTO Waiter VALUES(12251,'3a','Dhaka',01923256101)
INSERT INTO Waiter VALUES(13515,'3f','Comilla',01612656961)
INSERT INTO Waiter VALUES(18616,'3d','Barishal',01812656861)

SELECT * FROM Waiter

---- Inserting Values into Serve Table

INSERT INTO Serve VALUES(NEXT VALUE FOR Table_1,'Chinese',12101)
INSERT INTO Serve VALUES(NEXT VALUE FOR Table_1,'Biriyani',11101)
INSERT INTO Serve VALUES(NEXT VALUE FOR Table_1,'Deshi Dish',13515)
INSERT INTO Serve VALUES(NEXT VALUE FOR Table_1,'Tehari',18616)
INSERT INTO Serve VALUES(NEXT VALUE FOR Table_1,'Momos',12251)

SELECT * FROM Serve

---- Inserting Values into Takes Table

INSERT INTO Takes VALUES(NEXT VALUE FOR Table_1,12101,111)
INSERT INTO Takes VALUES(NEXT VALUE FOR Table_1,11101,222)
INSERT INTO Takes VALUES(NEXT VALUE FOR Table_1,11101,333)
INSERT INTO Takes VALUES(NEXT VALUE FOR Table_1,13515,444)
INSERT INTO Takes VALUES(NEXT VALUE FOR Table_1,12101,555)

SELECT * FROM Takes

---- Inserting Values into Delivery_service Table

INSERT INTO Delivery_service VALUES(1111,'Dhanmondi',01912626261)
INSERT INTO Delivery_service VALUES(1121,'Uttara',01715616761)
INSERT INTO Delivery_service VALUES(1113,'Kuratoli',01616161111)
INSERT INTO Delivery_service VALUES(1116,'Kuril',01715682515)
INSERT INTO Delivery_service VALUES(1122,'Dhanmondi',01912626261)

SELECT * FROM Delivery_service

---- Inserting Values into Order_dish Table

INSERT INTO Order_dish VALUES(NEXT VALUE FOR Table_1,111,1111)
INSERT INTO Order_dish VALUES(NEXT VALUE FOR Table_1,222,1121)
INSERT INTO Order_dish VALUES(NEXT VALUE FOR Table_1,333,1113)
INSERT INTO Order_dish VALUES(NEXT VALUE FOR Table_1,444,1116)
INSERT INTO Order_dish VALUES(NEXT VALUE FOR Table_1,555,1111)

SELECT * FROM Order_dish

---- Adding Constraints in Each Table with Primary and Foreign Key

ALTER TABLE Supplier_01 ADD CONSTRAINT c001 PRIMARY KEY (s_name)

ALTER TABLE Chefs ADD CONSTRAINT c002 PRIMARY KEY (C_id)

ALTER TABLE Material ADD CONSTRAINT c003 PRIMARY KEY (M_id)
ALTER TABLE Material ADD CONSTRAINT c004 FOREIGN KEY (C_id) REFERENCES Chefs(C_id)

ALTER TABLE Supplies ADD CONSTRAINT c005 PRIMARY KEY (Tb_1)
ALTER TABLE Supplies ADD CONSTRAINT c006 FOREIGN KEY (S_name) REFERENCES Supplier_01(S_name)
ALTER TABLE Supplies ADD CONSTRAINT c007 FOREIGN KEY (M_id) REFERENCES Material(M_id)

ALTER TABLE Dish ADD CONSTRAINT c008 PRIMARY KEY (Dish_name)
ALTER TABLE Dish ADD CONSTRAINT c009 FOREIGN KEY (C_id) REFERENCES Chefs(C_id)

ALTER TABLE Customer ADD CONSTRAINT c010 PRIMARY KEY (Invoice_no)

ALTER TABLE Cooks ADD CONSTRAINT c011 PRIMARY KEY (Tb_2)
ALTER TABLE Cooks ADD CONSTRAINT c012 FOREIGN KEY (Dish_name) REFERENCES Dish(Dish_name)
ALTER TABLE Cooks ADD CONSTRAINT c013 FOREIGN KEY (Invoice_no) REFERENCES Customer(Invoice_no)

ALTER TABLE Waiter ADD CONSTRAINT c014 PRIMARY KEY (E_id)

ALTER TABLE Serve ADD CONSTRAINT c015 PRIMARY KEY (Tb_3)
ALTER TABLE Serve ADD CONSTRAINT c016 FOREIGN KEY (Dish_name) REFERENCES Dish(Dish_name)
ALTER TABLE Serve ADD CONSTRAINT c017 FOREIGN KEY (E_id) REFERENCES Waiter(E_id)

ALTER TABLE Takes ADD CONSTRAINT c018 PRIMARY KEY (Tb_4)
ALTER TABLE Takes ADD CONSTRAINT c019 FOREIGN KEY (E_id) REFERENCES Waiter(E_id)
ALTER TABLE Takes ADD CONSTRAINT c020 FOREIGN KEY (Invoice_no) REFERENCES Customer(Invoice_no)

ALTER TABLE Delivery_service ADD CONSTRAINT c021 PRIMARY KEY (D_id)

ALTER TABLE Order_dish ADD CONSTRAINT c022 FOREIGN KEY (Invoice_no) REFERENCES Customer(Invoice_no)
ALTER TABLE Order_dish ADD CONSTRAINT c023 FOREIGN KEY (D_id) REFERENCES Delivery_service(D_id)


-- Adding Index For Each Table (Supplier, Chefs, Material, Supplies, Dish, Customer, Cooks, Waiter, Serve, Takes, Delivery_service, Order_dish)


CREATE INDEX index_1 ON supplier_01(quantity_kg)

CREATE INDEX index_2 ON supplier_01(city,item_name)

CREATE INDEX index_3 ON chefs(c_id,speciality,city,c_phone_no)

CREATE INDEX index_4 ON Material(M_id,Price_TK,Quantity_Used_Kg,Item_Name,C_id)

CREATE INDEX index_5 ON Supplies(Tb_1,S_Name,M_id)

CREATE INDEX index_6 ON Dish(Dish_Name,Price_Tk,C_id)

CREATE INDEX index_7 ON Customer(Invoice_no,Phone_no)

CREATE INDEX index_8 ON Cooks(Tb_2,Dish_Name,Invoice_no)

CREATE INDEX index_9 ON Waiter(E_id,Table_no,City,E_Phone_no)

CREATE INDEX index_10 ON Serve(Tb_3,Dish_Name,E_id)

CREATE INDEX index_11 ON Takes(Tb_4,E_id,Invoice_no)

CREATE INDEX index_12 ON Delivery_service(D_id,Location,D_Phone_no)

CREATE INDEX index_13 ON Order_dish(Tb_5,Invoice_no,D_id)
