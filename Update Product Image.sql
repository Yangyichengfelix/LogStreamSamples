INSERT INTO mac2s.Product (Name, MoldId , ImageId) Value ("New Product", null, null);
UPDATE mac2s.Product 
SET ImageId =(SELECT Id FROM Image ORDER BY Id DESC LIMIT 1)
WHERE Name ="New Product";