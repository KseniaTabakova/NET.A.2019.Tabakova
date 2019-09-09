-- A query displays a list of customers in a table consisting of two columns, 
-- customerID and companyName. Table rows must be sorted by customer code.

CREATE database customers;

use customers;

CREATE TABLE information (
    customerID INT,
    companyName VARCHAR(20));

INSERT INTO information (customerID, companyName)
    VALUES (1, 'MAC'), (12, 'EPAM'), (8, 'ZARA');

SELECT * FROM information
    ORDER BY customerID;
