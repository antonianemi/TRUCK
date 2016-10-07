using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUCK
{

    /// <summary>
    /// this is the entitie configuration that contains all necessary for normalize the information and validate 
    /// </summary>
    public class ENT_CONFIGURATION
    {
        public int puerto { set; get; }
        public int baudrate { set; get; }
        public int puerto2 { set; get; }
        public int baudrate2 { set; get; }
        public int puerto3 { set; get; }
        public int baudrate3 { set; get; }
        public int baudrate5 { set; get; }
        public int puerto4 { set; get; }
        public int puerto5 { set; get; }
        public int baudrate4 { set; get; }
        public int tipo { set; get; }
        public int scale { set; get; }
        public string formato_fecha { set; get; }
        public int num_decimal { set; get; }
        public int numemp { set; get; }
        public string car_moneda { set; get; }
        public int folio { set; get; }
        public int display { set; get; }
        public int aplicacion { set; get; }
        public string path { set; get; }
        public string rmto { set; get; }

        /// <summary>
        /// Normalize the information and validate the same.
        /// </summary>
        public void Validate()
        {

        }
    }
}
