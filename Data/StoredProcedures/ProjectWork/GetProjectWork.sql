DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetProjectWork` $$

CREATE PROCEDURE `GetProjectWork`()

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
order by ModifiedDate desc $$

DELIMITER ;