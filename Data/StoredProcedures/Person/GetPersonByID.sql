DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPersonByID` $$

CREATE PROCEDURE `GetPersonByID`(
	
	IN p_PersonID int
)

BEGIN

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
		
	where PersonEntityID = p_PersonID;
	
END$$

DELIMITER ;