-- Request displays the average freight cost of orders for customer companies that indicated the place of delivery of the order 
-- a city belonging to the UK or Canada. An additional selection criterion is the value of the average cost of the order — greater than 
-- or equal to 100, or less than 10. The resulting table should have columns CustomerID and FreightAvg, the average cost should be 
-- rounded to the nearest integer, the rows should be sorted in reverse order by the average freight .

SELECT custId, AVG(prodA+prodB+prodC) AS totalFreight
     FROM totalOrders
     WHERE custID IN( SELECT custID FROM productA WHERE deliveryCity IN ('London', 'Toronto'))
     HAVING (totalFreight) >= 100 OR (totalFreight) < 10
     ORDER BY ROUND(AVG(totalFreight),0) DESC;
