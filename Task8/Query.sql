USE Northwind
/*
1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) 
включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при любых региональных настройках, 
согласно требованиям статьи “Writing International Transact-SQL Statements” в Books Online раздел 
“Accessing and Changing Relational Data Overview”. Этот метод использовать далее для всех заданий. 
Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia. 
Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. 
*/
SELECT OrderID, ShippedDate, ShipVia
FROM Northwind.Orders
WHERE ShippedDate >= CONVERT(DATETIME,'19980506',102) AND ShipVia >= 2
/*заказы с NULL в ShipDate не попали в результат, так как результат сравнения с NULL вернет 
значение NULL, а выборку попадают только записи, для которых выражение в WHERE равняется TRUE*/

/*
1.2	Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
 В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку 
 ‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен высвечивать только 
 колонки OrderID и ShippedDate.
*/
SELECT OrderID, ShippedDate = 
	CASE 
	WHEN ShippedDate IS NULL
	THEN 'Not Shipped'
	END 
FROM Northwind.Orders
WHERE ShippedDate IS NULL

/*
1.3	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) 
не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только 
колонки OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date).
 В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку 
 ‘Not Shipped’, для остальных значений высвечивать дату в формате по умолчанию.
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
2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. 
Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя и 
названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и 
по месту проживания.
*/

SELECT ContactName,Country
FROM Northwind.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country

/*
2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
Запрос сделать с помощью оператора IN. 
Высвечивать колонки с именем пользователя и названием страны в результатах запроса. 
Упорядочить результаты запроса по имени заказчиков.
*/
SELECT ContactName,Country
FROM Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName

/*
2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики.
 Страна должна быть упомянута только один раз и список отсортирован по убыванию. 
 Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса.
*/ 
SELECT DISTINCT Country
FROM Northwind.Customers
ORDER BY Country DESC

/*
3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), 
где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в 
таблице Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.
*/
SELECT DISTINCT OrderID
FROM Northwind.[Order Details]
WHERE Quantity BETWEEN 3 AND 10

/*
3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны 
начинается на буквы из диапазона b и g. Использовать оператор BETWEEN. 
Проверить, что в результаты запроса попадает Germany. 
Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
*/
SELECT CustomerID, Country
FROM Northwind.Customers
WHERE SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY Country
  --|--Sort(ORDER BY:([Northwind].[Northwind].[Customers].[Country] ASC)) 
         --|--Clustered Index Scan(OBJECT:([Northwind].[Northwind].[Customers].[PK_Customers]), WHERE:(substring([Northwind].[Northwind].[Customers].[Country],(1),(1))>=N'b' AND substring([Northwind].[Northwind].[Customers].[Country],(1),(1))<=N'g')) 

/*
3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на 
буквы из диапазона b и g, не используя оператор BETWEEN. 
С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3 
– для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов, 
результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам 
дать ответ на вопрос – по какому параметру было проведено сравнение. 
Запрос должен высвечивать только колонки CustomerID  и Country и отсортирован по Country.
 */
SELECT CustomerID, Country
FROM Northwind.Customers
WHERE SUBSTRING(Country,1,1) >= 'b' AND SUBSTRING(Country,1,1) <= 'g'
ORDER BY Country
--|--Sort(ORDER BY:([Northwind].[Northwind].[Customers].[Country] ASC))
       --|--Clustered Index Scan(OBJECT:([Northwind].[Northwind].[Customers].[PK_Customers]), WHERE:(substring([Northwind].[Northwind].[Customers].[Country],(1),(1))>=N'b' AND substring([Northwind].[Northwind].[Customers].[Country],(1),(1))<=N'g'))

/* Запросы 3.2 и 3.3 выполняются идентично. Предпочтительным считаю выполнение запроса
3.2 в силу большей краткости синтаксической конструкции */

/*
4.1	В таблице Products найти все продукты (колонка ProductName), 
где встречается подстрока 'chocolade'. Известно, что в подстроке 'chocolade' может быть 
изменена одна буква 'c' в середине - найти все продукты, которые удовлетворяют этому условию. 
Подсказка: результаты запроса должны высвечивать 2 строки.
*/
SELECT ProductName
FROM Northwind.Products
WHERE ProductName LIKE '%cho_olade%'

