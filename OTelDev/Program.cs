using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Data.SqlClient;

using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Npgsql;

namespace OTelDev
{
    class Program
    {
        private static readonly string connString = "{add your connstring to a simple postgres db}";

        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("SIGNALFX_ENV", "dev", EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("SIGNALFX_SERVICE_NAME", "otel_test", EnvironmentVariableTarget.Process);

            Console.WriteLine("envs set");

            for (int i = 0; i < 3; i++)
            {
                CallGithub();
                CallDatabase();
                Thread.Sleep(2000);
            }

            Console.WriteLine("end");

        }

        private static void CallDatabase()
        {
            string sql = "select table_catalog, table_schema, table_name from information_schema.tables;";

            using (var connection = new NpgsqlConnection(connString))
            {
                try
                {
                    var output = connection.Execute(sql, null, null, null, System.Data.CommandType.Text);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }

                Console.WriteLine("**************************** db call executed *****************************");
                connection.Close();
            }
        }

        private static void CallGithub()
        {
            using (var client = new HttpClient())
            {
                string restQuery = "https://api.github.com/orgs/dotnet/repos";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var response = client.GetAsync(restQuery).Result;
                var stringResult = response.Content.ReadAsStringAsync().Result;
                Thread.Sleep(1000);
                Console.Write(stringResult);
            }
        }
    }
}
