-- A query displays employeeID of the last employee hired by the company.

-- I am using the previous DB(customers)

CREATE TABLE employees (
    employeeID INT,
    employmentData DATE);

INSERT INTO employees (employeeID, employmentData) 
    VALUES (1, '2019-05-23'), (2, '2013-09-04'), (3, '2019-05-25'), (4, '1998-12-12'), (5, '2003-10-19'), (6, '2019-07-30');

SELECT * FROM employees
    WHERE employmentData = (SELECT MAX(employmentData) FROM employees);
