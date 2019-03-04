USE Northwind
/*
1.1	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) 
������������ � ������� ���������� � ShipVia >= 2. ������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, 
�������� ����������� ������ �Writing International Transact-SQL Statements� � Books Online ������ 
�Accessing and Changing Relational Data Overview�. ���� ����� ������������ ����� ��� ���� �������. 
������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia. 
�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate. 
*/
SELECT OrderID, ShippedDate, ShipVia
FROM Northwind.Orders
WHERE ShippedDate >= CONVERT(DATETIME,'19980506',102) AND ShipVia >= 2
/*������ � NULL � ShipDate �� ������ � ���������, ��� ��� ��������� ��������� � NULL ������ 
�������� NULL, � ������� �������� ������ ������, ��� ������� ��������� � WHERE ��������� TRUE*/

/*
1.2	�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
 � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ 
 �Not Shipped� � ������������ ��������� ������� CAS�. ������ ������ ����������� ������ 
 ������� OrderID � ShippedDate.
*/
SELECT OrderID, ShippedDate = 
	CASE 
	WHEN ShippedDate IS NULL
	THEN 'Not Shipped'
	END 
FROM Northwind.Orders
WHERE ShippedDate IS NULL

/*
1.3	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) 
�� ������� ��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������� ������ 
������� OrderID (������������� � Order Number) � ShippedDate (������������� � Shipped Date).
 � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ 
 �Not Shipped�, ��� ��������� �������� ����������� ���� � ������� �� ���������.
*/

SELECT OrderID as [Order Number], [Shipped Date] =
	CASE
	WHEN ShippedDate IS NULL
	THEN 'Not Shipped'
	ELSE CONVERT(VARCHAR,ShippedDate,121)
	END
FROM Northwind.Orders
WHERE ShippedDate > CONVERT(DATETIME,'19980506',102) OR (ShippedDate IS NULL)

/*
2.1	������� �� ������� Customers ���� ����������, ����������� � USA � Canada. 
������ ������� � ������ ������� ��������� IN. ����������� ������� � ������ ������������ � 
��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ���������� � 
�� ����� ����������.
*/

SELECT ContactName,Country
FROM Northwind.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country

/*
2.2	������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
������ ������� � ������� ��������� IN. 
����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
����������� ���������� ������� �� ����� ����������.
*/
SELECT ContactName,Country
FROM Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName

/*
2.3	������� �� ������� Customers ��� ������, � ������� ��������� ���������.
 ������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. 
 �� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������.
*/ 
SELECT DISTINCT Country
FROM Northwind.Customers
ORDER BY Country DESC

/*
3.1	������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), 
��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � 
������� Order Details. ������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.
*/
SELECT DISTINCT OrderID
FROM Northwind.[Order Details]
WHERE Quantity BETWEEN 3 AND 10

/*
3.2	������� ���� ���������� �� ������� Customers, � ������� �������� ������ 
���������� �� ����� �� ��������� b � g. ������������ �������� BETWEEN. 
���������, ��� � ���������� ������� �������� Germany. 
������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
*/
SELECT CustomerID, Country
FROM Northwind.Customers
WHERE SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY Country
  --|--Sort(ORDER BY:([Northwind].[Northwind].[Customers].[Country] ASC)) 
         --|--Clustered Index Scan(OBJECT:([Northwind].[Northwind].[Customers].[PK_Customers]), WHERE:(substring([Northwind].[Northwind].[Customers].[Country],(1),(1))>=N'b' AND substring([Northwind].[Northwind].[Customers].[Country],(1),(1))<=N'g')) 

/*
3.3	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� 
����� �� ��������� b � g, �� ��������� �������� BETWEEN. 
� ������� ����� �Execution Plan� ���������� ����� ������ ���������������� 3.2 ��� 3.3 
� ��� ����� ���� ������ � ������ ���������� ���������� Execution Plan-a ��� ���� ���� ��������, 
���������� ���������� Execution Plan ���� ������ � ������ � ���� ����������� � �� �� ����������� 
���� ����� �� ������ � �� ������ ��������� ���� ��������� ���������. 
������ ������ ����������� ������ ������� CustomerID  � Country � ������������ �� Country.
 */
