-- Request displays a list of names of customer companies located in the following cities: Berlin, London, Madrid, Brussels, Paris. 
-- The list should be sorted by company identifier in reverse alphabetical order.

ALTER TABLE information ADD city VARCHAR(30);
ALTER TABLE information ADD companyName VARCHAR(20);

INSERT INTO information (customerID,companyName, city)
    VALUES (13,'Mac','Minsk'), (42,'Bayer', 'Berlin'), (73,'BigBan','London'), (92,'Scklo','Grodno'), (300,'HP', 'Paris'), (50,'EY','Paris');

SELECT companyName FROM information
    WHERE city IN ('Berlin', 'London', 'Madrid', 'Bruxelles', 'Paris')
    ORDER BY customerID DESC;
