﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Data
{
    public class Mac2s_log
    {
        public DateTime Date_Heure { get; set; }
        public int StatusId { get; set; }
        public int VersionId { get; set; }
        public int ProductionOrderId { get; set; }

        public int RunTime_h { get; set; }
        public int CycleTime_s { get; set; }
        public int Nr_Cycle { get; set; }
        public string Nr_Moule { get; set; }
        public int NOK { get; set; }
        public float Abs_Val_S1_microm { get; set; }
        public float Abs_Val_S2_microm { get; set; }
        public float Abs_Val_S3_microm { get; set; }
        public float Abs_Val_S4_microm { get; set; }
        public float Abs_Val_S5_microm { get; set; }
        public float Abs_Val_PL { get; set; }
        public float Hi_Tol_S1 { get; set; }
        public float Lo_Tol_S1 { get; set; }
        public float Hi_Tol_S2 { get; set; }
        public float Lo_Tol_S2 { get; set; }
        public float Hi_Tol_S3 { get; set; }
        public float Lo_Tol_S3 { get; set; }
        public float Hi_Tol_S4 { get; set; }
        public float Lo_Tol_S4 { get; set; }
        public float Hi_Tol_S5 { get; set; }
        public float Lo_Tol_S5 { get; set; }
        public string Part_Pr { get; set; }
    }
}