SELECT CustomerID, Country
FROM Northwind.Customers
WHERE SUBSTRING(Country,1,1) >= 'b' AND SUBSTRING(Country,1,1) <= 'g'
ORDER BY Country
--|--Sort(ORDER BY:([Northwind].[Northwind].[Customers].[Country] ASC))
       --|--Clustered Index Scan(OBJECT:([Northwind].[Northwind].[Customers].[PK_Customers]), WHERE:(substring([Northwind].[Northwind].[Customers].[Country],(1),(1))>=N'b' AND substring([Northwind].[Northwind].[Customers].[Country],(1),(1))<=N'g'))

/* ������� 3.2 � 3.3 ����������� ���������. ���������������� ������ ���������� �������
3.2 � ���� ������� ��������� �������������� ����������� */

/*
4.1	� ������� Products ����� ��� �������� (������� ProductName), 
��� ����������� ��������� 'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� 
�������� ���� ����� 'c' � �������� - ����� ��� ��������, ������� ������������� ����� �������. 
���������: ���������� ������� ������ ����������� 2 ������.
*/
SELECT ProductName
FROM Northwind.Products
WHERE ProductName LIKE '%cho_olade%'

/*
5.1	����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� 
����������� ������� � ������ �� ���. ��������� ��������� �� ����� � ��������� � ����� 1 
��� ���� ������ money.  ������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. 
��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� 
� ������� UnitPrice ����. ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� 
������� 'Totals'.
*/
SELECT CONVERT(MONEY,ROUND(SUM((UnitPrice-UnitPrice*Discount)*Quantity),2),1) as 'Totals'
FROM Northwind.[Order Details]

/*
5.2	�� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� 
(�.�. � ������� ShippedDate ��� �������� ���� ��������). 
������������ ��� ���� ������� ������ �������� COUNT. �� ������������ ����������� WHERE � GROUP.
*/
SELECT COUNT(OrderID)-COUNT(ShippedDate)
FROM Northwind.Orders

/*
5.3	�� ������� Orders ����� ���������� ��������� ����������� (CustomerID), 
��������� ������. ������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.
*/
SELECT COUNT(*)
FROM (
		SELECT DISTINCT CustomerID
		FROM Northwind.Orders
	 ) as a

/*
6.1	�� ������� Orders ����� ���������� ������� � ������������ �� �����. 
� ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total. 
�������� ����������� ������, ������� ��������� ���������� ���� �������.
*/
SELECT COUNT(OrderID) as Quantity, YEAR(OrderDate) as [Year]
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(OrderID) as Quantity
FROM Northwind.Orders

/*
6.2	�� ������� Orders ����� ���������� �������, c�������� ������ ���������. 
����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, 
��� � ������� EmployeeID ������ �������� ��� ������� ��������. 
� ����������� ������� ���� ����������� ������� � ������ �������� 
(������ ������������� ��� ���������� ������������� LastName & FirstName. 
��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. 
����� �������� ������ ������ ������������ ����������� �� EmployeeID.) 
� ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ��������� 'Amount'. 
���������� ������� ������ ���� ����������� �� �������� ���������� �������. 
*/
SELECT EmployeeID as Seller, 
	(SELECT CONCAT(FirstName, LastName)
	 FROM Northwind.Employees as employees
	 WHERE employees.EmployeeID = orders.EmployeeID) 
	 as [LastName & FirstName],
	COUNT(OrderID) as Amount 
FROM Northwind.Orders as orders
GROUP BY EmployeeID
ORDER BY Amount DESC