/*
5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества 
закупленных товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 
для типа данных money.  Скидка (колонка Discount) составляет процент из стоимости для данного товара. 
Для определения действительной цены на проданный продукт надо вычесть скидку из указанной 
в колонке UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием 
колонки 'Totals'.
*/
SELECT CONVERT(MONEY,ROUND(SUM((UnitPrice-UnitPrice*Discount)*Quantity),2),1) as 'Totals'
FROM Northwind.[Order Details]

/*
5.2	По таблице Orders найти количество заказов, которые еще не были доставлены 
(т.е. в колонке ShippedDate нет значения даты доставки). 
Использовать при этом запросе только оператор COUNT. Не использовать предложения WHERE и GROUP.
*/
SELECT COUNT(OrderID)-COUNT(ShippedDate)
FROM Northwind.Orders

/*
5.3	По таблице Orders найти количество различных покупателей (CustomerID), 
сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
*/
SELECT COUNT(*)
FROM (
		SELECT DISTINCT CustomerID
		FROM Northwind.Orders
	 ) as a

/*
6.1	По таблице Orders найти количество заказов с группировкой по годам. 
В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
Написать проверочный запрос, который вычисляет количество всех заказов.
*/
SELECT COUNT(OrderID) as Quantity, YEAR(OrderDate) as [Year]
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(OrderID) as Quantity
FROM Northwind.Orders

/*
6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом. 
Заказ для указанного продавца – это любая запись в таблице Orders, 
где в колонке EmployeeID задано значение для данного продавца. 
В результатах запроса надо высвечивать колонку с именем продавца 
(Должно высвечиваться имя полученное конкатенацией LastName & FirstName. 
Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. 
Также основной запрос должен использовать группировку по EmployeeID.) 
с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'. 
Результаты запроса должны быть упорядочены по убыванию количества заказов. 
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
6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя.
Необходимо определить это только для заказов сделанных в 1998 году. 
В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), 
колонку с именем покупателя (название колонки ‘Customer’)  и колонку c количеством заказов 
высвечивать с названием 'Amount'. В запросе необходимо использовать специальный оператор языка T-SQL
для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса).
Группировки должны быть сделаны по ID продавца и покупателя. 
Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж.
В результатах должна быть сводная информация по продажам. Т.е. в резульирующем наборе должны 
присутствовать дополнительно к информации о продажах продавца для каждого покупателя следующие строчки:
Seller		Customer	Amount
ALL 		ALL			<общее число продаж>
<имя>		ALL			<число продаж для данного продавца>
ALL			<имя>		<число продаж для данного покупателя>
<имя>		<имя>		<число продаж данного продавца для даннного покупателя>
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
6.4	Найти покупателей и продавцов, которые живут в одном городе. 
Если в городе живут только один или несколько продавцов или только один 
или несколько покупателей, то информация о таких покупателя и продавцах не должна 
попадать в результирующий набор. Не использовать конструкцию JOIN. 
В результатах запроса необходимо вывести следующие заголовки для результатов запроса:
 ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости от типа записи),
  ‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
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
6.5	Найти всех покупателей, которые живут в одном городе. 
В запросе использовать соединение таблицы Customers c собой - самосоединение. 
Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи. 
Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза 
в таблице Customers. Это позволит проверить правильность запроса.
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
6.6	По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. 
Высветить колонки с именами 'User Name' (LastName) и 'Boss'. 
В колонках должны быть высвечены имена из колонки LastName. 
Высвечены ли все продавцы в этом запросе?
*/
SELECT emp1.LastName AS [User name], emp2.LastName AS Boss
FROM Northwind.Employees AS emp1 JOIN Northwind.Employees AS emp2
ON emp1.ReportsTo = emp2.EmployeeID

