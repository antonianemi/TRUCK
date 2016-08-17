using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace TRUCK
{
    class Comunica
    {
        public bool inicia(ref SerialPort S_RS232, int puerto, int baud, ref string mensaje)

        {


            try
            {
                if (S_RS232.IsOpen) S_RS232.Close();
                S_RS232.BaudRate = Convert.ToInt32(Global.velocidad[baud]);
                S_RS232.PortName = Global.port[puerto].ToString();  // "COM" + puerto.ToString();
                S_RS232.Parity = System.IO.Ports.Parity.None;
                S_RS232.StopBits = System.IO.Ports.StopBits.One;
                S_RS232.DataBits = 8;
                S_RS232.Handshake = System.IO.Ports.Handshake.None;
                S_RS232.ReadTimeout = 1000;
                S_RS232.WriteTimeout = 1000;
                S_RS232.Open();
                mensaje = "";
                return true;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            catch (System.IO.IOException e)
            {
                Console.Write(e.Message);
                return false;
            }
            catch (System.ArgumentOutOfRangeException ea)
            {
                Console.Write(ea.Message);
                return false;
            }
            
        }

        public void SendData(ref SerialPort S_RS232, ref string mensaje, string dato)
        {
            try
            {
                S_RS232.Write(dato);
                if (!Global.display) mensaje = "";
            }
            catch (System.NullReferenceException en)
            {
                Termino(ref S_RS232);
                System.Console.Write(en.Message);
            }
            catch (System.IO.IOException e)
            {
                Termino(ref S_RS232);
                System.Console.Write(e.Message);
            }
            catch (System.InvalidOperationException eo)
            {
                Termino(ref S_RS232);
                System.Console.Write(eo.Message);
            }
        }
             
        public void Termino(ref SerialPort S_RS232)
        {
            try
            {
                if (S_RS232.IsOpen)
                {
                    S_RS232.Close();
                    S_RS232 = null;
                }
                S_RS232.Dispose();
                S_RS232 = null;
            }
            catch (System.IO.IOException eO)
            {
                Console.Write(eO.Message);
            }
            catch (System.InvalidOperationException ei)
            {
                Console.Write(ei.Message);
            }
            catch (System.ArgumentNullException ea)
            {
                Console.Write(ea.Message);
            }
            catch (System.NullReferenceException e)
            {
                Console.Write(e.Message);
            }
        }



        public string obtiene_peso(string txt_peso)
        {
            if (Global.aplicacion != 2)
            {
                if (txt_peso.IndexOf(Global.M_Error[258, Global.idioma].ToUpper()) >= 0 || txt_peso.IndexOf(Global.M_Error[262, Global.idioma].ToUpper()) >= 0)
                {
                    int pos = txt_peso.IndexOf(":") + 1;
                    txt_peso = txt_peso.Substring(pos).Trim();
                    int ult = txt_peso.IndexOf((char)32);
                    return txt_peso.Substring(0, ult);
                }
                else
                {
                    if (txt_peso.IndexOf(":") >= 0)
                    {
                        int pos = txt_peso.IndexOf(":") + 1;
                        txt_peso = txt_peso.Substring(pos).Trim();
                        int ult = txt_peso.IndexOf((char)32);
                        return txt_peso.Substring(0, ult);
                    }
                    else return "";
                   /* else
                    {
                        txt_peso = txt_peso.Trim();
                        int ult = txt_peso.IndexOf((char)32);
                        if (ult > 0) return txt_peso.Substring(0, ult);
                        else return txt_peso;
                    }*/
                }
            }
            else return txt_peso;
        }



        public string obtiene_um(string txt_um)
        {
            char[] c = new char[]{'Z','M'};
            if (Global.aplicacion != 2)
            {
                if (txt_um.IndexOf(Global.M_Error[258, Global.idioma].ToUpper()) >= 0 || txt_um.IndexOf(Global.M_Error[262, Global.idioma].ToUpper()) >= 0)
                {
                    int pos = txt_um.IndexOf(":") + 1;
                    txt_um = txt_um.Substring(pos).Trim();
                    pos = txt_um.IndexOf((char)32) + 1;
                    txt_um = txt_um.Substring(pos).Trim();
                    int ult = txt_um.IndexOfAny(c);
                    if (ult > 0) return txt_um.Substring(0, ult);
                    else return txt_um.Substring(0);
                }
                else
                {
                    if (txt_um.IndexOf(":") >= 0)
                    {
                        int pos = txt_um.IndexOf(":") + 1;
                        txt_um = txt_um.Substring(pos).Trim();
                        pos = txt_um.IndexOf((char)32) + 1;
                        txt_um = txt_um.Substring(pos).Trim();
                        int ult = txt_um.IndexOfAny(c);
                        if (ult > 0) return txt_um.Substring(0, ult);
                        else return txt_um.Substring(0);
                    }
                    else return "";
                    /*{
                        txt_um = txt_um.Trim();
                        int pos = txt_um.IndexOf((char)32) + 1;
                        if (pos > 0) txt_um = txt_um.Substring(pos).Trim();
                        int ult = txt_um.IndexOfAny(c);
                        if (ult > 0) return txt_um.Substring(0, ult);
                        else return txt_um; 
                    }*/
                }
            }
            else return txt_um;
        }
    }
}
