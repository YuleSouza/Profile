DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPricing` $$

CREATE PROCEDURE `GetPricing`()

select 
		 PricingEntityID, 
		 Price, 
		 PricingType, 
		 Period, 
		 ModifiedDate 
		 
from Pricing $$

DELIMITER ;