using BaseAcces;
using System.Data;
using System.Collections.Generic;

namespace TRUCK
{

    public class BLL:BaseBusiness
    {
        DLL _dll;
        public BLL()
        {
            _dll = new DLL(_StringConexion, TypeDataBase.Firebird);
        }

        public List<string> getListData(string query)
        {
           return _dll.getListData(query);
        }

        public DataSet getData(string query)
        {
            return _dll.getData(query);
        }

        public IDataReader getDataReader(string query)
        {
            return _dll.getDataReader(query);
        }

        public void ExecuteQuery(string query)
        {
            _dll.ExecuteQuery(query);
        }
    }

}
