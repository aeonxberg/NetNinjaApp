ALTER TABLE [dbo].[Equipment]
	ADD CONSTRAINT [fk_EquipmentNinja]
	FOREIGN KEY (NinjaName)
	REFERENCES [Ninja] (Name)
