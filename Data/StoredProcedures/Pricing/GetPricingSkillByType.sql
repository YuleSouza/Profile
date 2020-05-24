DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPricingSkillByType` $$

CREATE PROCEDURE `GetPricingByType`(
	
	IN p_PricingType nvarchar(2)
)

BEGIN

	select 
		P.PricingEntityID, 
		PS.PricingSkillEntityID, 
		P.Price, 
		PS.SkillDescription, 
		PS.PricingSkillEnabled, 
		P.Period, 
		PS.ModifiedDate 
	from Pricing P 
	join PricingSkill PS on P.PricingEntityID = PS.PricingEntityID 
	where P.PricingType = p_PricingType;
	
END$$

DELIMITER ;