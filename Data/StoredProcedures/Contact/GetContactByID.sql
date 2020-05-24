DELIMITER $$

DROP PROCEDURE IF EXISTS `profile`.`GetContactByID` $$

CREATE PROCEDURE `GetContactByID`(
	
	IN p_ContactID int
)
BEGIN 

	select 
			ContactEntityID, 
			Email,
			Name, 
			Message,
			DataContact
			
	from Comment 
	where ContactEntityID = p_ContactID
	order by DataContact desc;

END$$

DELIMITER ;