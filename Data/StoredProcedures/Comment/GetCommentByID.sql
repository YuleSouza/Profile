DELIMITER $$

DROP PROCEDURE IF EXISTS `profile`.`GetCommentByID` $$

CREATE PROCEDURE `GetCommentByID`(
	
	IN p_CommentID int
)
BEGIN 

	select 
			CommentEntityID, 
			Title,
			CommentDescription, 
			DateComment 
			
	from Comment 
	where CommentEntityID = p_CommentID
	order by DateComment desc;

END$$

DELIMITER ;