
-- Restaurant Management System Database

USE RestaurantManagementSystem

-- This File Consist T-SQL Queries Including (Functions, Stored Procedure, Records, Cursor, Trigger and Schema)

--- ##Functions

---- 1.Create a function that returns the total number of Dish serve in the restaurant.

CREATE OR ALTER FUNCTION totalDish()
RETURNS INT
AS
BEGIN 
   DECLARE @total INT;
   SELECT @total = count(*)
   FROM dish  
   RETURN @total
END;

SELECT dbo.totalDish()

---- 2.Create a function that can show the number of Speciality the Chefs has.

CREATE OR ALTER FUNCTION Speciality()
RETURNS INT
AS
BEGIN 
   DECLARE @total INT;
   SELECT @total = count(Speciality) 
   FROM chefs;  
   RETURN @total; 
END;

SELECT dbo.Speciality() AS Number_of_Speciality

---- 3.Create a function that will show where Chefs ID 101 live in.

CREATE OR ALTER FUNCTION City()
RETURNS VARCHAR(20)
AS
BEGIN 
    DECLARE @city_name VARCHAR(20); 
	SELECT @city_name = City 
	FROM Chefs WHERE C_id = '101';
	RETURN @city_name;
END;

SELECT dbo.City() AS Chefs_City

SELECT * FROM Chefs

--- ##Stored Procedure

---- 1. Due to over price of onions the restaurant owner updated the price of Biriyani. So create a procedure to update the value of the dish From tk500 to tk700.

CREATE OR ALTER PROCEDURE Update_price
 (
   @in_price INT
 )
AS
BEGIN
    UPDATE dish
    SET price_tk = 700
    WHERE price_tk = @in_price
END;

EXEC Update_price 500

---- 2. Waiter whose phone number was 01915682515 has lost his phone and brought a new phone with new number. Now create a procedure to change the number from 01915682515 to 01912616888.

CREATE OR ALTER PROCEDURE Update_Phone
 (
    @in_phone INT
 ) 
AS
BEGIN
   UPDATE waiter
   SET e_phone_no = 1912616888
   WHERE e_phone_no= @in_phone
END;

EXEC Update_Phone 1915682515

---- 3. Create a procedure to change the delivery service location from Kuril to Baridhara.

CREATE OR ALTER PROCEDURE Update_loc
  (
    @in_loc VARCHAR(15)
  ) 
AS
BEGIN
   UPDATE delivery_service
   SET location='Baridhara'
   WHERE location= @in_loc
END;

EXEC Update_loc Kuril

--- ##Records

---- 1.	Create a record that can output the city name whose c_id is ‘104’.

DECLARE @city NVARCHAR(100)

BEGIN
    SELECT @city = City
    FROM Chefs 
    WHERE C_id = '104'

    PRINT @city
END;

---- 2.	Create a record that can output the city name of all the chefs inside the Restaurants.

DECLARE @chefs_record TABLE (
    c_id INT,
    city NVARCHAR(100)
);

INSERT INTO @chefs_record
SELECT c_id, city
FROM Chefs;

SELECT 'Chefs ID = ' + CAST(c_id AS NVARCHAR) + ' from ' + city AS Chef_Details
FROM @chefs_record;


---- 3. Create a record that show the dish which price is 350tk.

DECLARE @Dish_Name VARCHAR(25)

BEGIN
    SELECT @Dish_Name = Dish_Name
    FROM dish
    WHERE price_tk = '350'

    PRINT @Dish_Name
END;

--- ##Cursor

---- 1. Create a cursor that can output the dish_name and price_tk of all categories.

DECLARE @Dish_Name VARCHAR(50) 
DECLARE @Price_TK NVARCHAR(50)

DECLARE c_dish CURSOR FOR
SELECT dish_name, price_tk
FROM dish;

OPEN c_dish

FETCH NEXT FROM c_dish INTO @Dish_Name, @Price_TK;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Dish name ' + @Dish_Name + ' Price ' + @Price_TK + ' Tk';
    FETCH NEXT FROM c_dish INTO @Dish_Name, @Price_TK;
