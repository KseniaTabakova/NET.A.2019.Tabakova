-- Request displays a list of identifiers of the companies for which orders were delivered in September 1996. 
-- The list should be sorted in alphabetical order.

CREATE TABLE productA(
    custID INT,
    deliveryDate DATE);

ALTER TABLE productA ADD FOREIGN KEY (custID) references customers (customerID);

INSERT INTO productA(custID, deliveryDate)
    VALUES (1, '1996-10-15'), (5, '1996-09-15'), (3, '2001-07-18'), (9, '2005-09-01'), (2, '1996-09-30'), (16, '2013-12-23');

SELECT customerID FROM customers
    WHERE customerID IN (SELECT custID FROM productA WHERE MONTH(deliveryDate)=09)
    ORDER BY customerID;
