using Common.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace Common.Email
{
    public class SendEmail
    {
        static Thread SendMail_Thread;

       

        public class EmailQueue
        {
            public string Email { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public bool is_finished { get; set; }

            public EmailQueue()
            {
                Email = "";
                Subject = "";
                Body = "";
                is_finished = false;
            }
        }

        
        
        public static List<EmailQueue> EmailQueueList = new List<EmailQueue>();
       

        /* while (SendMail_Thread.IsAlive)
         {

             for (int i = 0; i < EmailQueueList.Count; i++)
             {
                 try
                 {
                     if (!EmailQueueList[i].is_finished)
                     {
                         SendMail(EmailQueueList[i].Email, EmailQueueList[i].Subject, EmailQueueList[i].Body, false);
                         EmailQueueList[i].is_finished = true;
                         Thread.Sleep(3000);
                     }
                 }
                 catch (Exception ex)
                 {

                 }
             }
             Thread.Sleep(10000);
         }
        
     }*/
    }
}