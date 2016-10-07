using BaseAcces;
using System.Data;
using System.Collections.Generic;

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

        public List<string> getListData(string query)
        {
            List<string> items = new List<string>();


           IDataReader reader= this.ExecuteReader(query);

            while (reader.Read())
            {
                items.Add(reader[0].ToString());
            }

            return items;
        }
    }

}
