using BusinessLogic.Interface;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using Xunit;

namespace BusinessLogic.Tests
{
    public class EmailTests
    {
        [Fact(Skip = "Development Test only")]
        public void SendEmail()
        {
            var logic = new Logic(new DataProvider());

            var result = logic.SendEmail(
                type: ClientType.Microsoft,
                credential: GetCredential(),
                fromEmail: "s219403805@mandela.ac.za",
                toEmail: "s217467571@mandela.ac.za",
                subject: "WARDx Fluent Email",
                body: "This is a test email");

            // email sent successfully
            Assert.True(result);
        }

        private static string GetUsername()
        {
            // a ConfigurationBuilder object is created
            var builder = new ConfigurationBuilder()
                // get the current folder path of the application and
                // set it as the base path
                .SetBasePath(Directory.GetCurrentDirectory())
                // append the JSON file to be used to the base path
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true);

            // configure the IConfiguration interface to use the
            // setting applied in the ConfigurationBuilder
            var config = builder.Build();

            // get the value from the key 'ConnectionStrings:DefaultConnection' found 
            // in the 'appsettings.json' file
            string value = config["Credentials:Username"];

            // return the value
            return value;
        }

        private static string GetPassword()
        {
            // a ConfigurationBuilder object is created
            var builder = new ConfigurationBuilder()
                // get the current folder path of the application and
                // set it as the base path
                .SetBasePath(Directory.GetCurrentDirectory())
                // append the JSON file to be used to the base path
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true);

            // configure the IConfiguration interface to use the
            // setting applied in the ConfigurationBuilder
            var config = builder.Build();

            // get the value from the key 'ConnectionStrings:DefaultConnection' found 
            // in the 'appsettings.json' file
            string value = config["Credentials:Password"];

            // return the value
            return value;
        }

        public static NetworkCredential GetCredential()
        {
            return new NetworkCredential(
                userName: GetUsername(),
                password: GetPassword());
        }
    }
}
