-- Create a query that lists all countries from the dbo.Customers.Country column. 
-- The list should be sorted in alphabetical order and should contain only unique values.

CREATE TABLE address(
    custID INT,
    country VARCHAR(20),
    city VARCHAR(20));

INSERT INTO address(custID, country, city)
    VALUES (1, 'Spain', 'Madrid'), (5, 'Sweden', 'Skokholm'), (3, 'France', 'Paris'), (9, 'USA','Chikago'), (2, 'Japan', 'Tokyo'), (16, 'Japan', 'Tokyo');

SELECT DISTINCT country FROM address
    ORDER BY country;