/*
7.1	Определить продавцов, которые обслуживают регион 'Western' (таблица Region). 
Результаты запроса должны высвечивать два поля: 'LastName' продавца и 
название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). 
Запрос должен использовать JOIN в предложении FROM. Для определения связей между 
таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind.
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
8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и 
суммарное количество их заказов из таблицы Orders. Принять во внимание, 
что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. 
Упорядочить результаты запроса по возрастанию количества заказов.
*/
SELECT cust.ContactName, COUNT(ord.OrderID) AS Amount
FROM Northwind.Customers AS cust
	LEFT JOIN Northwind.Orders AS ord
	ON cust.CustomerID = ord.CustomerID
GROUP BY cust.CustomerID, cust.ContactName
ORDER BY Amount

/*
9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers,
 у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0). 
 Использовать вложенный SELECT для этого запроса с использованием оператора IN. 
 Можно ли использовать вместо оператора IN оператор '=' ?
 */
SELECT CompanyName
FROM Northwind.Suppliers
WHERE SupplierID 
	IN(SELECT SupplierID
	FROM Northwind.Products
	WHERE UnitsInStock = 0)
/*
оператор '=' использовать нельзя, т.к в запросе происходит проверка вхождения элемента в множество, 
а не сравнение с конкретным значением
*/

/*
10.1 Высветить всех продавцов, которые имеют более 150 заказов. 
Использовать вложенный коррелированный SELECT.
*/
SELECT emp.EmployeeID
FROM Northwind.Employees AS emp
WHERE (SELECT COUNT(*) 
		FROM Northwind.Orders AS ord 
		WHERE ord.EmployeeID = emp.EmployeeID 
		GROUP BY ord.EmployeeID) > 150

/*
11.1 Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
(подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.
*/
SELECT cust.CustomerID
FROM Northwind.Customers AS cust
WHERE NOT EXISTS (SELECT * 
				  FROM Northwind.Orders AS ord 
				  WHERE ord.CustomerID = cust.CustomerID)

/*
12.1 Для формирования алфавитного указателя Employees высветить из таблицы Employees 
список только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) 
из этой таблицы. Алфавитный список должен быть отсортирован по возрастанию.
*/
SELECT DISTINCT SUBSTRING(LastName,1,1) AS [character]
FROM Northwind.Employees 
ORDER BY [character]

/*
13.1 Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов 
за определенный год. В результатах не может быть несколько заказов одного продавца, должен 
быть только один и самый крупный. В результатах запроса должны быть выведены следующие колонки: 
колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), 
номер заказа и его стоимость. В запросе надо учитывать Discount при продаже товаров. 
Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей. 
Результаты запроса должны быть упорядочены по убыванию суммы заказа. 
*/
DECLARE @const_year int = 1998
DECLARE @const_num int = 5

exec Northwind.GreatestOrders @year = @const_year, @number = @const_num

/*
13.2 Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в днях 
(разница между OrderDate и ShippedDate).  В результатах должны быть возвращены заказы, срок которых превышает 
переданное значение или еще недоставленные заказы. Значению по умолчанию для передаваемого срока 35 дней.
 Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки: OrderID, OrderDate, ShippedDate, 
 ShippedDelay (разность в днях между ShippedDate и OrderDate), SpecifiedDelay (переданное в процедуру значение).
 */
 exec Northwind.ShippedOrdersDiff

 /*
 13.3 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, 
 так и подчиненных его подчиненных. В качестве входного параметра функции используется EmployeeID. 
 Необходимо распечатать имена подчиненных и выровнять их в тексте (использовать оператор PRINT) 
 согласно иерархии подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен. 
 Название процедуры SubordinationInfo.
 */
exec Northwind.SubordinationInfo @seller = 2

/*
13.4 Написать функцию, которая определяет, есть ли у продавца подчиненные. 
Возвращает тип данных BIT. В качестве входного параметра функции используется EmployeeID. 
Название функции IsBoss. Продемонстрировать использование функции для всех продавцов из таблицы Employees.
*/
SELECT EmployeeID, Northwind.IsBoss (EmployeeID) AS IsBoss
FROM Northwind.Employees
ORDER BY EmployeeID