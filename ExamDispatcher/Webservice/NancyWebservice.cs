using System.Collections.Generic;
using System.Diagnostics;
using DataModels.Questions;
using ExamSandbox;
using Nancy;

namespace Webservice
{
    using System;
    using Nancy.Hosting.Self;
    using Utilities;

    public class NancyWebservice
    {
        private static NancyHost HostedWebService;
        
        public static void Start()
        {
            var uri = new Uri("http://localhost:3579");

            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() {CreateAutomatically = true}
            };
                
            var HostedWebservice = new NancyHost(uri, new DefaultNancyBootstrapper(), hostConfiguration);

            //Commands.Run("netsh.exe", "advfirewall firewall add rule name=\"ExamDispatcher 3579\" dir=in action=allow protocol=TCP localport=3579");
            //Commands.Run("netsh.exe", "advfirewall firewall add rule name=\"ExamDispatcher 3579\" dir=out action=allow protocol=TCP localport=3579");

            //Commands.Run("netsh advfirewall firewall add rule name=\"ExamDispatcher 3579\" dir=in action=allow protocol=TCP localport=3579");

            //Commands.CommandRun("\\Content\\firewall.bat");

            //NetAclChecker.AddAddress("http://+:3579/");

            HostedWebservice.Start();
        }

        public static void Stop()
        {
            try
            {

                HostedWebService.Stop();
            }
            catch (Exception e)
            {
                
            }
        }

        static void Main(string[] args)
        {
            var uri =
                new Uri("http://localhost:3579");

            using (var host = new NancyHost(uri))
            {
                host.Start();

                var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
                var exam = new Exam("Title", guid, new List<BaseQuestion>(), 10);

                Sandbox.AddExamToSandbox(exam);

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
