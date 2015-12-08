using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;

namespace PivotalWorkshop.Utilities
{
    public class PCFEnvironment
    {
        private static readonly string INSTANCE_GUID_ENV_VARIABLE_NAME = "INSTANCE_GUID";
        private static readonly string BOUND_SERVICES_ENV_VARIABLE_NAME = "VCAP_SERVICES";

        private static string _connectionString = string.Empty;

        static PCFEnvironment()
        {
            if (BoundServices.GetValue("p-mysql") != null)
            {
                MySqlConnectionStringBuilder csbuilder = new MySqlConnectionStringBuilder();
                csbuilder.Add("server", BoundServices["p-mysql"][0]["credentials"]["hostname"].ToString());
                csbuilder.Add("port", BoundServices["p-mysql"][0]["credentials"]["port"].ToString());
                csbuilder.Add("uid", BoundServices["p-mysql"][0]["credentials"]["username"].ToString());
                csbuilder.Add("pwd", BoundServices["p-mysql"][0]["credentials"]["password"].ToString());
                csbuilder.Add("database", BoundServices["p-mysql"][0]["credentials"]["name"].ToString());
                _connectionString = csbuilder.ToString();
            }
        }

        public static JObject BoundServices
        {
            get { return JObject.Parse(Environment.GetEnvironmentVariable(BOUND_SERVICES_ENV_VARIABLE_NAME)); }
        }

        public static string DbConnectionString
        {
            get { return _connectionString; }
        }
    }
}