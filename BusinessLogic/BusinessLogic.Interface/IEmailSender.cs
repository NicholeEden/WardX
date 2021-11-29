using System.Net;

namespace BusinessLogic.Interface
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email using FluentEmail
        /// </summary>
        /// <param name="client"></param>
        /// <param name="credential"></param>
        /// <param name="fromEmail"></param>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        bool SendEmail(
            ClientType type,
            NetworkCredential credential,
            string fromEmail,
            string toEmail,
            string subject,
            string body);
    }

    public enum ClientType
    {
        Microsoft,
        Google,
        Yahoo
    }
}
