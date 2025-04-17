
-- Restaurant Management System Database

USE RestaurantManagementSystem

-- This File Consist SQL Queries Including (Single-row functions, Group function, Subquery, Joining, Views and Synonym)

--- ##Single Row Function

---- 1. Display table number of the waiter whose city is in Dhaka with the all of the letters capitalized.

SELECT UPPER(Table_no) AS Table_Number, UPPER(City) AS City
FROM Waiter WHERE City= 'DHAKA'

---- 2. Displays Employee ID and Table number of waiters in a Single Column.

SELECT CONCAT(e_id,table_no) AS Assigned_Waiters
FROM Waiter

---- 3. Display Dish Name of the dishes whose price is not more than Five Hundred Tk.

SELECT Dish_Name,Price_Tk
FROM Dish WHERE Price_Tk <= 500

--- ##Group Function

---- 1. Display the minimum price among all of the dishes.

SELECT MIN(Price_Tk) AS Minimum_Price
FROM Dish 

---- 2. Display the maximum price among all of the dishes.

SELECT MAX(Price_Tk) AS Maximum_Price
FROM Dish 

---- 3.	Display the average price of all the dishes.

SELECT AVG(Price_Tk) AS Average_Price
FROM Dish 

--- ##Sub-query

---- 1.	Display the item name of a material which has a price greater than TK 4800?

SELECT Item_Name
FROM Material
WHERE Price_TK > (SELECT Price_TK FROM Material WHERE Price_TK = 4800)

---- 2. Display the dish name whose price is greater than TK 500?

SELECT Dish_Name
FROM Dish
WHERE Price_TK > (SELECT Price_TK FROM Dish WHERE Price_TK = 500)

---- 3.	Find the dish name which has the maximum price.

SELECT Dish_Name
FROM Dish 
WHERE Price_TK =(SELECT MAX(Price_Tk) FROM Dish)

--- ##Joining

---- 1. Create a query to display the table number and dish name.

SELECT Table_no,Dish_Name
FROM Waiter JOIN Serve
ON Waiter.E_id = Serve.E_id

---- 2.	Display the invoice no along with dish name.

SELECT Invoice_no,Dish_name
FROM Takes JOIN Serve
ON Takes.E_id=.Serve.E_id

---- 3. Display the quantity in kg of the supplies that has been supplied along with the quantity that has been used.

SELECT Quantity_KG, Quantity_Used_Kg
FROM Supplier_01 JOIN Material
ON Supplier_01.Item_Name = Material.Item_Name

--- ##Views

---- 1.	Create a view called mats which will have material id, item name and price of materials, .

CREATE VIEW mats 
AS SELECT M_id,Item_Name, Price_Tk
FROM Material

SELECT * FROM mats 

---- 2.	Display the contents of the view mat.

CREATE OR ALTER VIEW mats(price_tk,mat_id,I_Name) 
AS SELECT Price_Tk, M_id,Item_Name
FROM Material

SELECT * FROM mats 

---- 3. Drop view mat.   

Drop VIEW mats

--- ##Synonym

---- 1.	Create synonym for material.

CREATE SYNONYM mat FOR Material

---- 2.	Drop synonym for material.

DROP SYNONYM mat

---- 3.	Create synonym for waiter.

CREATE SYNONYM Staff FOR Waiter




