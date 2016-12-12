print '*-- inserting into table ninja --*'

MERGE INTO Ninja AS Target
USING (VALUES
('MoMoney',5,25,20,9001,'no image url'),
('LordAeon',7,30,17,650,'no image url'),
('IronMan',10,20,25,900,'no image url'),
('Hitman',5,5,1,150,'no image url')
)
AS Source (Name, Agility, Intelligence, Strength, Gold, ImageURL)
ON target.Name = Source.Name
WHEN MATCHED THEN
UPDATE SET Name = Source.Name
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, Agility, Intelligence, Strength, Gold, ImageURL)
VALUES (Name, Agility, Intelligence, Strength, Gold, ImageURL)
WHEN NOT MATCHED BY SOURCE THEN DELETE;