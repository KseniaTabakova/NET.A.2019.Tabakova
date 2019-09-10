-- Request displays total freight amount of orders for customer companies whose freight cost is greater than or the average cost of 
-- all orders, as well as the date of shipment of the order should be in the second half of July 1996. 
The resulting table should have columns CustomerID and FreightSum, the rows of which should be sorted by the sum of the freight orders.


ALTER TABLE productA ADD unloadDate DATE;

INSERT INTO productA(unloadDate)
VALUES ('1996-07-17'), ('1996-09-10'), ('2001-04-18'), ('2005-07-21'), ('1996-08-30'), ('2013-10-23');

SELECT custID, SUM(prodA) AS aSum FROM totalOrders
     WHERE prodA >= (SELECT AVG(prodA+prodB+prodC) FROM totalOrders WHERE custID IN (SELECT custID FROM productA WHERE unloadDate BETWEEN '1996-07-16' AND '1996-07-31'))
     GROUP BY custID
     ORDER BY aSum;
