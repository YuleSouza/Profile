-- Create Tables  =======================================================================================================================================================
delete from Person;
drop table if exists Person;
create table Person  
(
   PersonEntityID int not null AUTO_INCREMENT primary key,
   Name nvarchar(255) not null, 
   Email nvarchar(140) not null, 
   About nvarchar(500) not null,
   JobTitle nvarchar(100) not null,
   DateBirth date not null,
   Phone nvarchar(20) null,
   Age int not null,
   Freelance bit not null,
   Residence nvarchar(120) not null, 
   ImageProfile nvarchar(150) not null,
   ImageProfileBackground nvarchar(150) not null,
   Address nvarchar(120) not null,
   CreatedDate date not null, 
   ModifiedDate date not null
);


delete from PersonSecurity;
drop table if exists PersonSecurity;
create table PersonSecurity
(

	PersonSecurityEntityID int not null AUTO_INCREMENT primary key,
	PersonEntityID int not null,
	UserName nvarchar(120) not null, 
	Password nvarchar(255) not null,
	PasswordHash nvarchar(255) not null,
	CreatedDate date not null, 
	ModifiedDate date not null 
);

delete from Comment;
drop table if exists Comment;
create table Comment
(
	CommentEntityID int not null AUTO_INCREMENT primary key,
	Title nvarchar(100) not null, 
	CommentDescription nvarchar(255) not null, 
	DateComment date not null,
	CreatedDate date not null
);

delete from Contact;
drop table if exists Contact;
create table Contact 
(
	ContactEntityID int not null AUTO_INCREMENT primary key,
	Name nvarchar(200) not null, 
	Email nvarchar(255) not null, 
	Message nvarchar(300) not null,
	DateContact date not null,
	CreatedDate date not null,
	ModifiedDate date not null
);

delete from Education;
drop table if exists Education;
create table Education
(
   EducationEntityID int not null AUTO_INCREMENT primary key,
   StartDate date not null,
   EndDate date not null, 
   EducationTitle nvarchar(255) not null, 
   InstitutionName nvarchar(120) not null,
   CourseDescription nvarchar(255) not null,
   CreatedDate date not null, 
   ModifiedDate date not null
);

delete from ProjectWork;
drop table if exists ProjectWork;
create table ProjectWork
(
   ProjectWorkEntityID int not null AUTO_INCREMENT primary key,
   Title nvarchar(255) not null, 
   SubTitle nvarchar(255) null, 
   ProjectDescription nvarchar(500) null,
   ImagePath nvarchar(255) not null,
   ImageDescription nvarchar(255) null, 
   ExternalUrl nvarchar(200) not null,
   CreatedDate date not null,
   ModifiedDate date not null
);

delete from Experience;
drop table if exists Experience;
create table Experience
(
   ExperienceEntityID int not null AUTO_INCREMENT primary key,
   StartDate date not null,
   EndDate date not null, 
   ExperienceTitle nvarchar(255) not null, 
   InstitutionName nvarchar(120) not null,
   ExperienceDescription nvarchar(255) not null,
   CreatedDate date not null, 
   ModifiedDate date not null
);

delete from Skills;
drop table if exists Skills;
create table Skills
(
   SkillEntityID int not null AUTO_INCREMENT primary key,
   SkillName nvarchar(120) not null,
   SkillRating int not null, 
   SkillType nvarchar(2) not null,
   CreatedDate date not null, 
   ModifiedDate date not null
);

delete from Pricing;
drop table if exists Pricing;
create table Pricing 
(
	PricingEntityID int not null AUTO_INCREMENT primary key,
	Price int not null, 
	PricingType nvarchar(2) not null,
	Period nvarchar(50) not null,
	CreatedDate date not null, 
	ModifiedDate date not null
);

delete from PricingSkill;
drop table if exists PricingSkill;
create table PricingSkill
(
	PricingSkillEntityID int not null AUTO_INCREMENT primary key,
	PricingEntityID int not null, 
	SkillDescription nvarchar(120) not null,
	PricingSkillEnabled bit not null,
	CreatedDate date not null,
	ModifiedDate date not null
);
-- Create Tables  =============================================================================================================================================================



-- Get Comment Stored Procedure  =========================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetComment` $$

CREATE PROCEDURE `GetComment`()

select 
		CommentEntityID, 
		Title,
		CommentDescription, 
		DateComment 
		
from Comment order by DateComment desc $$

DELIMITER ;
-- Get Comment Stored Procedure  =============================================================================================================================================

-- Get Comment By ID Stored Procedure  =======================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetCommentByID` $$

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
-- Get Comment By ID Stored Procedure  =========================================================================================================================================


