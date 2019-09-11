-- Query displays 3 orders with the highest value that were created after September 1, 1997 inclusive and were delivered to South America. 
-- The total cost is calculated as the sum of the cost of the details of the order, taking into account the discount. 
-- The resulting table should have columns CustomerID, ShipCountry and OrderPrice, rows should be sorted by order value in reverse.

SELECT customerID, shipCountry, (SELECT ROUND(SUM(unitPrice * quantity * (1 - discount)), 2) FROM totalOrders
     GROUP BY orderID FROM totalOrders
     WHERE shipCountry IN ('Brazil', 'Chile', 'Colombia', 'Equador', 'Argentina', 'Bolivia', 'Paraguay', 'Peru', 'Suriname', 'Uruguay', 'Venezuela')
     AND orderData >= '1997-09-01'
     ORDER BY orderID DESC
     LIMIT 3;
