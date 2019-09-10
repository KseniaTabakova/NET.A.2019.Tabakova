-- A query displays a list of customers in a table consisting of two columns, 
-- customerID and companyName. Table rows must be sorted by customer code.

CREATE DATABASE CompanyInformation;
use CompanyInformation;

CREATE TABLE customers(
    customerID INT,
    companyName VARCHAR(20));

INSERT INTO customers(customerID, companyName)
    VALUES (1, 'Zara'), (5, 'H&M'), (3, 'LOreal'), (9, 'EPAM'), (2, 'Toyota'), (16, 'Yamaha');

SELECT * FROM customers
    ORDER BY customerID;