-- Get Contact Stored Procedure  ===============================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetContact` $$

CREATE PROCEDURE `GetContact`()

select 
		ContactEntityID, 
		Email, 
		Name, 
		Message, 
		DateContact
		
from Contact order by DateContact desc $$

DELIMITER ;
-- Get Contact Stored Procedure  ===============================================================================================================================================

-- Get Contact By ID Stored Procedure  =========================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetContactByID` $$

CREATE PROCEDURE `GetContactByID`(
	
	IN p_ContactID int
)
BEGIN 

	select 
			ContactEntityID, 
			Email,
			Name, 
			Message,
			DataContact
			
	from Contact 
	where ContactEntityID = p_ContactID
	order by DataContact desc;

END$$

DELIMITER ;
-- Get Contact By ID Stored Procedure  =========================================================================================================================================


-- Get Education Stored Procedure  =============================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetEducation` $$

CREATE PROCEDURE `GetEducation`()

select 
		 EducationEntityID, 
		 StartDate, 
		 EndDate, 
		 EducationTitle, 
		 InstitutionName, 
		 CourseDescription, 
		 ModifiedDate 
		
from Education order by ModifiedDate desc $$

DELIMITER ;
-- Get Education Stored Procedure  =============================================================================================================================================

-- Get Education By ID Stored Procedure  ==========================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetEducationByID` $$

CREATE PROCEDURE `GetEducationByID`(
	
	IN p_EducationID int
)
BEGIN 

	select 
			EducationEntityID, 
			StartDate, 
			EndDate, 
			EducationTitle, 
			InstitutionName, 
			CourseDescription, 
			ModifiedDate 
			
	from Education 
	where EducationEntityID = p_EducationID
	order by ModifiedDate desc;

END$$

DELIMITER ;
-- Get Education By ID Stored Procedure  =======================================================================================================================================


-- Get Experience Stored Procedure  ============================================================================================================================================
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
-- Get Experience Stored Procedure  ============================================================================================================================================

-- Get Experience BY ID Stored Procedure  ======================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetExperienceByID` $$

CREATE PROCEDURE `GetExperienceByID`(
	
	IN p_ExperienceID int
)
BEGIN 

	select 
			ExperienceEntityID, 
			StartDate, 
			EndDate, 
			ExperienceTitle, 
			InstitutionName, 
			ExperienceDescription, 
			ModifiedDate 
			
	from Experience
	where ExperienceEntityID = p_ExperienceID
	order by ModifiedDate desc;

END$$

DELIMITER ;
-- Get Experience BY ID Stored Procedure  ======================================================================================================================================


-- Get Person Stored Procedure  ===============================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPerson` $$

CREATE PROCEDURE `GetPerson`()

select 
		PersonEntityID, 
		Name, 
		Email, 
		About, 
		JobTitle, 
		DateBirth, 
		Phone, 
		Age, 
		Freelance, 
		Residence, 
		ImageProfile, 
		ImageProfileBackground, 
		Address, 
		ModifiedDate 

		from Person $$

DELIMITER ;
-- Get Person Stored Procedure  ===============================================================================================================================================

-- Get Person By ID Stored Procedure  =========================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPersonByID` $$

CREATE PROCEDURE `GetPersonByID`(
	
	IN p_PersonID int
)

BEGIN

	select 
		PersonEntityID, 
		Name, 
		Email, 
		About, 
		JobTitle, 
		DateBirth, 
		Phone, 
		Age, 
		Freelance, 
		Residence, 
		ImageProfile, 
		ImageProfileBackground, 
		Address, 
		ModifiedDate 
		
	from Person 
		
	where PersonEntityID = p_PersonID;
	
END$$

DELIMITER ;
-- Get Person By ID Stored Procedure  =========================================================================================================================================

-- Get Person Security By User and Password Stored Procedure  =================================================================================================================
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
-- Get Person Security By User and Password Stored Procedure  =================================================================================================================


-- Get Pricing Stored Procedure  =============================================================================================================================================
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
-- Get Pricing Stored Procedure  ================================================================================================================================================

-- Get Pricing Skill By Type Stored Procedure  ==================================================================================================================================
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
-- Get Pricing Skill By Type Stored Procedure  ===================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetPricingSkillByType` $$

CREATE PROCEDURE `GetPricingSkillByType`(
	
	IN p_PricingSkillType nvarchar(2)
)

