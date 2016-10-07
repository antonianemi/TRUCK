using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;


namespace TRUCK
{

    public class ModelGeneral : MVP.MVPGeneral.IModelOpc
    {
        DataAccesQuery db;

        private readonly MVP.MVPGeneral.IRequiredPresenterOpc _presenter;

        public ModelGeneral(MVP.MVPGeneral.IRequiredPresenterOpc presenter)
        {
            db = new TRUCK.DataAccesQuery();
            _presenter = presenter;
        }

        public ENT_CONFIGURATION getConfiguration()
        {
            ENT_CONFIGURATION obj = new ENT_CONFIGURATION();
            
            return obj;
        }
        


        public void saveConfiguration(ENT_CONFIGURATION obj)
        {
            db.ExcetuteQuery(String.Format("INSERT INTO CONFIGURACION VALUES('{0}',{1},'{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},'{19}','{20}')", obj.car_moneda, obj.num_decimal, obj.formato_fecha, obj.puerto, obj.puerto2, obj.puerto3, obj.puerto4, obj.puerto5, obj.baudrate, obj.baudrate2, obj.baudrate3, obj.baudrate4, obj.baudrate5, obj.folio, obj.tipo, obj.scale, obj.aplicacion, obj.display, obj.numemp, obj.rmto, obj.path));
        }

    }

}
