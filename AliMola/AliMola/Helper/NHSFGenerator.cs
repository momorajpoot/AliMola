using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AliMola
{
    public class NHSFGenerator
    {
        public static ISessionFactory SF = null;
        public static ISessionFactory GetNHSF()
        {
            try
            {
                Configuration NHConfig = new Configuration();

                if (SF == null)
                {
                    NHConfig.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    NHConfig.SetProperty("dialect", "NHibernate.Dialect.MySQLDialect");
                    NHConfig.SetProperty("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
                    NHConfig.SetProperty("command_timeout", "60");
                    NHConfig.SetProperty("connection.connection_string", "Server=localhost;Database=alimoladb;User ID=root;Password=maryam;CharSet=utf8;");

                    NHConfig.AddAssembly("AliMola");

                    //only needed when you get error for session context
                    NHConfig.CurrentSessionContext<WebSessionContext>();


                    SF = NHConfig.BuildSessionFactory();
                }
            }
            catch (Exception ex)
            {

            }
                

            return SF;
        }
        }
}