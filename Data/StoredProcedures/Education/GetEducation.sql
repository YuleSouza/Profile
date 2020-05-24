DELIMITER $$

DROP PROCEDURE IF EXISTS `profile`.`GetEducation` $$

CREATE PROCEDURE `GetEducation`()

select 
		 EducationEntityID, 
		 StartDate, 
		 EndDate, 
		 EducationTitle, 
		 InstitutionName, 
		 CourseDescription, 
		 ModifiedDate 
		
from Education order by ModifiedDate desc $$

DELIMITER ;