BEGIN

	select 
		P.PricingEntityID, 
		PS.PricingSkillEntityID, 
		P.Price, 
		P.PricingType,
		PS.SkillDescription, 
		PS.PricingSkillEnabled, 
		P.Period, 
		PS.ModifiedDate 
	from Pricing P 
	join PricingSkill PS on P.PricingEntityID = PS.PricingEntityID 
	where P.PricingType = p_PricingSkillType;
	
END$$

DELIMITER ;
-- Get Pricing Skill By Type Stored Procedure  =================================================================================================================================


-- Get Project Work Stored Procedure  ==========================================================================================================================================
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
-- Get Project Work Stored Procedure  ========================================================================================================================================

-- Get Project Work By ID Stored Procedure  ==================================================================================================================================
DELIMITER $$

DROP PROCEDURE IF EXISTS `taptwel`.`GetProjectWorkByID` $$

CREATE PROCEDURE `GetProjectWorkByID`(
	
	IN p_ProjectWorkID nvarchar(2)
)

BEGIN

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
	where ProjectWorkEntityID = p_ProjectWorkID;
	
END$$

DELIMITER ;
-- Get Project Work By ID Stored Procedure  ==================================================================================================================================


-- Get Skill By Type Stored Procedure  ========================================================================================================================================
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
-- Get Skill By Type Stored Procedure  ========================================================================================================================================



--  Load Person ================================================================================================================================================================
insert into Person (Name, Email, About, JobTitle, DateBirth, Phone, Age, Freelance, Residence, ImageProfile, ImageProfileBackground, Address, CreatedDate, ModifiedDate) 
values ('Yule Souza', 'yule.souza@outlook.com', 'Template Card Profile', 'Web Developer', '1989-01-27', '+551197481-8734', 30, 1, 'Sao Paulo, Brazil', '/Theme/Card/images/ProfileUser.png', '/Theme/Card/images/bg.jpg', 'Rua Jaguaribe', now(), now());
--  Load Person ================================================================================================================================================================


--  Load Person Security =======================================================================================================================================================
insert into PersonSecurity(PersonEntityID, UserName, Password, PasswordHash, CreatedDate, ModifiedDate) values (1, 'CosmicCoder', 'P@$$w0rd', 'P@$$w0rd', now(), now());
--  Load Person Security =======================================================================================================================================================


