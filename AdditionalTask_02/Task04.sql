-- Request displays a list of names of customer companies located in the following cities: Berlin, London, Madrid, Brussels, Paris. 
-- The list should be sorted by company identifier in reverse alphabetical order.

ALTER TABLE customers ADD PRIMARY KEY (customerID);
ALTER TABLE address ADD FOREIGN KEY (custID) references customers (customerID);

SELECT companyName FROM customers
    WHERE customerID IN (SELECT custID FROM address WHERE city IN ('Berlin', 'London', 'Madrid', 'Bruxelles', 'Paris'))
    ORDER BY customerID DESC;
