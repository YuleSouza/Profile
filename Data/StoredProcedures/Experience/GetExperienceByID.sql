DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetExperienceByID` $$

CREATE PROCEDURE `GetExperienceByID`(
	
	IN p_ExperienceID int
)
BEGIN 

	select 
			ExperienceEntityID, 
			StartDate, 
			EndDate, 
			ExperienceTitle, 
			InstitutionName, 
			ExperienceDescription, 
			ModifiedDate 
			
	from Experience
	where ExperienceEntityID = p_ExperienceID
	order by ModifiedDate desc;

END$$

DELIMITER ;