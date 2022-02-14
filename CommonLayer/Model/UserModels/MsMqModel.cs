using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace CommonLayer.Model.UserModels
{
    public class MsMqModel
    {
       // MessageQueue MSMQ = new MessageQueue();
        //MessageQueue msmq = new MessageQueue();

        /// <summary>
        /// MSMQs the sender.
        /// </summary>
        /// <param name="token">The token.</param>
    //    public void MsmqSender(string token)
    //    {
    //        try
    //        {
    //            msmq.Path = @".\private$\Token";
    //            if (!MessageQueue.Exists(msmq.Path))
    //            {
    //                MessageQueue.Create(msmq.Path);
    //            }

    //            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
    //            msmq.ReceiveCompleted += MsmqReceiver;
    //            msmq.Send(token);
    //            msmq.BeginReceive();
    //            msmq.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    /// <summary>
    //    /// MSMQs the receiver.
    //    /// </summary>
    //    /// <param name="sender">The sender.</param>
    //    /// <param name="e">The <see cref="ReceiveCompletedEventArgs"/> instance containing the event data.</param>
    //    private void MsmqReceiver(object sender, ReceiveCompletedEventArgs e)
    //    {
    //        try
    //        {
    //            var msg = msmq.EndReceive(e.AsyncResult);
    //            string token = msg.Body.ToString();
    //            string Subject = "Book Store Application Password Reset";
    //            string Body = token;
    //            string receiverMail = DecodeJwt(token);

    //            MailMessage message = new MailMessage("fakemailing302@gmail.com", receiverMail);
    //            message.Body = Body;
    //            message.IsBodyHtml = true;
    //            message.Subject = Subject;

    //            //mail sending code

    //            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    //            NetworkCredential credential = new NetworkCredential("fakemailing302@gmail.com", "@Password123");
    //            smtpClient.EnableSsl = true;
    //            smtpClient.UseDefaultCredentials = false;
    //            smtpClient.Credentials = credential;
    //            smtpClient.Send(message);

    //            //msmq receiver
    //            msmq.BeginReceive();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    /// <summary>
    //    /// Decodes the JWT.
    //    /// </summary>
    //    /// <param name="token">The token.</param>
    //    /// <returns></returns>
    //    public static string DecodeJwt(string token)
    //    {
    //        try
    //        {
    //            var decodeToken = token;
    //            var handler = new JwtSecurityTokenHandler();
    //            var jsonToken = handler.ReadJwtToken((decodeToken)) as JwtSecurityToken;
    //            var result = jsonToken.Claims.FirstOrDefault().Value;
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }
    //}

    //public void Sender(string token)
    //{

    //    MSMQ.Path = @".\private$\Tokens";

    //    try
    //    {
    //        if (!MessageQueue.Exists(MSMQ.Path))
    //        {
    //            MessageQueue.Create(MSMQ.Path);
    //        }

    //        MSMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

    //        MSMQ.ReceiveCompleted += Msmq_ReceiveCompleted;
    //        MSMQ.Send(token);
    //        MSMQ.BeginReceive();
    //        MSMQ.Close();
    //    }
    //    catch (Exception e)
    //    {
    //        throw;
    //    }

    //}
    //public static string GetEmailFromToken(string token)
    //{
    //    var handler = new JwtSecurityTokenHandler();
    //    var decoded = handler.ReadJwtToken((token));
    //    var result = decoded.Claims.FirstOrDefault().Value;
    //    return result;
    //}
    //private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
    //{
    //    var msg = MSMQ.EndReceive(e.AsyncResult);
    //    string token = msg.Body.ToString();


    //    // mail sending code smtp 
    //    string mailReceiver = GetEmailFromToken(token).ToString();
    //    MailMessage message = new MailMessage("fakemailing302@gmail.com", mailReceiver);
    //    string bodymessage = "here" +
    //        "Token-> : " + token;



    //    message.Subject = "Message";
    //    message.Body = bodymessage;
    //    message.BodyEncoding = Encoding.UTF8;
    //    message.IsBodyHtml = true;
    //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
    //    System.Net.NetworkCredential basicCredential1 = new
    //    System.Net.NetworkCredential("fakemailing302@gmail.com", "@Password123");
    //    client.EnableSsl = true;
    //    client.UseDefaultCredentials = false;
    //    client.Credentials = basicCredential1;
    //    try
    //    {
    //        client.Send(message);
    //    }

    //    catch (Exception ex)
    //    {
    //        throw;
    //    }

    //    MSMQ.BeginReceive();
    //}

    }
}
