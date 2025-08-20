using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.Controller;

namespace ConsoleApp
{
    public class Controller
    {
        public void ReportCallBack(Report report)
        {
            Console.WriteLine($"Report Generation successful for {report.ReportName}");
        }

        public void GetReport(int RequestID, Request request)
        {
            GetReportActual(request, (rep) => Console.WriteLine($"Report Generation successful for {rep.ReportName}"));
        }

        public void GetReportActual(Request request, Action<Report> action)
        {
            var result = request.GetResult();
            if (result != null)
            {
                if (result.Status == StatusType.Done)
                {
                    action(result.Report);
                }
                else
                    Console.WriteLine("Report Generation failed");
            }
        }

        public enum StatusType
        {
            None,
            Pending,
            Done,
            Error
        }

        public class Request
        {
            public Result GetResult()
            {
                var result = new Result();
                if (Validation == RequestValidation.Verified)
                {
                    result.GenerateReport();
                    result.Status = StatusType.Done;
                }
                else
                {
                    result.Status = StatusType.Error;
                }
                return result;
            }

            public RequestValidation Validation { get; set; }
        }

        public enum RequestValidation
        {
            Verified,
            NotVerified
        }

        public class Result
        {
            public Result()
            {

            }

            public void GenerateReport()
            {
                Report = new Report(1, "Report1");
            }

            public Report Report { get; set; }

            public StatusType Status { get; set; }
        }

        public class Report
        {
            public Report(int SrNo, string reportName)
            {
                num = SrNo;
                ReportName = reportName;
            }
            public int num;

            public string ReportName;
        }
    }


    public class BaseReportHandler : Controller
    {
        public void ExportExcecuted()
        {
            Console.WriteLine("Doing some work Related to General things like log/or some basic Validation");
            ExportExcecutedOverride();
        }

        public virtual void ExportExcecutedOverride()
        {
            //this is over and above basic validation at base level can be overriden at further levels
        }

        public void GetReport(Request request)
        {
            GetReportActual(request, BasicReportCallBack);
        }

        public void BasicReportCallBack(Report report)
        {
            ReportCallBack(report);
        }

        public void ReportCallBack(Report report) { }
    }
}
