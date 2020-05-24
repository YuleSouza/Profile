DELIMITER $$

DROP PROCEDURE IF EXISTS `profile`.`GetContact` $$

CREATE PROCEDURE `GetContact`()

select 
		ContactEntityID, 
		Email, 
		Name, 
		Message, 
		DateContact
		
from Comment order by DateContact desc $$

DELIMITER ;