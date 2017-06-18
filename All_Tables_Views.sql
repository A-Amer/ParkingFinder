-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema parkingfinder
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema parkingfinder
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `parkingfinder` DEFAULT CHARACTER SET utf8 ;
USE `parkingfinder` ;

-- -----------------------------------------------------
-- Table `parkingfinder`.`account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`account` (
  `Username` VARCHAR(15) NOT NULL,
  `Password` VARCHAR(15) NOT NULL,
  `Type` ENUM('client', 'manager', 'employee') NOT NULL,
  PRIMARY KEY (`Username`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`clients` (
  `Client_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `CName` VARCHAR(45) NOT NULL,
  `Telephone` INT(11) NULL DEFAULT NULL,
  `Username` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`Client_ID`),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC),
  CONSTRAINT `usr`
    FOREIGN KEY (`Username`)
    REFERENCES `parkingfinder`.`account` (`Username`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 31
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`location`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`location` (
  `Location_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `District` VARCHAR(45) NOT NULL,
  `Area` VARCHAR(45) NOT NULL,
  `City` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Location_ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`bookmarked`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`bookmarked` (
  `Client_ID` INT(11) NOT NULL,
  `Location_ID` INT(11) NOT NULL,
  PRIMARY KEY (`Client_ID`, `Location_ID`),
  INDEX `loc_book_idx` (`Location_ID` ASC),
  CONSTRAINT `client_book`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `loc_book`
    FOREIGN KEY (`Location_ID`)
    REFERENCES `parkingfinder`.`location` (`Location_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`client_credit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`client_credit` (
  `Client_ID` INT(11) NOT NULL,
  `Credit_Card_No` BIGINT(255) NULL DEFAULT NULL,
  PRIMARY KEY (`Client_ID`),
  UNIQUE INDEX `Credit_Card_No_UNIQUE` (`Credit_Card_No` ASC),
  CONSTRAINT `client_iddd`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`employee` (
  `Employee_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `EName` VARCHAR(45) NOT NULL,
  `SSN` BIGINT(20) NOT NULL,
  `Telephone` INT(11) NULL DEFAULT NULL,
  `Salary` INT(11) NOT NULL,
  `Username` VARCHAR(15) NOT NULL,
  `Spot_ID` INT(11) NOT NULL,
  `Arrival` DATETIME NULL DEFAULT NULL,
  `Departure` DATETIME NULL DEFAULT NULL,
  `Monthly_Worked_Hours` FLOAT NULL DEFAULT '0',
  PRIMARY KEY (`Employee_ID`),
  UNIQUE INDEX `SSN_UNIQUE` (`SSN` ASC),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC),
  INDEX `work_spot_idx` (`Spot_ID` ASC),
  CONSTRAINT `uname`
    FOREIGN KEY (`Username`)
    REFERENCES `parkingfinder`.`account` (`Username`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `work_spot`
    FOREIGN KEY (`Spot_ID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 39
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`parking_place`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`parking_place` (
  `Spot_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SName` VARCHAR(45) NOT NULL,
  `Pay_Rate` FLOAT NOT NULL,
  `Manager_ID` INT(11) NOT NULL,
  `Overtime_Rate` FLOAT NULL DEFAULT '1',
  `No_Floors` INT(11) NOT NULL DEFAULT '1',
  `No_Lanes` INT(11) NOT NULL DEFAULT '4',
  `No_Sections` INT(11) NOT NULL DEFAULT '4',
  `Location_ID` INT(11) NOT NULL,
  `Street` VARCHAR(35) NOT NULL,
  PRIMARY KEY (`Spot_ID`),
  UNIQUE INDEX `Manager ID_UNIQUE` (`Manager_ID` ASC),
  INDEX `loc_idx` (`Location_ID` ASC),
  CONSTRAINT `loc`
    FOREIGN KEY (`Location_ID`)
    REFERENCES `parkingfinder`.`location` (`Location_ID`)
    ON UPDATE NO ACTION,
  CONSTRAINT `mgr`
    FOREIGN KEY (`Manager_ID`)
    REFERENCES `parkingfinder`.`employee` (`Employee_ID`)
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 29
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`current_parking`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`current_parking` (
  `Plates_Number` INT(11) NOT NULL,
  `Expected_Dep` DATETIME NULL DEFAULT NULL,
  `Arrival_DateTime` DATETIME NULL DEFAULT NULL,
  `Floor` INT(11) NOT NULL,
  `Lane` INT(11) NOT NULL,
  `Section` ENUM('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N') NOT NULL,
  `Deposit` FLOAT NULL DEFAULT NULL,
  `Spot_ID` INT(11) NOT NULL,
  `Client_ID` INT(11) NOT NULL,
  PRIMARY KEY (`Plates_Number`),
  INDEX `client_park_idx` (`Client_ID` ASC),
  INDEX `spot_park_idx` (`Spot_ID` ASC),
  CONSTRAINT `client_park`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_park`
    FOREIGN KEY (`Spot_ID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`ratings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`ratings` (
  `CID` INT(11) NOT NULL,
  `SID` INT(11) NOT NULL,
  `Rating` TINYINT(5) NULL DEFAULT NULL,
  PRIMARY KEY (`CID`, `SID`),
  INDEX `spot_idx` (`SID` ASC),
  CONSTRAINT `cli`
    FOREIGN KEY (`CID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `spot`
    FOREIGN KEY (`SID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`refund`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`refund` (
  `Refund_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Date_Of_Cancel` DATE NULL DEFAULT NULL,
  `Cancel_Reason` VARCHAR(100) NULL DEFAULT NULL,
  `Amount_Refunded` FLOAT NOT NULL,
  `Client_ID` INT(11) NOT NULL,
  `Spot_ID` INT(11) NOT NULL,
  PRIMARY KEY (`Refund_ID`),
  INDEX `client_refund_idx` (`Client_ID` ASC),
  INDEX `spot_refund_idx` (`Spot_ID` ASC),
  CONSTRAINT `client_refund`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_refund`
    FOREIGN KEY (`Spot_ID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`reservation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`reservation` (
  `Reservation_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `ArrDT` DATETIME NULL DEFAULT NULL,
  `DepDT` DATETIME NULL DEFAULT NULL,
  `Deposit` FLOAT NOT NULL,
  `Floor` INT(11) NOT NULL,
  `Lane` INT(11) NOT NULL,
  `Section` ENUM('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N') NOT NULL,
  `Client_ID` INT(11) NOT NULL,
  `Spot_ID` INT(11) NOT NULL,
  PRIMARY KEY (`Reservation_ID`),
  INDEX `client_res_idx` (`Client_ID` ASC),
  INDEX `spot_res_idx` (`Spot_ID` ASC),
  CONSTRAINT `client_res`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_res`
    FOREIGN KEY (`Spot_ID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 37
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`reviews`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`reviews` (
  `CID` INT(11) NOT NULL,
  `SID` INT(11) NOT NULL,
  `_DateTime` DATETIME NOT NULL,
  `Review` VARCHAR(200) NULL DEFAULT NULL,
  `Reply` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`CID`, `SID`, `_DateTime`),
  INDEX `spot_rev_idx` (`SID` ASC),
  CONSTRAINT `client_rev`
    FOREIGN KEY (`CID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_rev`
    FOREIGN KEY (`SID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`saved_place`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`saved_place` (
  `Client_ID` INT(11) NOT NULL,
  `Spot_ID` INT(11) NOT NULL,
  PRIMARY KEY (`Client_ID`, `Spot_ID`),
  INDEX `spot_save_idx` (`Spot_ID` ASC),
  CONSTRAINT `client_save`
    FOREIGN KEY (`Client_ID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_save`
    FOREIGN KEY (`Spot_ID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `parkingfinder`.`transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `parkingfinder`.`transactions` (
  `Transaction_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Arrival_DateTime` DATETIME NULL DEFAULT NULL,
  `Dep_DateTime` DATETIME NULL DEFAULT NULL,
  `Amount_Paid` FLOAT NOT NULL,
  `Payment_Method` ENUM('Cash', 'Credit') NOT NULL,
  `CID` INT(11) NOT NULL,
  `SID` INT(11) NOT NULL,
  `Deposit` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`Transaction_ID`),
  INDEX `client_trans_idx` (`CID` ASC),
  INDEX `spot_trans_idx` (`SID` ASC),
  CONSTRAINT `client_trans`
    FOREIGN KEY (`CID`)
    REFERENCES `parkingfinder`.`clients` (`Client_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `spot_trans`
    FOREIGN KEY (`SID`)
    REFERENCES `parkingfinder`.`parking_place` (`Spot_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 31
DEFAULT CHARACTER SET = utf8;

USE `parkingfinder` ;

-- -----------------------------------------------------
-- procedure EmplInfo
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `EmplInfo`(IN ID INT)
BEGIN
 SELECT 
    P.SName,E.Ename,`AVG(rating)` 
FROM
    EMPLOYEE AS E,
    PARKING_PLACE AS P,
    avg_rating AS R
WHERE
        E.Employee_ID = ID
        AND P.Spot_ID = E.Spot_ID
        AND R.SID = E.Spot_ID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Garage_Details
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Garage_Details`(
IN S_ID INT(14)

)
BEGIN
SELECT 
    SNAME AS GARAGE_NAME,
    STREET AS STREET,
    AREA,
    DISTRICT,
    CITY,

    Pay_Rate,
    Overtime_Rate
FROM
    PARKING_PLACE,
    avg_rating AS AR,
    Location
WHERE
        Spot_ID = S_ID
        AND LOCATION.LOCATION_ID = PARKING_PLACE.LOCATION_ID;
        

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Inser_Client
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inser_Client`(
IN  C_N varchar(45),
IN  TEL  INT(11),
IN  U_N  varchar(15)

)
BEGIN
INSERT INTO Clients(CName,Telephone,Username)
Values (C_N,TEL,U_N);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure InsertParkingCar
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertParkingCar`(in arr datetime,
in dep datetime,
in pno int,
in floor int,
in lane int,
in section char,
in cid int,
in sid int,
in deposite float
)
BEGIN
INSERT INTO current_parking (Plates_Number,Expected_Dep,Arrival_DateTime,Floor,Lane,Section,Deposit,Spot_ID,Client_ID) 
VALUES (pno,dep,arr,floor,lane,section,deposite,sid,cid);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Insert_Account
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Account`(
IN username VARCHAR(15),
IN `password`      VARCHAR(15),
IN `Type`      enum('Client','Manager','Employee')
)
BEGIN
INSERT INTO ACCOUNT(`Username`,`Password`,`Type`)
Values(username,`password`,`Type`);

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Insert_Transaction
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Transaction`(in arr datetime,
in dep datetime,
in pay float,
in method varchar(15),
in cid int,
in sid int,
in deposite float
)
BEGIN
INSERT INTO transactions (Arrival_DateTime,Dep_DateTime,Amount_Paid,Payment_Method,CID,SID,Deposit) 
VALUES (arr,dep,pay,method,cid,sid,deposite);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Insert_employee
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_employee`(
in E_Name varchar(45), 
in E_SSN bigint(20),
in E_Tel int,
in E_Salary int,
in E_User_name varchar (15),
in E_Spot_ID int
)
BEGIN

insert into employee(EName,SSN,Telephone,Salary,Username,Spot_ID) 
values (E_Name,E_SSN, E_Tel,E_Salary,E_User_name, E_Spot_ID);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Insert_refund
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_refund`(
in canceldate datetime, 
in reason varchar(100),
in amount float,
in clientid int,
in spotid int
)
BEGIN

insert into refund(Date_Of_Cancel,Cancel_Reason,Amount_Refunded,Client_ID,Spot_ID) 
values (canceldate,reason,amount,clientid,spotid);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Is_Free
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Is_Free`(IN SptID INT,OUT Free INT)
BEGIN
   IF(SELECT COUNT(*) FROM current_parking WHERE Spot_ID=SptID) IN 
   (SELECT 
    No_Floors * No_Lanes * No_Sections
FROM
    parking_place
WHERE
    Spot_ID = SptID )
   THEN 
   SET Free= 0;
   ELSE
   SET Free= 1;
   END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Percent_occ
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Percent_occ`(IN SPTID INT)
BEGIN
 SELECT Round((100*COUNT(CP.Plates_Number)/(No_Floors * No_Lanes * No_Sections)),0) AS OCP 
FROM
    parking_place AS PP,current_parking AS CP
WHERE
    PP.Spot_ID = SPTID AND
    CP.Spot_ID = SPTID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Performance
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Performance`(IN EMPID INT)
BEGIN
SELECT 
    Monthly_Worked_Hours, `AVG(Monthly_Worked_Hours)`AS Average_Worked
FROM
    avg_worked AS aw,
    employee AS e
WHERE
        e.Employee_ID = EMPID
        AND aw.Spot_ID = e.Spot_ID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Save_Garage
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Save_Garage`(
in clientid int,
in spotid int
)
BEGIN

insert into saved_place(Client_ID,Spot_ID) 
values (clientid,spotid);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SelectClientFromReservation
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectClientFromReservation`(in spotid int)
BEGIN
SELECT CName,C.Client_ID 
FROM clients AS C,
reservation AS R 
WHERE C.Client_ID=R.Client_ID 
AND Spot_ID= spotid;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure SelectReservation
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectReservation`(in spotid int,in cid int)
BEGIN
SELECT Reservation_ID,CName,ArrDT,DepDT,Floor,Section,Lane,Deposit 
FROM clients as C,reservation as R 
WHERE Spot_ID=spotid
AND R.Client_ID= C.Client_ID 
AND R.Client_ID=cid;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Total_Res_3Month
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Total_Res_3Month`(IN M1 INT,IN M2 INT,IN M3 INT,IN SPTID INT,IN YEAR1 INT,IN YEAR2 INT,IN YEAR3 INT)
BEGIN
SELECT 
    *
FROM
    (SELECT 
        COUNT(*) AS TOTAL_MONTH1
    FROM
        TRANSACTIONS 
    WHERE
        YEAR(Arrival_DateTime)=YEAR1 AND MONTH(Arrival_DateTime)=M1 AND DEPOSIT<>0 AND SID=SPTID) AS TOTAL_MONTH1 ,
    (SELECT 
        COUNT(*) AS TOTAL_MONTH2
    FROM
        TRANSACTIONS
    WHERE
       YEAR(Arrival_DateTime)=YEAR2 AND MONTH(Arrival_DateTime)=M2 AND DEPOSIT<>0 AND SID=SPTID ) AS TOTAL_MONTH2,
    (SELECT 
        COUNT(*) AS TOTAL_MONTH3
    FROM
        TRANSACTIONS
    WHERE
        YEAR(Arrival_DateTime)=YEAR3 AND MONTH(Arrival_DateTime)=M3 AND DEPOSIT<>0 AND SID=SPTID) AS TOTAL_MONTH3;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Total_Res_Current_Month
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Total_Res_Current_Month`(IN SPTID INT,OUT TOT_RES INT)
BEGIN

 SET TOT_RES = (SELECT 
    COUNT(*)
FROM
    Reservation AS R
WHERE
    YEAR(R.ArrDT) = YEAR(CURRENT_DATE())
        AND MONTH(R.ArrDT) = MONTH(CURRENT_DATE())
        AND R.Spot_ID = SPTID)
  +(SELECT 
    COUNT(*)
FROM
    transactions AS T
WHERE
    YEAR(T.Arrival_DateTime) = YEAR(CURRENT_DATE())
        AND MONTH(T.Arrival_DateTime) = MONTH(CURRENT_DATE())
        AND T.Deposit <> 0
        AND T.SID = SPTID)
  +(SELECT 
    COUNT(*)
FROM
    Current_parking AS CP
WHERE
    YEAR(CP.Arrival_DateTime) = YEAR(CURRENT_DATE())
        AND MONTH(CP.Arrival_DateTime) = MONTH(CURRENT_DATE())
        AND CP.Deposit <> 0
        AND CP.Spot_ID = SPTID);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure View_Review
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `View_Review`(IN SPTID INT,IN rat INT)
BEGIN
SELECT 
    Review, Reply,_DateTime, Client_Name,Rating, Client_ID
FROM
    all_reviews as rv,Ratings as r
    where 
    rv.SID=SPTID and r.sid=SPTID and r.cid=Client_ID and Rating<=rat ;
    
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure get_description
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_description`(IN clientID int)
BEGIN
  SELECT Reservation_ID, concat(SName,': Floor ',Floor,' :Section ',Section,' :Lane ',Lane) as Description FROM reservation 
  INNER JOIN parking_place 
  ON reservation.Spot_ID = parking_place.Spot_ID
  WHERE Client_ID=clientID;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure get_garages
-- -----------------------------------------------------

DELIMITER $$
USE `parkingfinder`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_garages`()
BEGIN
  SELECT SName as sname,Spot_ID FROM parkingfinder.parking_place;
  
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `parkingfinder`.`all_current`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`all_current` AS select `cp`.`Expected_Dep` AS `Expected_Dep`,`cp`.`Arrival_DateTime` AS `Arrival`,`cp`.`Floor` AS `Floor`,`cp`.`Lane` AS `Lane`,`cp`.`Section` AS `Section`,`cp`.`Deposit` AS `Deposit`,`c`.`CName` AS `Client_Name`,`c`.`Client_ID` AS `Client_ID`,`cp`.`Spot_ID` AS `Spot_ID`,`cp`.`Plates_Number` AS `Plates_Number` from (`parkingfinder`.`current_parking` `cp` join `parkingfinder`.`clients` `c`) where (`cp`.`Client_ID` = `c`.`Client_ID`);

-- -----------------------------------------------------
-- View `parkingfinder`.`all_refund`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`all_refund` AS select `r`.`Cancel_Reason` AS `Cancel_Reason`,`r`.`Amount_Refunded` AS `Amount_Refunded`,`c`.`Username` AS `Username`,`r`.`Date_Of_Cancel` AS `Date_Of_Cancel`,`r`.`Spot_ID` AS `Spot_ID` from (`parkingfinder`.`refund` `r` join `parkingfinder`.`clients` `c`) where (`r`.`Client_ID` = `c`.`Client_ID`);

-- -----------------------------------------------------
-- View `parkingfinder`.`all_res`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`all_res` AS select `r`.`ArrDT` AS `Arrival_Date`,`r`.`DepDT` AS `Departure_Date`,`r`.`Deposit` AS `Deposit`,`r`.`Floor` AS `Floor`,`r`.`Lane` AS `Lane`,`r`.`Section` AS `Section`,`c`.`Username` AS `Username`,`r`.`Spot_ID` AS `Spot_ID` from (`parkingfinder`.`reservation` `r` join `parkingfinder`.`clients` `c`) where (`r`.`Client_ID` = `c`.`Client_ID`);

-- -----------------------------------------------------
-- View `parkingfinder`.`all_reviews`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`all_reviews` AS select `parkingfinder`.`reviews`.`Review` AS `Review`,`parkingfinder`.`reviews`.`Reply` AS `Reply`,`parkingfinder`.`reviews`.`_DateTime` AS `_DateTime`,`c`.`CName` AS `Client_Name`,`parkingfinder`.`reviews`.`SID` AS `SID`,`c`.`Client_ID` AS `Client_ID` from (`parkingfinder`.`reviews` join `parkingfinder`.`clients` `c`) where (`c`.`Client_ID` = `parkingfinder`.`reviews`.`CID`);

-- -----------------------------------------------------
-- View `parkingfinder`.`all_trans`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`all_trans` AS select round(sum(`parkingfinder`.`transactions`.`Amount_Paid`),2) AS `Total_Amount_Paid`,round(sum(`parkingfinder`.`transactions`.`Deposit`),2) AS `Total_Deposit`,`parkingfinder`.`transactions`.`SID` AS `SID`,`parkingfinder`.`transactions`.`CID` AS `Client_ID`,`parkingfinder`.`clients`.`CName` AS `Client_Name`,month(`parkingfinder`.`transactions`.`Dep_DateTime`) AS `Month`,year(`parkingfinder`.`transactions`.`Dep_DateTime`) AS `Year` from (`parkingfinder`.`transactions` join `parkingfinder`.`clients`) where (`parkingfinder`.`transactions`.`CID` = `parkingfinder`.`clients`.`Client_ID`) group by `parkingfinder`.`transactions`.`CID`,`parkingfinder`.`transactions`.`SID`;

-- -----------------------------------------------------
-- View `parkingfinder`.`avg_rating`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`avg_rating` AS select round(avg(`parkingfinder`.`ratings`.`Rating`),2) AS `AVG(rating)`,`parkingfinder`.`ratings`.`SID` AS `SID` from `parkingfinder`.`ratings` group by `parkingfinder`.`ratings`.`SID`;

-- -----------------------------------------------------
-- View `parkingfinder`.`avg_worked`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`avg_worked` AS select round(avg(`parkingfinder`.`employee`.`Monthly_Worked_Hours`),0) AS `AVG(Monthly_Worked_Hours)`,`parkingfinder`.`employee`.`Spot_ID` AS `Spot_ID` from `parkingfinder`.`employee` group by `parkingfinder`.`employee`.`Spot_ID`;

-- -----------------------------------------------------
-- View `parkingfinder`.`change_reservation`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`change_reservation` AS select `r`.`ArrDT` AS `Date`,`r`.`Floor` AS `Floor`,`r`.`Lane` AS `Lane`,`r`.`Section` AS `Section`,`c`.`Username` AS `Username`,`g`.`SName` AS `SName` from ((`parkingfinder`.`reservation` `r` join `parkingfinder`.`clients` `c`) join `parkingfinder`.`parking_place` `g`) where ((`r`.`Client_ID` = `c`.`Client_ID`) and (`g`.`Spot_ID` = `r`.`Spot_ID`));

-- -----------------------------------------------------
-- View `parkingfinder`.`tot_refund`
-- -----------------------------------------------------
USE `parkingfinder`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `parkingfinder`.`tot_refund` AS select sum(`parkingfinder`.`refund`.`Amount_Refunded`) AS `SUM(Amount_Refunded)`,`parkingfinder`.`refund`.`Spot_ID` AS `Spot_ID` from `parkingfinder`.`refund` group by `parkingfinder`.`refund`.`Spot_ID`;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
