﻿namespace AdoptMe.Web.Infrastructure.EmailSender
{
    public class SmtpSettings
    {
        public string Server { get; set; }

        public int Port { get; set; }

        public string FromAddress { get; set; }

        public string Password { get; set; }
    }
}
