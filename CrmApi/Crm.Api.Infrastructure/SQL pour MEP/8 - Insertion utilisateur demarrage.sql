BEGIN TRAN

	IF NOT EXISTS (SELECT * FROM [User] WHERE [mail] = 'depretfred@gmail.com')
	BEGIN
		INSERT INTO [dbo].[Address] ([Created],[Updated],[CityId],[Street],[ComplementStreet])
		SELECT GETDATE(),NULL,7140,'34 rue de lescure',NULL

		INSERT INTO [dbo].[User] ([Created],[Updated],[AddressId],[CivilityId],[LastName],[FirstName],[PhoneNumber],[MobilePhoneNumber],[Mail],[Password],[Actif],[Lock])
		SELECT GETDATE(),NULL,SCOPE_IDENTITY(),1,'DEPRET','Frédéric', '0556478383', '0682052023', 'depretfred@gmail.com', '834C5A4199AB2DF6D23054F585B9CE76',  1, 0
	END
COMMIT TRAN
