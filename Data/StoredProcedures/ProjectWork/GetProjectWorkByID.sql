DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetProjectWorkByID` $$

CREATE PROCEDURE `GetProjectWorkByID`(
	
	IN p_ProjectWorkID nvarchar(2)
)

BEGIN

	select 
		ProjectWorkEntityID, 
		Title, 
		SubTitle, 
		ProjectDescription, 
		ImagePath, 
		ImageDescription, 
		ExternalUrl, 
		CreatedDate, 
		ModifiedDate 
		
	from ProjectWork 
	where ProjectWorkEntityID = p_ProjectWorkID;
	
END$$

DELIMITER ;