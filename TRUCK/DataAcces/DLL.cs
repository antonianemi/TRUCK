using System;
using BaseAcces;
using System.Data;
namespace TRUCK
{

    public class DLL:BaseDLL
    {
        public DLL(string pstrConn, TypeDataBase pTypeDB) : base(pstrConn, pTypeDB)
        {

        }

        public IDataReader getDataReader(string query)
        {
            return ExecuteReader(query);          
        }

        public DataSet getData(string query)
        {
            return AdapterFill(query);
        }

        public void ExecuteQuery(string query)
        {
            this.ExecuteNonQuery(query);
        }
    }

}