END;

CLOSE c_dish
DEALLOCATE c_dish;

---- 2. Create a cursor that can output the first Chefs ID with speciality.

DECLARE @c_id INT
DECLARE @speciality VARCHAR(50)

DECLARE c_chefs CURSOR FOR
SELECT c_id, speciality
FROM chefs;

OPEN c_chefs

FETCH NEXT FROM c_chefs INTO @c_id, @speciality;

PRINT 'Chef ID ' + CAST(@c_id AS NVARCHAR) + ' Speciality is ' + @speciality;

CLOSE c_chefs
DEALLOCATE c_chefs

---- 3.	Create a cursor that can output the 2nd delivery_services ID and place of Delivery.

DECLARE @d_id INT
DECLARE @location NVARCHAR(255)

DECLARE c_service CURSOR FOR
SELECT d_id, location
FROM delivery_service;

OPEN c_service

FETCH NEXT FROM c_service INTO @d_id, @location;
FETCH NEXT FROM c_service INTO @d_id, @location;

PRINT 'ID ' + CAST(@d_id AS NVARCHAR) + ' location is ' + @location;

CLOSE c_service
DEALLOCATE c_service


--- ##Trigger

---- 1. Create a trigger in such a way that whenever a new row is inserted into the delivery_service table an output ‘New Delivery Added’ is generated.

CREATE OR ALTER TRIGGER delivery_service_added
ON delivery_service
AFTER INSERT
AS
BEGIN
    PRINT 'New Delivery Added'
END;

INSERT INTO Delivery_service (D_id,Location, D_Phone_no)
VALUES(1133,'Gulsan', 1812312191)

---- 2.	Create a trigger in such a way that whenever a id deleted from the delivery_service table an output ‘New Delivery Remove’ is generated.

CREATE OR ALTER TRIGGER delivery_service_cancel
ON delivery_service
AFTER DELETE
AS
BEGIN
    PRINT 'New Delivery Remove';
END;

DELETE FROM Delivery_service
WHERE D_id = 1133

---- 3.	Create a trigger to update trigger Deleted for showing output ‘New delivery remove’ to ‘Delivery record Updated’.

CREATE OR ALTER TRIGGER delivery_service_cancel
ON delivery_service
AFTER UPDATE
AS
BEGIN
    PRINT 'Delivery Record Updated';
END;


--- ##Schema

---- 1. Create a schema that contains a procedure which can display the dish name of any dish whose price is passed as its parameter.

CREATE SCHEMA dish_pack;
GO

CREATE OR ALTER PROCEDURE dish_pack.display_dish_name
    @price_tk INT 
AS
BEGIN
    DECLARE @e_dish NVARCHAR(100); 

    SELECT @e_dish = dish_name
    FROM dish
    WHERE Price_Tk = @price_tk;

    PRINT 'Dish is: ' + @e_dish;
END;
GO

EXEC dish_pack.display_dish_name @price_tk = 350;

---- 2. Create a schema that contains a procedure which can display the item name of any material whose price is passed as its parameter. 

CREATE SCHEMA material_pack;
GO

CREATE OR ALTER PROCEDURE material_pack.display_item_name
    @price_tk INT 
AS
BEGIN
    DECLARE @e_material NVARCHAR(100); 

    SELECT @e_material = Item_Name
    FROM material
    WHERE Price_TK = @price_tk;

    PRINT 'Item is: ' + @e_material;
END;
GO

EXEC material_pack.display_item_name @price_tk = 500;

---- 3. Create a schema that contains a procedure which can display the chefs id when price of item is passed. 

CREATE SCHEMA chef_pack;
GO

CREATE OR ALTER PROCEDURE chef_pack.display_c_id
    @price_tk INT 
AS
BEGIN
    DECLARE @c_id INT; 

    SELECT @c_id = c_id
    FROM material
    WHERE Price_TK = @price_tk;

    PRINT 'Belong to Chef ID: ' + CAST(@c_id AS NVARCHAR);
END;
GO

EXEC chef_pack.display_c_id @price_tk = 5000;