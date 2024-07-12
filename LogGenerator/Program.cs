using Newtonsoft.Json;
using System.Text;

class Program
{
    static mac2s_log logModel = null;
//#if DEBUG
//    public static string baseUrl = "https://localhost:7064/";
//#else
//#endif
 public static string baseUrl = "http://10.17.250.14:8081/";
    static void Main(string[] args)
    {
        int cyclyCounter=1;
        int nok=0;
        while (true)
        {
            try
            {
                logModel = Applog.getlogData();
                if (logModel != null)
                {
                    using (var client = new HttpClient())
                    {
                        logModel.Part_Pr = cyclyCounter.ToString();
                        logModel.Nr_Cycle = cyclyCounter;
                        if (Applog.NokStatus(logModel))
                        {
                            nok++;
                            logModel.NOK=nok;
                        }
                        string contentType = "application/json";
                        string PostUrl = baseUrl + "api/log/create";
                        var content = new StringContent(JsonConvert.SerializeObject(logModel), Encoding.UTF8, contentType);
                        using (HttpResponseMessage response = client.PostAsync(PostUrl, content).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {

                                Console.WriteLine("{0}", logModel.Date_Heure);
                                Console.WriteLine("{0}", logModel.ProductionOrderId);
                            }
                            else
                            {
                                Console.WriteLine("{0}", response);
                                Console.WriteLine("{0}", logModel.Date_Heure);
                                Console.WriteLine("{0}", logModel.ProductionOrderId);
                            }
                        }
                    }
                }
                cyclyCounter++;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }

            Thread.Sleep(8000);
        }
    }
}

public class mac2s_log
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
    public double Abs_Val_S1_microm { get; set; }
    public double Abs_Val_S2_microm { get; set; }
    public double Abs_Val_S3_microm { get; set; }
    public double Abs_Val_S4_microm { get; set; }
    public double Abs_Val_S5_microm { get; set; }
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
    public int RefMachine { get; set; }
}

static class Applog
{
    public static mac2s_log getlogData()
    {
        mac2s_log objdata = new mac2s_log()
        {
            StatusId = 3,
            ProductionOrderId = 1,
            RunTime_h = 1,
            CycleTime_s = 8,
            Nr_Cycle = 0,
            Nr_Moule = "test",
            Abs_Val_S1_microm= Utilities.randomDouble(-0.6, 0.6),
            Abs_Val_S2_microm= Utilities.randomDouble(-0.6, 0.6),
            Abs_Val_S3_microm= Utilities.randomDouble(-0.6, 0.6),
            Abs_Val_S4_microm= Utilities.randomDouble(-0.6, 0.6),
            Abs_Val_S5_microm= Utilities.randomDouble(-0.6, 0.6),
            Abs_Val_PL= 0,
            //NOK = Utilities.RandomNumber(0, 1),
            NOK = 0,
            Hi_Tol_S1 = 0.5f,
            Hi_Tol_S2 = 0.5f,
            Hi_Tol_S3 = 0.5f,
            Hi_Tol_S4 = 0.5f,
            Hi_Tol_S5 = 0.5f,
            Lo_Tol_S1 = -0.5f,
            Lo_Tol_S2 = -0.5f,
            Lo_Tol_S3 = -0.5f,
            Lo_Tol_S4 = -0.5f,
            Lo_Tol_S5 = -0.5f,
            Part_Pr = "0" ,
            RefMachine=15,
            Date_Heure = DateTime.Now
        };

        return objdata;
    }

    public static bool NokStatus(mac2s_log log)
    {
        bool result = false;
        if (log.Abs_Val_PL!=0 
                || log.Abs_Val_S1_microm > log.Hi_Tol_S1 || log.Abs_Val_S1_microm < log.Lo_Tol_S1
                || log.Abs_Val_S2_microm > log.Hi_Tol_S2 || log.Abs_Val_S2_microm < log.Lo_Tol_S2
                || log.Abs_Val_S3_microm > log.Hi_Tol_S3 || log.Abs_Val_S3_microm < log.Lo_Tol_S3
                || log.Abs_Val_S4_microm > log.Hi_Tol_S4 || log.Abs_Val_S4_microm < log.Lo_Tol_S4
                || log.Abs_Val_S5_microm > log.Hi_Tol_S5 || log.Abs_Val_S5_microm < log.Lo_Tol_S5
            )
        {
            Console.WriteLine($"Abs_Val_PL: {log.Abs_Val_PL}");
            Console.WriteLine($"Abs_Val_S1_microm: {log.Abs_Val_S1_microm}");
            Console.WriteLine($"Abs_Val_S2_microm: {log.Abs_Val_S2_microm}");
            Console.WriteLine($"Abs_Val_S4_microm: {log.Abs_Val_S3_microm}");
            Console.WriteLine($"Abs_Val_S4_microm: {log.Abs_Val_S4_microm}");
            Console.WriteLine($"Abs_Val_S5_microm: {log.Abs_Val_S5_microm}");
            result =true;
        }
        return result;
    }
}

static class Utilities
{
    public static int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    public static double randomDouble( double start, double end)
    {
        Random rand = new Random();

        return (rand.NextDouble() * Math.Abs(end - start)) + start;
    }


}