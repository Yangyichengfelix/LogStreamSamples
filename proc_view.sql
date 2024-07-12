CREATE VIEW LogDuration AS 
                SELECT A.*,  CONVERT( TIME_TO_SEC(TIMEDIFF(B.Date_Heure , A.Date_Heure)), DECIMAL) AS Duration
                FROM `Log` A INNER JOIN `Log` B ON B.id = (A.id+1 )
                ORDER BY B.id ASC;
                
CREATE PROCEDURE GetStatusWithDurationBy_TimeRange_schedule
	                                    ( 
		                                IN StartTime DATETIME, 
		                                IN EndTime DATETIME,
		                                IN ScheduleStart TIME,
		                                IN ScheduleEnd TIME
	                                    )
                                    BEGIN
		                                SELECT StatusId as Id,Status.Name,(SUM(duration))  AS Duration , Color 
		                                FROM LogDuration
                                        LEFT JOIN Status
                                        ON LogDuration.StatusId =Status.Id 
                                        WHERE Date_Heure <EndTime AND Date_Heure > StartTime
                                        AND TIME(Date_Heure)>ScheduleStart AND TIME(Date_Heure)<ScheduleEnd
                                        GROUP BY Status.name
                                        ORDER BY StatusId;
                                    END
                                    ;
                                    CREATE PROCEDURE GetStatusGroup_WithDuration_ByTimeRange_schedule
	                                    ( 
		                                    IN StartTime DATETIME, 
		                                    IN EndTime DATETIME,
		                                    IN ScheduleStart TIME,
		                                    IN ScheduleEnd TIME
	                                    )
                                    BEGIN
		                                    SELECT StatusGroupId as Id,StatusGroup.Name,(SUM(duration))  AS Duration, StatusGroup.Color as Color    
		                                    FROM LogDuration
                                            LEFT JOIN Status
                                            ON LogDuration.StatusId =Status.Id 
                                            LEFT JOIN StatusGroup
                                            ON Status.StatusGroupId =StatusGroup.Id 
                                            WHERE Date_Heure >StartTime AND Date_Heure < EndTime
                                            AND TIME(Date_Heure)>ScheduleStart AND TIME(Date_Heure)<ScheduleEnd
                                            GROUP BY StatusGroup.name
                                            ORDER BY StatusGroupId;
                                    END
                                    ;
                                   CREATE PROCEDURE GetGroupedStatusByTimeRange
	                                (
		                            IN StartTime DATETIME, 
		                            IN EndTime DATETIME
	                                )
                                BEGIN
                                SELECT StatusId,  Name, Grp,MIN(Date_Heure) AS StartTime,MAX(Date_Heure) AS EndTime, Color
                                FROM
                                    (SELECT StatusId,Name, Date_Heure, Duration, Color,
                                             SUM(reset) OVER (ORDER BY Date_Heure) AS Grp
                                     FROM 
                                            (SELECT StatusId,Status.Name as Name, Date_Heure,Duration, Color,
                                                    case when coalesce(lag(StatusId) OVER (ORDER BY Date_Heure), '0') <> StatusId THEN 1 END AS reset
                                             FROM   LogDuration
                                             LEFT JOIN Status
                                             ON Status.Id= LogDuration.StatusId
                                             WHERE Date_Heure <EndTime AND Date_Heure > StartTime
                                             ) t1
                                    ) t2
                                GROUP BY Grp
                                ORDER BY StartTime;
                                END;