/*
6.3	�� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������.
���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. 
� ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), 
������� � ������ ���������� (�������� ������� �Customer�)  � ������� c ����������� ������� 
����������� � ��������� 'Amount'. � ������� ���������� ������������ ����������� �������� ����� T-SQL
��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������).
����������� ������ ���� ������� �� ID �������� � ����������. 
���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ���������� ������.
� ����������� ������ ���� ������� ���������� �� ��������. �.�. � ������������� ������ ������ 
�������������� ������������� � ���������� � �������� �������� ��� ������� ���������� ��������� �������:
Seller		Customer	Amount
ALL 		ALL			<����� ����� ������>
<���>		ALL			<����� ������ ��� ������� ��������>
ALL			<���>		<����� ������ ��� ������� ����������>
<���>		<���>		<����� ������ ������� �������� ��� �������� ����������>
*/

SELECT ISNULL((SELECT CONCAT(FirstName, LastName) 
		FROM Northwind.Employees as emp 
		WHERE ord.EmployeeID = emp.EmployeeID), 'ALL') as Seller,
		ISNULL((SELECT ContactName 
		FROM Northwind.Customers as cust 
		WHERE ord.CustomerID = cust.CustomerID), 'ALL') as Customer, 
		COUNT(*) AS Amount
FROM Northwind.Orders as ord
WHERE DATEPART(year, OrderDate) = '1998'
GROUP BY cube (EmployeeID, CustomerID)
ORDER BY Seller, Customer, Amount DESC

/*
6.4	����� ����������� � ���������, ������� ����� � ����� ������. 
���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� 
��� ��������� �����������, �� ���������� � ����� ���������� � ��������� �� ������ 
�������� � �������������� �����. �� ������������ ����������� JOIN. 
� ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������:
 �Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ��������� �� ���� ������),
  �City�. ������������� ���������� ������� �� ������� �City� � �� �Person�.
  */
SELECT cust.ContactName AS Person, 'Customer' AS Type,cust.City AS City
FROM Northwind.Northwind.Customers AS cust
WHERE EXISTS (
              SELECT emp.City 
              FROM Northwind.Northwind.Employees AS emp
              WHERE emp.City=cust.City
              )
UNION ALL
SELECT emp.FirstName+' '+emp.LastName AS Person, 'Seller' AS Type,emp.City AS City
FROM Northwind.Northwind.Employees AS emp
WHERE EXISTS (
              SELECT cust.City 
              FROM Northwind.Northwind.Customers AS cust
              WHERE emp.City=cust.City
              )
ORDER BY City, Person

/*
6.5	����� ���� �����������, ������� ����� � ����� ������. 
� ������� ������������ ���������� ������� Customers c ����� - ��������������. 
��������� ������� CustomerID � City. ������ �� ������ ����������� ����������� ������. 
��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� 
� ������� Customers. ��� �������� ��������� ������������ �������.
*/
SELECT DISTINCT cust1.CustomerID, cust1.City
FROM Northwind.Customers AS cust1 JOIN Northwind.Customers AS cust2
ON cust1.City = cust2.City
GROUP BY cust1.City, cust1.CustomerID
HAVING COUNT(*) > 1

SELECT City, COUNT(*) AS Times
FROM Northwind.Customers
GROUP BY City
HAVING COUNT(*) > 1

/*
6.6	�� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. 
��������� ������� � ������� 'User Name' (LastName) � 'Boss'. 
� �������� ������ ���� ��������� ����� �� ������� LastName. 
��������� �� ��� �������� � ���� �������?
*/
SELECT emp1.LastName AS [User name], emp2.LastName AS Boss
FROM Northwind.Employees AS emp1 JOIN Northwind.Employees AS emp2
ON emp1.ReportsTo = emp2.EmployeeID

/*
7.1	���������� ���������, ������� ����������� ������ 'Western' (������� Region). 
���������� ������� ������ ����������� ��� ����: 'LastName' �������� � 
�������� ������������� ���������� ('TerritoryDescription' �� ������� Territories). 
������ ������ ������������ JOIN � ����������� FROM. ��� ����������� ������ ����� 
��������� Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind.
*/
SELECT emp.LastName, ter.TerritoryDescription
FROM Northwind.EmployeeTerritories AS empt 
	JOIN Northwind.Territories AS ter 
	ON empt.TerritoryID = ter.TerritoryID 
	JOIN Northwind.Region AS reg 
	ON ter.RegionID = reg.RegionID
	JOIN Northwind.Employees AS emp
	ON emp.EmployeeID = empt.EmployeeID
