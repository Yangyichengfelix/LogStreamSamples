using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mac2sAPI.Migrations
{
    public partial class procedure_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "StatusGroup",
            columns: new[] { "Id", "Name", "Color" },
            values: new object[,]
            {
                            {1,"Production", "green"},
                            {2,"Cleaning/ Maintenance", "orange"},
                            {3,"Outage", "crimsn"},
                            {4,"Break time", "grey"},
                            {5,"Changing", "greenyellow"},
                            {6,"Configuration", "chocolate"},
                            {7,"Others", "indigo"}

            });


            migrationBuilder.InsertData(
            table: "Mold",
            columns: new[] { "Id", "Nr_Moule", "NameIMM", "Nb_piece", "Ref_S1", "Ref_S2", "Ref_S3", "Ref_S4", "Ref_S5" },
            values: new object[,]
            {
                {1,"Erp0000", "IMM Test",0,0f, 0f, 0f, 0f,0f},

            });

            migrationBuilder.InsertData(
            table: "Image",
            columns: new[] { "Id", "FileName", "FileContent" },
            values: new object[,]
            {
                {1,"Test",null},

            });
            migrationBuilder.InsertData(
            table: "Product",
            columns: new[] { "Id", "Name", "MoldId", "ImageId" },
            values: new object[,]
            {
                {1,"Test",1,null},

            });
            migrationBuilder.InsertData(
            table: "ProductionOrder",
            columns: new[] { "Id", "Reference", "ProductId", "Color", "Material", "ObjectifNumber" },
            values: new object[,]
            {
                {1,"Test",1,6666, "Test", 1000},

            });
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name", "StatusGroupId", "Color" },
                values: new object[,]
                {
                    {1, "Senors reset to 0", 6, "darkorange"},
                    {2, "Modify paramters of Mac2s", 6, "darkgoldenrod"},
                    {3, "Production", 1, "lightgreen"},
                    {4, "Stop indefinitie",  4, "crimson"},
                    {5, "Power down", 4 , "darkgray"},
                    {6, "Manuel", 1 , "black"},
                    {7, "Test", 6, "gold"},
                    {8, "Production order change", 5, "mediumturquoise" },
                    {9, "Version change", 5, "lightseagreen" },
                    {10, "Material/colorant change",5, "teal"},
                    {11, "Break", 4, "skyblue"},
                    {12, "Moud mounting", 2, "steelblue"},
                    {13, "Waiting for staff", 4, "royalblue"},
                    {14, "Maintenance/PDJ Mold", 2, "navy" },
                    {15, "Outage IMM", 3, "firebrick"},
                    {16, "Outage Robot", 3 , "lightcoral"},
                    {17, "Outage Mold", 3 , "mediumvioletred"},
                    {18, "Auxiliary outage", 3, "orangered" },
                    {19, "Status 19", 7 , "wheat"},
                    {20, "Status 20", 7 ,"whitesmoke"},
                    {21, "Status 21", 7, "silver" },
                    {22, "Status 22", 7 , "oldlace"},
                    {23, "Sensor error", 3, "tomato" },
                    {24, "Status 24", 7 , "orchid"},
                    {25, "Connection on", 7 , "indigo"}

                });
            migrationBuilder.InsertData(
                table: "GaugeParameter",
                columns: new[] { "Id", "Name", "StartAngle", "EndAngle", "step", "Breakpoint1", "Breakpoint2" },
                values: new object[,]
                {
                    {1, "Overall Equipement Effectiveness", -90, 90, 10, 40, 75},
                    {2, "Overall Operations Effectiveness", -90, 90, 10, 40, 75}

                });
            //16:32 16/12/2021
            migrationBuilder.InsertData(
            table: "ScheduleParameter",
            columns: new[] { "Id", "Name", "Start", "End" },
            values: new object[,]
            {
                    {1, "Default 1", new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)},
                    {2, "Default 2", new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)},
                    {3, "Default 3", new TimeSpan(0, 0, 0), new TimeSpan(23, 0, 0)}


            });
            migrationBuilder.Sql(@"CREATE VIEW LogDuration AS 
                SELECT A.*,  CONVERT( TIME_TO_SEC(TIMEDIFF(B.Date_Heure , A.Date_Heure)), DECIMAL) AS Duration
                FROM `Log` A INNER JOIN `Log` B ON B.id = (A.id+1 )
                ORDER BY B.id ASC;");

            migrationBuilder.Sql(@"
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
                                    ;");
            migrationBuilder.Sql(@"
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
                                    ;");
            migrationBuilder.Sql(@"CREATE PROCEDURE GetGroupedStatusByTimeRange
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
                                END;");
            migrationBuilder.Sql(
                @"CREATE TRIGGER trig_validate_log
                        BEFORE INSERT
                        ON Log
                        FOR EACH ROW
                        BEGIN
                        IF
                        new.Date_Heure < (SELECT Date_heure FROM Log ORDER BY Id DESC LIMIT 1)
                        THEN
                        SET new.Date_Heure = NOW();
                        END IF;
                        END "
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW LogDuration;");
            migrationBuilder.Sql(@"DROP PROCEDURE GetStatusWithDurationBy_TimeRange_schedule;");
            migrationBuilder.Sql(@"DROP PROCEDURE GetStatusGroup_WithDuration_ByTimeRange_schedule;");
            migrationBuilder.Sql(@"DROP PROCEDURE GetGroupedStatusByTimeRange;");
            migrationBuilder.Sql(@"DROP TRIGGER trig_validate_log;");

        }

    }
}
