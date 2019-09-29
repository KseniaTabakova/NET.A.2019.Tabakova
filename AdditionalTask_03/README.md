# Задания:
- Выясните кардинальность для связей между таблицами PK Table (таблица, которая содержит первичный ключ сущности) и FK Table (таблица, содержащая внешний ключ сущности). Заполните колонки Cardinality в таблице.

| PK Table      | Cardinality PK Table | FK Table	Cardinality | FK Table      | Relationship |
| ------------- | -------------------- | -------------------- | ------------- | ------------ |
| shippers    	 |   Zero-or-One        |orders    	           | One-or-Many   | One-to-Many  | 
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
				



		
