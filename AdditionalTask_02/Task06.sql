-- Request displays the name of the contact person of the customer company, whose phone number starts with the code "171" 
-- and contains "77", as well as the fax number starts with the code "171" and ends with "50".

CREATE TABLE contactPerson(
    custID INT,
    name VARCHAR(20),
    phoneNumber INT(7),
    faxNumber INT(7));

INSERT INTO contactPerson(custID, name, phoneNumber, faxNumber)
    VALUES (1, 'Angelina', 1715677, 1710050), 
           (5, 'Kolya', 1607700, 8800771), 
           (3, 'Bob', 1710050, 5017150), 
           (9, 'Theresa', 1717777, 1719950), 
           (2, 'Donald', 9090901, 9090902), 
           (16, 'Edward', 7700010, 7700011);

SELECT name FROM contactPerson
      WHERE phoneNumber LIKE '(171)%' AND phoneNumber LIKE '%77%'
      AND  faxNumber LIKE '(171)%' AND faxNumber LIKE '%50';
