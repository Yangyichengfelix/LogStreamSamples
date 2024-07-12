using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Mac2sAPI.Data
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public DateTime Date_Heure { get; set; }
        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status  Status { get; set; }
        [ForeignKey("Version")]
        public Int64? VersionId { get; set; }
        [ForeignKey("ProductionOrder")]

        public int? ProductionOrderId { get; set; }

        public virtual ProductionOrder? ProductionOrder { get; set; }
        [Required]
        public Int64 RunTime_h { get; set; }
        public Int64? CycleTime_s { get; set; }
        public Int64? Nr_Cycle { get; set; }
        [MaxLength(50)]
        public string? Nr_Moule { get; set; }

        public Int64? NOK { get; set; }

        public float? Abs_Val_S1_microm { get; set; }

        public float? Abs_Val_S2_microm { get; set; }

        public float? Abs_Val_S3_microm { get; set; }

        public float? Abs_Val_S4_microm { get; set; }

        public float? Abs_Val_S5_microm { get; set; }

        public float? Abs_Val_PL { get; set; }

        public float? Hi_Tol_S1 { get; set; }

        public float? Lo_Tol_S1 { get; set; }

        public float? Hi_Tol_S2 { get; set; }

        public float? Lo_Tol_S2 { get; set; }

        public float? Hi_Tol_S3 { get; set; }

        public float? Lo_Tol_S3 { get; set; }

        public float? Hi_Tol_S4 { get; set; }

        public float? Lo_Tol_S4 { get; set; }

        public float? Hi_Tol_S5 { get; set; }

        public float? Lo_Tol_S5 { get; set; }


        public string? Part_Pr { get; set; }
        public Int64? RefMachine { get; set; }
    }
}