-- Load Skills Coding  =========================================================================================================================================================
insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('HTML / CSS / BOOTSTRAP', 75, 'C', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('MYSQL / SQL SERVER / NOSQL', 67, 'C', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('JAVASCRIPT / JSON', 70, 'C', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('.NET FRAMEWORK / ASP .NET / C#', 70, 'C', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('REACT JS / WEB API', 72, 'C', now(), now());
-- Load Skills Coding  =========================================================================================================================================================


-- Load Skills Others  =========================================================================================================================================================
insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('NODE JS ', 70, 'O', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('POWERSHELL', 70, 'O', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('GIT / TFS', 78, 'O', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('AZURE', 65, 'O', now(), now());

insert into Skills (SkillName, SkillRating, SkillType, CreatedDate, ModifiedDate) values('PYTHON', 55, 'O', now(), now());
-- Load Skills Others  =========================================================================================================================================================


-- Load Experience =============================================================================================================================================================
insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2019-01-10', '2020-04-30', 'Web Developer Full Stack', 'Legal Control', 'Architected the git repository and developed product evolutions.', now(), now());

insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2014-01-06', '2018-01-06', 'Web Developer Full Stack', 'Keyrus Brasil - Telefonica B2B', 'Developed applications to provide intelligence to sales department.', now(), now());

insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2013-01-01', '2014-01-01', 'Backend Developer', 'Agility Solutions - Intermed', 'Developed web application integrated with ERP modules.', now(), now());

insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2012-02-03', '2013-01-19', 'Web Developer', 'Ecorp Ltda - Siemens', 'Collaborate with development of Intranet and other web application projects.', now(), now());

insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2010-01-29', '2011-12-31', 'Web Developer', 'Vannon Direct', 'Collaborate with development on ecommerce applications and web sites on demmand.', now(), now());

insert into Experience (StartDate, EndDate, ExperienceTitle, InstitutionName, ExperienceDescription, CreatedDate, ModifiedDate) 
values('2008-02-05', '2010-01-25', 'Technician Service Delivery', 'Amadeus IT Group', 'Monitored technical aspects of the service delivery software for several clients.', now(), now());
-- Load Experience =============================================================================================================================================================


-- Load Education  =============================================================================================================================================================
insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2011-03-03', '2011-03-28', 'ADO .NET 3.5', 'Bras Figueiredo', 'Key Features of application development with Microsoft ADO .NET 3.5', now(), now());

insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2011-04-04', '2011-04-25', 'Web Apps With Visual Studio', 'Bras Figueiredo', 'Developing web applications using Microsoft Visual Studio 2010', now(), now());

insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2011-05-05', '2011-05-19', '.NET Framework Foundations', 'Bras Figueiredo', 'Core foundations of Microsoft .NET Framework 3.5', now(), now());

insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2011-06-06', '2011-06-20', 'Programing with C# 3.5', 'Bras Figueiredo', 'Object-Oriented programing techniques in Microsoft .NET Framework', now(), now());

insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2011-06-23', '2011-07-07', 'System Development', 'Universidade Mogi das Cruzes', 'Bachelors degree in systems development, UMC Villa Lobos, Sao Paulo', now(), now());

insert into Education (StartDate, EndDate, EducationTitle, InstitutionName, CourseDescription, CreatedDate, ModifiedDate) values('2019-05-10', now(), 'MAC ONE | IELTS', 'Cultura Inglesa', 'MAC ONE | IELTS General Training e Academic', now(), now());
-- Load Education  =============================================================================================================================================================


-- Load Pricing Freelancer =====================================================================================================================================================
insert into Pricing(Price, PricingType, Period, CreatedDate, ModifiedDate) values (55, 'FL', 'Hour', now(), now());
-- Load Pricing Freelancer =====================================================================================================================================================


-- Load Pricing Full Time ======================================================================================================================================================
insert into Pricing(Price, PricingType, Period, CreatedDate, ModifiedDate) values (65, 'FT', 'Hour', now(), now());
-- Load Pricing Full Time ======================================================================================================================================================


-- Load Pricing Skill Description Freelancer ===================================================================================================================================
insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (1, 'Web Development', 1, now(), now());

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (1, 'Programming', 1, now(), now());

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (1, 'Database Development', 1, now(), now()); 

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (1, 'Azure Skills', 1, now(), now()); 
-- Load Pricing Skill Description Freelancer ===================================================================================================================================


-- Load Pricing Skill Description FullTime =====================================================================================================================================
insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (2, 'Web Development', 1, now(), now()); 

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (2, 'Programming', 1, now(), now()); 

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (2, 'Database Development', 1, now(), now()); 

insert into PricingSkill(PricingEntityID, SkillDescription, PricingSkillEnabled, CreatedDate, ModifiedDate) values (2, 'Azure Skills', 1, now(), now()); 
-- Load Pricing Skill Description FullTime ====================================================================================================================================


-- Load Projects Works ========================================================================================================================================================
insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Legal Control', 'Coding', 'Developed product evolutions and handled with git repository administrative tasks and planning', '/Theme/Card/uploads/projects/Legal.jpg', 'Legal Control', 'http://legalcontrol.com.br', now(), now());

insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Keyrus Brasil', 'Coding', 'Developed severeal applications.', '/Theme/Card/uploads/projects/Keyrus.jpg', 'Keyrus Brasil', 'http://keyrus.com.br', now(), now());

insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Telefonica Brasil', 'Coding', 'Developed applications to provide intelligence to sales department.', '/Theme/Card/uploads/projects/Telefonica.jpg', 'Telefonica Brasil | Vivo', 'http://telefonica.com.br', now(), now());

insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Amadeus I.T', 'Delivery', 'Delivered software to several clients.', '/Theme/Card/uploads/projects/Amadeus.jpg', 'Amadeus I.T Brasil', 'http://amadeus.com', now(), now());

insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Grupo GBI', 'Coding', 'Developed new currency and language to support Quito operation flights.', '/Theme/Card/uploads/projects/GBI.jpg', 'Grupo GBI', 'http://grupogbi.com/pt-br/', now(), now());

insert into ProjectWork (Title, SubTitle, ProjectDescription, ImagePath, ImageDescription, ExternalUrl, CreatedDate, ModifiedDate) 
values ('Vannon DirectT', 'Coding', 'Developed product evolutions to several e-commerce projects.', '/Theme/Card/uploads/projects/Vannon.png', 'Vannon Direct', 'http://vannon.com', now(), now());
-- Load Projects Works ========================================================================================================================================================

