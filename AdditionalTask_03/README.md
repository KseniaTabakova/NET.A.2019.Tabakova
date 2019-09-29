# Задания:
- Выясните кардинальность для связей между таблицами PK Table (таблица, которая содержит первичный ключ сущности) и FK Table (таблица, содержащая внешний ключ сущности). Заполните колонки Cardinality в таблице.

| PK Table      | Cardinality PK Table | FK Tabl  Cardinality | FK Table      | Relationship |
| ------------- | -------------------- | -------------------- | ------------- | ------------ |
| shippers    	|   Zero-or-One        |orders    	      | One-or-Many   | One-to-Many  | 
| employees     |   Zero-or-One        |orders                | One-or-Many   | One-to-Many  | 
| employees     |   Zero-or-One        |employees             | One-or-Many   | One-to-Many  | 
| employees     |   -                  |territories           | -             | Many-to-Many | 
| customers     |   Zero-or-One        |orders                | One-or-Many   | One-to-Many  |  
| customers     |   -                  |customerdemographics  | -             | Many-to-Many | 
| orders        |   One-and-only-One   |orderdetails          | One-or-Many   | One-to-Many  | 
| products      |   One-and-only-One   |orderdetails          | One-or-Many   | One-to-Many  |  
| suppliers     |   Zero-or-One        |products              | One-or-Many   | One-to-Many  | 
| categories    |   Zero-or-One        |products              | One-or-Many   | One-to-Many  | 
| region        |   One-and-only-One   |territories           | One-or-Many   | One-to-Many  | 
				
- Создайте в Postman новую коллекцию с именем Northwind, в этой коллекции создайте такие запросы к Northwind OData Service, которые будут удовлетворять описанию из таблицы ниже. После проверки запроса, занесите необходимые параметры в таблицу.

| Query Description             | HTTP Verb   | Url                  | 
| ----------------------------- | ----------- | -------------------- | 
| Get service metadata.         |   GET       | /$metadata           | 
| Get all customers.            |   GET       | /Customers           | 
| Get a customer with "ALFKI" id.|   GET      | /Customers('ALFKI')  |
| Get all orders.                |   GET      | /Orders              | 
| Get an order with "10248" id. |   GET       | /Orders('10248')     |
| Get all orders for a customer with "ANATR" id. |   GET       | /Customers('ANATR')/Orders   | 
| Get a customer for an order with "10248" id.   |   GET      | /Orders(10248)/Customer     |
|Get orders with freight >900.000 |GET |/Orders?$filter = Freight gt 900.000|
|Get orders where ShipCountry is France and ShippedDate is 1998 |  GET| /Orders?$filter = ShipCountry eq 'France' and (year(ShippedDate) eq 1998)|
|Get products with the price between 30.000 and 50.000 |  GET | /Products?$filter = UnitPrice lt 50.000 and UnitPrice gt 30.000|
|Get product name where its quantity more than 5| GET | Products?$select=ProductName&filter=Order_Details?filter =Order/Quantity gh 5|
|Get orders from United Package company| GET |/Orders?$expand= Shipper&$filter = Shipper/CompanyName eq 'United Package'|

- Найдите базовый класс, от которого унаследован NorthwindModel.NorthwindEntities. *System.Data.Services.Client.DataServiceContext*
В какой сборке находится базовый класс? *Microsoft.Data.Services.Client* 
По какому пути лежит эта сборка? *C:\Program Files (x86)\Microsoft WCF Data Services\5.6.3\bin\.NETFramework\Microsoft.Data.Services.Client.dll*
Какая версия у сборки, в которой находится базовый класс? *5.6.3.0*




		