WHERE reg.RegionDescription = 'Western'

/*
8.1	��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � 
��������� ���������� �� ������� �� ������� Orders. ������� �� ��������, 
��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� �������. 
����������� ���������� ������� �� ����������� ���������� �������.
*/
SELECT cust.ContactName, COUNT(ord.OrderID) AS Amount
FROM Northwind.Customers AS cust
	LEFT JOIN Northwind.Orders AS ord
	ON cust.CustomerID = ord.CustomerID
GROUP BY cust.CustomerID, cust.ContactName
ORDER BY Amount

/*
9.1	��������� ���� ����������� ������� CompanyName � ������� Suppliers,
 � ������� ��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). 
 ������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN. 
 ����� �� ������������ ������ ��������� IN �������� '=' ?
 */
SELECT CompanyName
FROM Northwind.Suppliers
WHERE SupplierID 
	IN(SELECT SupplierID
	FROM Northwind.Products
	WHERE UnitsInStock = 0)
/*
�������� '=' ������������ ������, �.� � ������� ���������� �������� ��������� �������� � ���������, 
� �� ��������� � ���������� ���������
*/

/*
10.1 ��������� ���� ���������, ������� ����� ����� 150 �������. 
������������ ��������� ��������������� SELECT.
*/
SELECT emp.EmployeeID
FROM Northwind.Employees AS emp
WHERE (SELECT COUNT(*) 
		FROM Northwind.Orders AS ord 
		WHERE ord.EmployeeID = emp.EmployeeID 
		GROUP BY ord.EmployeeID) > 150

/*
11.1 ��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ 
(��������� �� ������� Orders). ������������ ��������������� SELECT � �������� EXISTS.
*/
SELECT cust.CustomerID
FROM Northwind.Customers AS cust
WHERE NOT EXISTS (SELECT * 
				  FROM Northwind.Orders AS ord 
				  WHERE ord.CustomerID = cust.CustomerID)

/*
12.1 ��� ������������ ����������� ��������� Employees ��������� �� ������� Employees 
������ ������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName ) 
�� ���� �������. ���������� ������ ������ ���� ������������ �� �����������.
*/
SELECT DISTINCT SUBSTRING(LastName,1,1) AS [character]
FROM Northwind.Employees 
ORDER BY [character]

/*
13.1 �������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� 
�� ������������ ���. � ����������� �� ����� ���� ��������� ������� ������ ��������, ������ 
���� ������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������: 
������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), 
����� ������ � ��� ���������. � ������� ���� ��������� Discount ��� ������� �������. 
��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. 
���������� ������� ������ ���� ����������� �� �������� ����� ������. 
*/
DECLARE @const_year int = 1998
DECLARE @const_num int = 5

exec Northwind.GreatestOrders @year = @const_year, @number = @const_num

/*
13.2 �������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ���� 
(������� ����� OrderDate � ShippedDate).  � ����������� ������ ���� ���������� ������, ���� ������� ��������� 
���������� �������� ��� ��� �������������� ������. �������� �� ��������� ��� ������������� ����� 35 ����.
 �������� ��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate, 
 ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).
 */
 exec Northwind.ShippedOrdersDiff

 /*
 13.3 �������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, 
 ��� � ����������� ��� �����������. � �������� �������� ��������� ������� ������������ EmployeeID. 
 ���������� ����������� ����� ����������� � ��������� �� � ������ (������������ �������� PRINT) 
 �������� �������� ����������. ��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������. 
 �������� ��������� SubordinationInfo.
 */
exec Northwind.SubordinationInfo @seller = 2

/*
13.4 �������� �������, ������� ����������, ���� �� � �������� �����������. 
���������� ��� ������ BIT. � �������� �������� ��������� ������� ������������ EmployeeID. 
�������� ������� IsBoss. ������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.
*/
SELECT EmployeeID, Northwind.IsBoss (EmployeeID) AS IsBoss
FROM Northwind.Employees
ORDER BY EmployeeID