using System.Data;

namespace TRUCK
{
    public class DataAccesQuery
    {

        BLL _bll;

        public DataAccesQuery()
        {
            _bll = new BLL();
        }


        public DataSet getData(string query)
        {
            return _bll.getData(query);
        }

        public IDataReader getDataReader(string query)
        {
            return _bll.getDataReader(query);
        }
        public void ExcetuteQuery(string query)
        {
            _bll.ExecuteQuery(query);
        }

    }
}
