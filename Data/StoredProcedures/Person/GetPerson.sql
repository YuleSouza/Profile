DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPerson` $$

CREATE PROCEDURE `GetPerson`()

select 
		PersonEntityID, 
		Name, 
		Email, 
		About, 
		JobTitle, 
		DateBirth, 
		Phone, 
		Age, 
		Freelance, 
		Residence, 
		ImageProfile, 
		ImageProfileBackground, 
		Address, 
		ModifiedDate 

		from Person $$

DELIMITER ;