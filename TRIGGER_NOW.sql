CREATE TRIGGER trig_validate_log
BEFORE INSERT
ON Log
FOR EACH ROW
BEGIN
SET new.Date_Heure=NOW();
END 


DROP TRIGGER IF EXISTS trig_validate_log;

CREATE TRIGGER trig_validate_log
BEFORE INSERT
ON Log
FOR EACH ROW
BEGIN
	IF 
	new.Date_Heure<(SELECT Date_heure FROM Log ORDER BY Id DESC LIMIT 1)
	THEN
SET new.Date_Heure=NOW();
END IF;
END 


