﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.Services
{
    public interface IEmailSender
    {
        Task Sender(string userId,string message);
    }
}
