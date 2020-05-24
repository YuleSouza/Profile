DELIMITER $$

DROP PROCEDURE IF EXISTS `profile`.`GetComment` $$

CREATE PROCEDURE `GetComment`()

select 
		CommentEntityID, 
		Title,
		CommentDescription, 
		DateComment 
		
from Comment order by DateComment desc $$

DELIMITER ;