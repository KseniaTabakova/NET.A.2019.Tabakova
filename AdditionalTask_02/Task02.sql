-- A query displays employeeID of the last employee hired by the company.

-- I am using the previous DB(customers)

CREATE TABLE employees (
    employeeID INT,
    hireDate DATE);

INSERT INTO employees (employeeID, hireDate)
    VALUES (12, '2019-05-10'), (7, '2016-07-30'), (89, '2019-08-30');

SELECT * FROM employees
    WHERE hireDate = (SELECT MAX(hireDate) FROM employees);
