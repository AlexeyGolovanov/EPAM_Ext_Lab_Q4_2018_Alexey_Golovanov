--13.1
IF OBJECT_ID('Northwind.GreatestOrders') IS NOT NULL
	DROP PROCEDURE Northwind.GreatestOrders
GO

CREATE PROCEDURE Northwind.GreatestOrders
	@year INT,
	@number INT
AS
BEGIN
	SELECT TOP(@number) LastName + ' ' + FirstName AS Customer, OrderID, Max AS Price
	FROM Northwind.Employees AS emp
		JOIN (SELECT s.EmployeeID, o.OrderID, Max
			  FROM (SELECT EmployeeID, MAX(pr) AS [Max]
					FROM (SELECT ord.EmployeeID, ord.OrderID, SUM(UnitPrice*(1 - Discount)*Quantity) AS pr
						  FROM Northwind.Orders AS ord 
						  JOIN Northwind.[Order Details] AS d
						  ON ord.OrderID = d.OrderID
						  WHERE DATEPART(year, ord.OrderDate) = @year
						  GROUP BY ord.OrderID, EmployeeID) AS s
				    GROUP BY EmployeeID) AS s
			  JOIN (SELECT ord.EmployeeID, ord.OrderID, SUM(UnitPrice*(1 - Discount)*Quantity) AS pr
					FROM Northwind.Orders AS ord 
						JOIN Northwind.[Order Details] AS d
						ON ord.OrderID = d.OrderID
					WHERE DATEPART(year, ord.OrderDate) = @year
					GROUP BY ord.OrderID, EmployeeID) AS o
			  ON pr = Max) AS o
		ON emp.EmployeeID = o.EmployeeID
	ORDER BY Price DESC
END
GO

--13.2
IF OBJECT_ID('Northwind.ShippedOrdersDiff') IS NOT NULL
	DROP PROCEDURE Northwind.ShippedOrdersDiff
GO

CREATE PROCEDURE Northwind.ShippedOrdersDiff
	@term INT = 35
AS
BEGIN
	SELECT OrderID, OrderDate, ShippedDate, DATEDIFF(day, OrderDate, ShippedDate) AS ShippedDelay, @term AS SpecifiedDelay
	FROM Northwind.Orders
	WHERE DATEDIFF(day, OrderDate, ShippedDate) > @term OR ShippedDate IS NULL
END
GO

--13.3
IF OBJECT_ID('Northwind.SubordinationInfo') IS NOT NULL
	DROP PROCEDURE Northwind.SubordinationInfo
GO
CREATE PROCEDURE Northwind.SubordinationInfo
	@seller INT
AS
BEGIN
	DECLARE @emp nvarchar(100)
	DECLARE @repto nvarchar(100)
	DECLARE @empID nvarchar(100)
	DECLARE @lvl nvarchar(100)
	DECLARE crs CURSOR FOR
	WITH tab
	AS(
		SELECT LastName + ' ' + FirstName AS [Name], ReportsTo AS repto, EmployeeID, 0 AS lvl
		FROM Northwind.Employees
		WHERE EmployeeID = @seller
	UNION ALL
		SELECT LastName + ' ' + FirstName AS [Name], tab.repto, emp.EmployeeID, lvl + 1
		FROM tab , Northwind.Employees AS emp
		WHERE emp.ReportsTo = tab.EmployeeID)
	SELECT * FROM tab;
	OPEN crs
	FETCH NEXT FROM crs INTO @emp, @repto, @empID, @lvl;
	WHILE @@FETCH_STATUS = 0
	BEGIN   
	PRINT REPLICATE('  ', @lvl) + @emp 
	FETCH NEXT FROM crs INTO @emp, @repto, @empID, @lvl;
	END
	CLOSE crs;
	DEALLOCATE crs;
END
GO

--13.4
IF OBJECT_ID('Northwind.IsBoss') IS NOT NULL
	DROP FUNCTION Northwind.IsBoss
GO

CREATE FUNCTION Northwind.IsBoss 
	(@EmpID INT)
RETURNS BIT
AS
BEGIN
	DECLARE @res INT
	SELECT @res =
	CASE
		WHEN COUNT(*) = 0 THEN 0
		ELSE 1
	END
	FROM Northwind.Employees
	WHERE ReportsTo = @EmpID
	RETURN @res
END
GO