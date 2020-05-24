DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPersonSecurity` $$

CREATE PROCEDURE `GetPersonSecurity`(
	
	IN p_UserName nvarchar(120),
	IN p_PasswordHash nvarchar(255)
)

BEGIN

	select 
		ps.PersonSecurityEntityID,
		ps.PersonEntityID, 
		ps.UserName,
		ps.Password,
		ps.PasswordHash,
		ps.CreatedDate,
		ps.ModifiedDate	
		
	from PersonSecurity ps
	join Person p on ps.PersonEntityID = p.PersonEntityID
		
	where ps.UserName = p_UserName and ps.PasswordHash = p_PasswordHash;
	
END$$

DELIMITER ;