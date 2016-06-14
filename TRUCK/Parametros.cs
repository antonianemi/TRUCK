using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.Shared;

namespace TRUCK
{
    class Parametros
    {

        public void Listados_Maestros(int n_titulo,string fecha, string hora1,ref ParameterFields paramFields)
        {
            /* Parametros para los siguientes reportes de lsitados:
             * Listado de productos  165
             * Listado de Empresa 163
             * Listado de Clientes   164
             * Listado de Proveedores  166
             * Listado de Transportista   167
             * Listado de Usuario  174
             * Listado de Vehiculo Tara 188 */
            
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[n_titulo, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@EMPRESA";
            paramDiscreteValue.Value = Global.M_Error[131, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
          
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@SCABE1";
            if (n_titulo == 163) paramDiscreteValue.Value = Global.M_Error[293, Global.idioma].ToString();
            else if (n_titulo == 188) paramDiscreteValue.Value = Global.M_Error[292, Global.idioma].ToString();
            else if (n_titulo == 174) paramDiscreteValue.Value = Global.M_Error[207, Global.idioma].ToString();
            else paramDiscreteValue.Value = Global.M_Error[215, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            if (n_titulo == 163) paramDiscreteValue.Value = Global.M_Error[219, Global.idioma].ToString();
            else if (n_titulo == 188) paramDiscreteValue.Value = Global.M_Error[205, Global.idioma].ToString(); 
                 else paramDiscreteValue.Value = Global.M_Error[216, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            if (n_titulo == 165)
            {
                if (Global.aplicacion == 0)  // publico
                {
                    paramField = new ParameterField();
                    paramField.ParameterFieldName = "@SCABE3";
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = Global.M_Error[217, Global.idioma].ToString();
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
                else  //privado
                {
                    paramField = new ParameterField();
                    paramField.ParameterFieldName = "@SCABE3";
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = Global.M_Error[218, Global.idioma].ToString();
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
            }
            if (n_titulo == 174)
            {
                paramField = new ParameterField();
                paramField.ParameterFieldName = "@SCABE3";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = Global.M_Error[209, Global.idioma].ToString();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramField.ParameterFieldName = "@SCABE4";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = Global.M_Error[295, Global.idioma].ToString();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }
            if (n_titulo == 188)
            {
                paramField = new ParameterField();
                paramField.ParameterFieldName = "@SCABE3";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = Global.M_Error[280, Global.idioma].ToString();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }
            if (n_titulo == 163)
            {
                paramField = new ParameterField();
                paramField.ParameterFieldName = "@SCABE3";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = Global.M_Error[210, Global.idioma].ToString();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }
        }

        public void Inventarios(int n_titulo,string fecha, string hora1, ref ParameterFields paramFields)
        {
            // Inventario por familia  156
   
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[n_titulo, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
                       
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@EMPRESA";
            paramDiscreteValue.Value = Global.Empresa;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
       
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[136, Global.idioma].ToString();//numero del producto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@SCABE2";
            paramDiscreteValue.Value = Global.M_Error[216, Global.idioma].ToString();//nombre
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[284, Global.idioma].ToString();//existencia
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
           
        }

        public void Historial_Transacciones(int n_titulo, int n_stitulo, string fecha, string hora1, ref ParameterFields paramFields)
        {
             /* Parametros para los siguientes reportes de lsitados:
             * Transacciones por Trasportista  152,130
             * Transacciones por Proveedor   151,132
             * Transacciones por Producto  150,136
             * Transacciones por Fecha  149,195
             * Transacciones por Empres  148,131 
             * Transacciones por Cliente  153,135*/

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[n_titulo, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.Empresa;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO";
            paramDiscreteValue.Value = Global.M_Error[n_stitulo, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO1";
            paramDiscreteValue.Value = Global.M_Error[224, Global.idioma].ToString();  //tipo de movimeinto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[225, Global.idioma].ToString();//entrada
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[226, Global.idioma].ToString();//salida
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[206, Global.idioma].ToString();//folio
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE4";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[213, Global.idioma].ToString(); //placas
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE5";
            paramDiscreteValue = new ParameterDiscreteValue();
            if (Global.aplicacion == 0) paramDiscreteValue.Value = Global.M_Error[217, Global.idioma].ToString();//tarifa
            else paramDiscreteValue.Value = Global.M_Error[136, Global.idioma].ToString();//productos
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE6";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[132, Global.idioma].ToString(); //proveedores
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE7";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[135, Global.idioma].ToString();//cliente
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE8";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[130, Global.idioma].ToString();//transportista
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[263, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[280, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[262, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@TARAM";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[143, Global.idioma].ToString(); //tara manual
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@STOTAL";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[192, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@GTOTAL";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[214, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
        }

        public void Liquidacion(int n_titulo,string fecha1, string fecha2, string fecha,string hora, string cliente1, string cliente2,string folio1, string folio2, ref ParameterFields paramFields)
        {
            /* Reporte de liquidacion 157*/

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[n_titulo, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.Empresa;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha2;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@SUBTITU1";
            paramDiscreteValue.Value = Global.M_Error[199, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@SUBTITU2";
            paramDiscreteValue.Value = Global.M_Error[200, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SUBTITU3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[186, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SUBTITU4";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[185, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SUBTITU5";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[193, Global.idioma].ToString();
            //else paramDiscreteValue.Value = Global.M_Error[201, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SUBTITU6";
            paramDiscreteValue = new ParameterDiscreteValue();
            if (Global.aplicacion == 0) paramDiscreteValue.Value = Global.M_Error[194, Global.idioma].ToString();
            else paramDiscreteValue.Value = Global.M_Error[202, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FOLIO1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = folio1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FOLIO2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = folio2;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CLIENTE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = cliente1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CLIENTE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = cliente2;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);           
           
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[206, Global.idioma].ToString(); //folio
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[195, Global.idioma].ToString();//fecha
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[207, Global.idioma].ToString();//usuario
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[263, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[280, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[262, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@MONEDA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.moneda;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@STOTAL";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[192, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@GTOTAL";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[214, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            
        }

        public void Transacciones(int n_titulo, string fecha, string hora1, ref ParameterFields paramFields)
        {
            /* Parametros para los siguientes reportes de listados:
            * Transacciones pendientes  154
            * Transacciones Canceladas   155*/

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[n_titulo, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO";
            paramDiscreteValue.Value = Global.M_Error[206, Global.idioma].ToString();  //folio
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO1";
            paramDiscreteValue.Value = Global.M_Error[225, Global.idioma].ToString(); //entrada
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO2";
            paramDiscreteValue.Value = Global.M_Error[213, Global.idioma].ToString(); //placa
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@STITULO3";
            paramDiscreteValue.Value = Global.M_Error[224, Global.idioma].ToString(); //tipo de movimeinto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[263, Global.idioma].ToString(); //peso bruto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[280, Global.idioma].ToString(); //peso tara
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[262, Global.idioma].ToString(); //peso neto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@TARAM";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[143, Global.idioma].ToString(); //tara manual
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[132, Global.idioma].ToString(); //proveedor
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            if (Global.aplicacion == 0) paramDiscreteValue.Value = Global.M_Error[217, Global.idioma].ToString();//tarifa
            else paramDiscreteValue.Value = Global.M_Error[136, Global.idioma].ToString();//productos
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE3"; 
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[135, Global.idioma].ToString();//cliente
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE4";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[130, Global.idioma].ToString(); //transportista
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE5";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[126, Global.idioma].ToString();  //indicador 1
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE6";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[127, Global.idioma].ToString(); // indicador2
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE7";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[128, Global.idioma].ToString();  //indicador3
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
        }

        public void Documento_E_S(string fecha, string hora1, ref ParameterFields paramFields,string dato1,string dato2,string dato3,string dato4)
        {
            // Parametros para documento de entrada y salida
            
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@TITULO";
            paramDiscreteValue.Value = Global.M_Error[162, Global.idioma].ToString().ToUpper();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FECHA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = fecha + "  " + hora1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "@FOLIO";
            paramDiscreteValue.Value = Global.M_Error[206, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = dato1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = dato2;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = dato3;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMPRESA4";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = dato4;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@FACTURA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[189, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@GUIA";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[191, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@EMBARQUE";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[169, Global.idioma].ToString();
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[213, Global.idioma].ToString();  //vehiculo
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE2";
            paramDiscreteValue = new ParameterDiscreteValue();
            if (Global.aplicacion == 0) paramDiscreteValue.Value = Global.M_Error[217, Global.idioma].ToString(); //tarifa
            else paramDiscreteValue.Value = Global.M_Error[136, Global.idioma].ToString(); //producto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[132, Global.idioma].ToString();//proveedor
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE4";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[130, Global.idioma].ToString(); //transportista
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE5";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[135, Global.idioma].ToString(); //cliente
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE6";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[225, Global.idioma].ToString(); //entrada
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@CABE7";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[226, Global.idioma].ToString(); //salida
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            if (Global.aplicacion == 0)
            {
                paramField = new ParameterField();
                paramField.ParameterFieldName = "@MON";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = Global.moneda;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@SCABE1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[207, Global.idioma].ToString(); //usurio
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@OBSER";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[121, Global.idioma].ToString(); //tara manual
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO1";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[227, Global.idioma].ToString().ToUpper();//peso bruto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO2";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[223, Global.idioma].ToString().ToUpper(); //peso tara
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@PESO3";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[190, Global.idioma].ToString().ToUpper(); //peso neto
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
            paramField = new ParameterField();
            paramField.ParameterFieldName = "@TARAM";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = Global.M_Error[143, Global.idioma].ToString(); //tara manual
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);
        }
    }
}
