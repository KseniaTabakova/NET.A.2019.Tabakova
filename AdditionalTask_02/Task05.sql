-- Request displays a list of identifiers of the companies for which orders were delivered (dbo.Orders.RequiredDate) in September 1996. 
-- The list should be sorted in alphabetical order.

CREATE TABLE orders(
    requiredData DATE
    custID INT);

ALTER TABLE orders ADD FOREIGN KEY (custID) references information(customerID);


INSERT INTO orders(custID,requiredData)
    VALUES (13,'2010-09-02'), (42,'1996-09-22'), (73,'1996-12-17'), (92,'1996-09-17'), (300,'2015-03-01'), (50,'2000-11-14');

SELECT customerID FROM information
    WHERE customerID IN (SELECT custID FROM orders WHERE MONTH (requiredData) = 09)
    ORDER BY customerID;
