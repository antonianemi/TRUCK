


using TRUCK;
namespace TestDataTruck
{

    class Program
    {
        static DataAccesQuery db;
        static void Main(string[] args)
        {
            testEntityConfiguration();
            System.Console.ReadKey();
        }
        static void testEntityConfiguration()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 1,
                baudrate2 = 1,
                baudrate3 = 1,
                baudrate4 = 1,
                car_moneda = "moneda",
                display = 1,
                folio = 1,
                formato_fecha = "format_date",
                num_decimal = 1,
                path = "path",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "rmto",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration2()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration2");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration3()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration3");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration4()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration4");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration5()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration5");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration6()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration6");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void testEntityConfiguration7()
        {
            System.Console.Clear();
            System.Console.WriteLine("testEntityConfiguration7");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            InsertConfiguration(new ENT_CONFIGURATION()
            {
                aplicacion = 1,
                baudrate = 2,
                baudrate2 = 3,
                baudrate3 = 4,
                baudrate4 = 5,
                car_moneda = "",
                display = 1,
                folio = 1,
                formato_fecha = "",
                num_decimal = 1,
                path = "",
                puerto = 1,
                puerto2 = 1,
                puerto3 = 1,
                puerto4 = 1,
                rmto = "",
                scale = 1,
                tipo = 1
            });
        }
        static void InsertConfiguration(ENT_CONFIGURATION OBJ)
        {
            string query = string.Format("INSERT INTO configuracion (puerto,baudrate,puerto2,baudrate2,puerto3,baudrate3,puerto4,baudrate4,tipo,scale,formato_fecha,num_decimal,car_moneda,folio,display,aplicacion,path,rmto) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},'{10}',{11},'{12}',{13},{14},{15},'{16}','{17}')", OBJ.puerto,OBJ.baudrate,OBJ.puerto2, OBJ.baudrate2, OBJ.puerto3,OBJ.baudrate3,OBJ.puerto4,OBJ.baudrate4,OBJ.tipo, OBJ.scale, OBJ.formato_fecha, OBJ.num_decimal, OBJ.car_moneda, OBJ.folio, OBJ.display, OBJ.aplicacion, OBJ.path,OBJ.rmto);
            db = new DataAccesQuery();
            db.ExcetuteQuery(query);
        }

    }


    
}
