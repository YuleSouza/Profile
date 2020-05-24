DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetEducationByID` $$

CREATE PROCEDURE `GetEducationByID`(
	
	IN p_EducationID int
)
BEGIN 

	select 
			EducationEntityID, 
			StartDate, 
			EndDate, 
			EducationTitle, 
			InstitutionName, 
			CourseDescription, 
			ModifiedDate 
			
	from Education 
	where EducationEntityID = p_EducationID
	order by ModifiedDate desc;

END$$

DELIMITER ;