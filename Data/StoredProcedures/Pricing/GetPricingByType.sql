DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPricingByType` $$

CREATE PROCEDURE `GetPricingByType`(
	
	IN p_PricingType nvarchar(2)
)

BEGIN

	select 
		PricingEntityID, 
		Price, 
		PricingType, 
		Period, 
		ModifiedDate 
	from Pricing 
	where PricingType = p_PricingType;
	
END$$

DELIMITER ;