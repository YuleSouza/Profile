DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetSkillByType` $$

CREATE PROCEDURE `GetSkillByType`(
	
	IN p_SkillType nvarchar(2)
)

BEGIN

	select 
		SkillEntityID, 
		SkillName, 
		SkillRating, 
		ModifiedDate 
	from Skills 
	where SkillType = p_SkillType;
	
END$$

DELIMITER ;