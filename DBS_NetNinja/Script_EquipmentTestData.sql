print '*-- inserting into table ninja --*'

MERGE INTO Equipment AS Target
USING (VALUES
('Full Leather Jacket'	,5	,300	,0	,25	,'no image url', 'Chest', 'MoMoney'),
('Snake Leather Boots'	,10	,100	,0	,3	,'no image url', 'Boots', 'LordAeon'),
('Black Denim Hosen'	,3	,55		,0	,5	,'no image url', 'Legs', 'MoMoney'),
('Promise of War'		,10	,400	,6	,20	,'no image url', 'Chest', NULL),
('Terror of the Dragons',2	,550	,0	,4	,'no image url', 'Shoulders', NULL),
('Manly Mankini'		,20	,25		,-3	,5	,'no image url', 'Legs', NULL),
('Flip flops'			,35	,10		,10	,15	,'no image url', 'Boots', NULL)
)
AS Source (Name, Agility, Price, Intelligence, Strength, ImageURL, Category, NinjaName)
ON target.Name = Source.Name
WHEN MATCHED THEN
UPDATE SET Name = Source.Name
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, Agility, Price, Intelligence, Strength, ImageURL, Category, NinjaName)
VALUES (Name, Agility, Price, Intelligence, Strength, ImageURL, Category, NinjaName)
WHEN NOT MATCHED BY SOURCE THEN DELETE;