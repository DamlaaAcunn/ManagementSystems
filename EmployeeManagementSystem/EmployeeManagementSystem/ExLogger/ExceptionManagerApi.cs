﻿using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using System.Web.Mvc;  
using log4net;  
using System.IO;  
using System.Reflection;  
using System.Web.Http.ExceptionHandling;  
  
namespace EmployeeManagementSystem.ExLogger
{
    public class ExceptionManagerApi : ExceptionLogger
    {
        ILog _logger = null;
        public ExceptionManagerApi()
        {
            // Gets directory path of the calling application  
            // RelativeSearchPath is null if the executing assembly i.e. calling assembly is a  
            // stand alone exe file (Console, WinForm, etc).   
            // RelativeSearchPath is not null if the calling assembly is a web hosted application i.e. a web site  
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;


            var log4NetConfigFilePath = "C:\\inetpub\\wwwroot\\EmployeeManagementSystem\\ExLogger\\log4net.config";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }
        public override void Log(ExceptionLoggerContext context)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(context.Exception.ToString() + Environment.NewLine);
        }
        public void Log(string ex)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(ex);
           
        }

    }



}