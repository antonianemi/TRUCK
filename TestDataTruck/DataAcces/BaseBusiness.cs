using System;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;


namespace TRUCK
{
    public class BaseBusiness
    {
        private int _CodeError;
        private bool _IsError;
        private string _MessageError;

        public bool ExistError
        {
            get { return _IsError; }
            set { _IsError = value; }
        }
        public string MessageError
        {
            get { return _MessageError; }
            set { _MessageError = value; }
        }
        public int CodeError
        {
            get { return _CodeError; }
            set { _CodeError = value; }
        }


        private static string stringConexion = string.Empty;


        /// <summary>
        /// Representa 
        /// </summary>
        public static string _StringConexion
        {
            get
            {
                FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
                csb.ServerType = FbServerType.Embedded;
                csb.UserID = ConfigurationManager.AppSettings["USERID"];
                csb.Password = ConfigurationManager.AppSettings["PASSWORD"];
                csb.Dialect = Convert.ToInt32(ConfigurationManager.AppSettings["DIALECT"]);
                csb.Database = ConfigurationManager.AppSettings["DATABASE"];
                csb.Charset = ConfigurationManager.AppSettings["CHARSET"];
                stringConexion = csb.ConnectionString;
                return stringConexion;
            }
        }
    }



}
