-- Create a query that lists all countries from the dbo.Customers.Country column. 
-- The list should be sorted in alphabetical order and should contain only unique values.

use customers;

DROP TABLE information;

CREATE TABLE information (
    customerID INT NOT NULL,
    country VARCHAR(20),
    PRIMARY KEY(customerID));

INSERT INTO information (customerID, country)
    VALUES (1, 'Belarus'), (2, 'Italy'), (32, 'USA'), (52, 'Belarus'), (3, 'Angola'), (99, 'USA');

SELECT DISTINCT country FROM information
    ORDER BY country;
