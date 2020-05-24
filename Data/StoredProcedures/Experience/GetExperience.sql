DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetExperience` $$

CREATE PROCEDURE `GetExperience`()

select 
		 ExperienceEntityID, 
		 StartDate, 
		 EndDate, 
		 ExperienceTitle, 
		 InstitutionName, 
		 ExperienceDescription, 
		 ModifiedDate 
		 
from Experience order by ModifiedDate desc $$

DELIMITER ;