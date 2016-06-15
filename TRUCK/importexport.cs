using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace TRUCK
{
	/// <summary>
	/// Descripción breve de WINOUT.
	/// </summary>
	public class importexport
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private string renglon;
		private FileStream fi = null;
		string inum;
		string inom;
		string ipre;
		string itar;
		string iemp;
		string ifam;
		private int pos,n=0;
		private char cc = (char)9;
		private OleDbConnection imporconexion;
		private OleDbCommand imporcomando;
		private OleDbDataReader tb;





        /*WTF DID YOU SWSEA>.AY TO ME NIGGA?????????????*/
			





		public importexport(int opcion,int op)
		{	
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
		}
	
		public void importar(int op,System.Windows.Forms.StatusBar status)
		{			
			Global.MyDateShort = new DateTime(Global.year,Global.mes,Global.dia);
			int tama;
			
			string mod="";

			try
			{
				imporconexion = new OleDbConnection(Global.Conexion);
				imporcomando = new OleDbCommand();
				imporconexion.Open();
				DataSet dataset2 = new DataSet();
				
				OpenFileDialog dlgOpenFile = new OpenFileDialog();
				dlgOpenFile.ShowReadOnly = true;
				dlgOpenFile.InitialDirectory = Global.syspath + "\\data";
				if (op == 2)
				{
					dlgOpenFile.DefaultExt = "*.txt";
					dlgOpenFile.Filter = "Data files(*.TXT)|*.txt|All files(*.*)|*.*";
				}
				else
				{
					dlgOpenFile.DefaultExt = ".TXT";
					dlgOpenFile.Filter = "Data files(*.TXT)|*.txt|All files(*.*)|*.*";
				}				

				if(dlgOpenFile.ShowDialog() == DialogResult.OK)
				{
					string path = dlgOpenFile.FileName;
					if(dlgOpenFile.ReadOnlyChecked == true)
					{
						fi = (FileStream)dlgOpenFile.OpenFile();
					}
					else
					{						
						fi = new FileStream(path,FileMode.Open,FileAccess.ReadWrite);
					}					
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					StreamReader sr = new StreamReader(fi,System.Text.Encoding.Unicode);	
					sr.BaseStream.Seek(0,SeekOrigin.Begin);
					renglon = sr.ReadLine();
					int n_tab=0;
					for (int i=0;i<renglon.Length;i++)
					{						
						if (renglon.IndexOf(cc,i,1)>=0)n_tab++;
					}
					pos = 0;
					n=0;	
					sr.Close();
					fi.Close();
					fi = new FileStream(path,FileMode.Open,FileAccess.ReadWrite);
					sr = new StreamReader(fi,System.Text.Encoding.Unicode);
					sr.BaseStream.Seek(0,SeekOrigin.Begin);
					switch (op)
					{
						case 1:  //importar Productos
						{		
							mod= Global.M_Error[136,Global.idioma].ToString();
							OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From Articulos WHERE numemp = " + Global.nempresa.ToString() , imporconexion);
							OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
							imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
							imporDataAdapter.Fill(dataset2, "articulos");
							
							if (n_tab >= 4)
							{
								proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
								pro.Show();

								try
								{
									while ((renglon = sr.ReadLine()) != null)
									{
										tama = renglon.Length;
										importaprod(ref n,ref dataset2);
										status.Panels[1].Text =Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[135,Global.idioma].ToString();
										pro.UpdateProgress(tama,Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[135,Global.idioma].ToString());
									}
									MessageBox.Show(n.ToString() + " " + Global.M_Error[123,Global.idioma].ToString());
								}
								catch (OleDbException exdb)
								{
									string d=exdb.Message;
									MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
								}		
								pro.Close();								
							}
							else MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
							sr.Close();
							imporconexion.Close();
						}break;
						case 2: //importar Proveedores
						{		
							mod= Global.M_Error[132,Global.idioma].ToString();
							OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From proveedor WHERE numemp = " + Global.nempresa.ToString(), imporconexion);
							OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
							imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
							imporDataAdapter.Fill(dataset2, "proveedor");
						
							if (n_tab >= 2)
							{								
								proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
								pro.Show();
								try
								{
									while ((renglon = sr.ReadLine()) != null)
									{							
										tama = renglon.Length;
										importaprov(ref n,ref dataset2);
										status.Panels[1].Text = Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString();
										pro.UpdateProgress(tama,Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString());
									}
									MessageBox.Show(n.ToString() + " " + Global.M_Error[123,Global.idioma].ToString());
								}
								catch (OleDbException exdb)
								{
									string d=exdb.Message;
									MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
								}		
								pro.Close();
							}
							else MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
							sr.Close();
							imporconexion.Close();
						}break;
						case 3: //importar Clientes
						{
							mod= Global.M_Error[135,Global.idioma].ToString();
							OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From cliente WHERE numemp = " + Global.nempresa.ToString(), imporconexion);
							OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
							imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
							imporDataAdapter.Fill(dataset2, "cliente");
							//dataset2.Tables["cliente"].PrimaryKey = new DataColumn[] {dataset2.Tables["cliente"].Columns["numero"]}; 							
							if (n_tab >= 2)
							{
								proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
								pro.Show();
								try
								{
									while ((renglon = sr.ReadLine()) != null)
									{
										tama = renglon.Length;
										importacte(ref n,ref dataset2);
										status.Panels[1].Text = Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[137,Global.idioma].ToString();
										pro.UpdateProgress(tama,Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[137,Global.idioma].ToString());								
									}
									MessageBox.Show(n.ToString() + " " + Global.M_Error[123,Global.idioma].ToString());
								}
								catch (OleDbException exdb)
								{
									string c=exdb.Message;
									MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
								}
								pro.Close();
							}
							else MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
							sr.Close();
							imporconexion.Close();
						}break;
						case 4: //importar Transportista
						{		
							mod= Global.M_Error[130,Global.idioma].ToString();
							OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From transportistas WHERE numemp = " + Global.nempresa.ToString(), imporconexion);
							OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
							imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
							imporDataAdapter.Fill(dataset2, "transportistas");
						
							if (n_tab >= 2)
							{								
								proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
								pro.Show();
								try
								{
									while ((renglon = sr.ReadLine()) != null)
									{							
										tama = renglon.Length;
										importatran(ref n,ref dataset2);
										status.Panels[1].Text = Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString();
										pro.UpdateProgress(tama,Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString());
									}
									MessageBox.Show(n.ToString() + " " + Global.M_Error[123,Global.idioma].ToString());
								}
								catch (OleDbException exdb)
								{
									string d=exdb.Message;
									MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
								}		
								pro.Close();
							}
							else MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
							sr.Close();
							imporconexion.Close();
						}
                            break;



						case 5: //importar Vehiculo Tara
						{		
							mod= Global.M_Error[222,Global.idioma].ToString();
							OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From taras WHERE numemp = " + Global.nempresa.ToString(), imporconexion);
							OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
							imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
							imporDataAdapter.Fill(dataset2, "taras");
						
							if (n_tab >= 3)
							{								
								proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
								pro.Show();
								try
								{
									while ((renglon = sr.ReadLine()) != null)
									{							
										tama = renglon.Length;
										importatara(ref n,ref dataset2);
										status.Panels[1].Text = Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString();
										pro.UpdateProgress(tama,Global.M_Error[133,Global.idioma].ToString() + n + Global.M_Error[136,Global.idioma].ToString());
									}
									MessageBox.Show(n.ToString() + " " + Global.M_Error[123,Global.idioma].ToString());
								}
								catch (OleDbException exdb)
								{
									string d=exdb.Message;
									MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
								}		
								pro.Close();
							}
							else MessageBox.Show(Global.M_Error[306,Global.idioma]+ " " + mod+" "+Global.M_Error[307,Global.idioma]);
							sr.Close();
							imporconexion.Close();
						}
                            break;


                        case 6: //importar familia
                            {

                                mod = Global.M_Error[218, Global.idioma].ToString();
                                OleDbDataAdapter imporDataAdapter = new OleDbDataAdapter("Select * From familia WHERE numemp = " + Global.nempresa.ToString(), imporconexion);
                                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(imporDataAdapter);
                                imporDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                                imporDataAdapter.Fill(dataset2, "familia");

                                if (n_tab >= 2)
                                {
                                    proceso pro = new proceso(Convert.ToInt32(sr.BaseStream.Length));
                                    pro.Show();
                                    try
                                    {
                                        while ((renglon = sr.ReadLine()) != null)
                                        {
                                            tama = renglon.Length;
                                            importafam(ref n, ref dataset2);
                                            status.Panels[1].Text = Global.M_Error[133, Global.idioma].ToString() + n + Global.M_Error[136, Global.idioma].ToString();
                                            pro.UpdateProgress(tama, Global.M_Error[133, Global.idioma].ToString() + n + Global.M_Error[136, Global.idioma].ToString());
                                        }
                                        MessageBox.Show(n.ToString() + " " + Global.M_Error[123, Global.idioma].ToString());
                                    }
                                    catch (OleDbException exdb)
                                    {
                                        string d = exdb.Message;
                                        MessageBox.Show(Global.M_Error[306, Global.idioma] + " " + mod + " " + Global.M_Error[307, Global.idioma]);
                                    }
                                    pro.Close();
                                }
                                else MessageBox.Show(Global.M_Error[306, Global.idioma] + " " + mod + " " + Global.M_Error[307, Global.idioma]);
                                sr.Close();
                                imporconexion.Close();
                            } break;
					}					
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
			catch (Exception ex)
			{	
				MessageBox.Show(Global.M_Error[56,Global.idioma]);
				string d=ex.Message;
			}
            						
			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//

		}

		public void exportar(int op,System.Windows.Forms.StatusBar status)
		{
			Global.MyDateShort = new DateTime(Global.year,Global.mes,Global.dia);
			
			imporconexion = new OleDbConnection(Global.Conexion);
			imporcomando = new OleDbCommand();
			
			SaveFileDialog dlgOpenFile = new SaveFileDialog();
			dlgOpenFile.InitialDirectory = Global.syspath + "\\data";

			if (op == 2)
			{
				dlgOpenFile.DefaultExt = "*.txt";
				dlgOpenFile.Filter = "Data files(*.TXT)|*.txt|All files(*.*)|*.*";
			}
			else
			{
				dlgOpenFile.DefaultExt = ".TXT";
				dlgOpenFile.Filter = "Data files(*.TXT)|*.txt|All files(*.*)|*.*";
			}
			dlgOpenFile.FilterIndex = 2;
			dlgOpenFile.RestoreDirectory = true;

			try
			{
				if(dlgOpenFile.ShowDialog() == DialogResult.OK)
				{					
					if(dlgOpenFile.CreatePrompt == true)
					{						
						string path = dlgOpenFile.FileName;
						fi = new FileStream(path,FileMode.CreateNew,FileAccess.Write);
					}
					if(dlgOpenFile.OverwritePrompt == true)
					{
						string path = dlgOpenFile.FileName;
						fi = new FileStream(path,FileMode.Create,FileAccess.Write);
					}
					
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					StreamWriter sr = new StreamWriter(fi,System.Text.Encoding.Unicode);
					pos = 0;
					n=0;
					
					switch (op)
					{
						case 1:  // Exportar producto
						{	
							string sele = "SELECT numemp,numero,descripcion,familia,tarifa FROM Articulos WHERE numemp = " + Global.nempresa + " ORDER BY numero"; 
							imporcomando.CommandText = sele;
							imporcomando.Connection = imporconexion;
							imporconexion.Open();
							tb = imporcomando.ExecuteReader();
							while (tb.Read())
							{
								exportaprod(ref n,ref tb,ref sr);					
							}		
							tb.Close();
							sr.Close();
						}break;
						case 2: // Exportar Proveedor
						{	
							string sele = "SELECT numemp,numero,nombre FROM proveedor WHERE numemp = " + Global.nempresa + " ORDER BY numero";
							imporcomando.CommandText = sele;
							imporcomando.Connection = imporconexion;
							imporconexion.Open();
							tb = imporcomando.ExecuteReader();
							while (tb.Read())
							{
								exportadato(ref n,ref tb,ref sr);					
							}		
							tb.Close();
							sr.Close();
						}break;
						case 3:  // Export cliente
						{
							string sele = "SELECT numemp,numero,nombre FROM cliente WHERE numemp = " + Global.nempresa + " ORDER BY numero";
							imporcomando.CommandText = sele;
							imporcomando.Connection = imporconexion;
							imporconexion.Open();
							tb = imporcomando.ExecuteReader();
							while (tb.Read())
							{
								exportadato(ref n,ref tb,ref sr);					
							}	
							tb.Close();
							sr.Close();
						}break;
						case 4: // Exportar transportista
						{
							string sele = "SELECT numemp,numero,descripcion FROM transportistas WHERE numemp = " + Global.nempresa + " ORDER BY numero";
							imporcomando.CommandText = sele;
							imporcomando.Connection = imporconexion;
							imporconexion.Open();
							tb = imporcomando.ExecuteReader();
							while (tb.Read())
							{
								exportadato(ref n,ref tb,ref sr);					
							}
							tb.Close();
							sr.Close();
						}break;
						case 5:  // Exportar Taras
						{	
							string sele = "SELECT numemp,numero,descripcion,tara FROM Taras WHERE numemp = " + Global.nempresa + " ORDER BY numero"; 
							imporcomando.CommandText = sele;
							imporcomando.Connection = imporconexion;
							imporconexion.Open();
							tb = imporcomando.ExecuteReader();
							while (tb.Read())
							{
								exportatara(ref n,ref tb,ref sr);					
							}		
							tb.Close();
							sr.Close();
						}break;
                        case 6: // Exportar Familia
                            {
                                string sele = "SELECT numemp,familia,descripcion FROM familia WHERE numemp = " + Global.nempresa + " ORDER BY familia";
                                imporcomando.CommandText = sele;
                                imporcomando.Connection = imporconexion;
                                imporconexion.Open();
                                tb = imporcomando.ExecuteReader();
                                while (tb.Read())
                                {
                                    exportadato(ref n, ref tb, ref sr);
                                }
                                tb.Close();
                                sr.Close();
                            } break;
					}
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					MessageBox.Show(n.ToString() + Global.M_Error[123,Global.idioma].ToString());
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

						
			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>

		public bool Find_dato(string sele1 )
		{
			bool busca = false;

			OleDbCommand selecomando;
			OleDbDataReader finddatareader;

			try
			{	
				selecomando = new OleDbCommand(sele1,imporconexion);
				imporconexion.Open();
				finddatareader = selecomando.ExecuteReader();
				if (!finddatareader.Read())
				{
					busca = false;
				}
				else
				{
					busca = true;
				}
				finddatareader.Close();
				imporconexion.Close();
				return busca;
			}
			catch (Exception objExeption)
			{
				System.Diagnostics.EventLog.WriteEntry("ClaseGeneral",objExeption.Message,System.Diagnostics.EventLogEntryType.Error);
				throw objExeption;
				//return busca;
			}
		}

		private void importatara(ref int n, ref DataSet dataset2)
		{			
			int l_pos;
			if (renglon.Length > 0  && renglon.IndexOf(cc) > 0)
			{
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				iemp = renglon.Substring(0, pos);  // numero de empresa
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}
				
				inum = renglon.Substring(0, pos);   //munero placa
				renglon = renglon.Substring(pos + 1);                                            

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}

				inom = renglon.Substring(0, pos); //nombre
				renglon = renglon.Substring(pos + 1);
			
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else	pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}

				itar = renglon.Substring(0, pos);//tara
				renglon = "";
				
				if ( inum.Length > 0 && Global.nempresa > 0 )
				{
					DataRow[] rowFoundRow = dataset2.Tables["taras"].Select("numero = '" + inum + "' AND numemp = " + Global.nempresa.ToString());
					if (rowFoundRow.Length == 0) 
					{
						n++;
						string sele = "INSERT INTO taras (numemp,numero,descripcion,tara)"+
							" VALUES ( " + Global.nempresa + ",'" + inum+ "','" + inom + "','" + itar + "')";
						imporcomando.CommandText = sele;
						imporcomando.Connection = imporconexion;
						imporcomando.ExecuteNonQuery();
					}
				}
			}
		}

		private void importacte(ref int n,ref DataSet dataset2)
		{			
			int l_pos;

			if (renglon.Length > 6)
			{
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				iemp = renglon.Substring(0, pos);  // numero de empresa
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				inum = renglon.Substring(0, pos);  // numero de cliente
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
			
				inom = renglon.Substring(0, pos);  // descripcion de cliente
				renglon="";

				if ( Convert.ToInt32(inum) > 0 && Global.nempresa > 0 )
				{
					DataRow[] rowFoundRow = dataset2.Tables["cliente"].Select("numero = " + inum + " AND numemp = " + Global.nempresa.ToString());

					if (rowFoundRow.Length == 0) 
					{
						n++;
						string sele = "INSERT INTO cliente (numemp,numero,nombre)"+
							" VALUES ( " + Global.nempresa + "," + Convert.ToInt32(inum) + ",'" + inom + "')";
						imporcomando.CommandText = sele;
						imporcomando.Connection = imporconexion;
						imporcomando.ExecuteNonQuery();
					}
				}
			}
		}

		private void importatran(ref int n,ref DataSet dataset2)
		{			
			int l_pos;

			if (renglon.Length > 6)
			{
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				iemp = renglon.Substring(0, pos);  // numero de empresa
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				inum = renglon.Substring(0, pos);  // numero de transporte
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
			
				inom = renglon.Substring(0, pos);  // descripcion de trasnportista
				renglon = "";

				if ( Convert.ToInt32(inum) > 0 && Global.nempresa > 0 )
				{
					DataRow[] rowFoundRow = dataset2.Tables["transportistas"].Select("numero = " + inum + " AND numemp = " + Global.nempresa.ToString());

					if (rowFoundRow.Length == 0 ) 
					{
						n++;
						string sele = "INSERT INTO transportistas (numemp,numero,descripcion)"+
							" VALUES ( " + Global.nempresa + "," + Convert.ToInt32(inum) + ",'" + inom + "')";
						imporcomando.CommandText = sele;
						imporcomando.Connection = imporconexion;
						imporcomando.ExecuteNonQuery();
					}
				}
			}
		}
		private void importaprov(ref int n,ref DataSet dataset2)
		{			
			int l_pos;

			if (renglon.Length > 6)
			{
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				iemp = renglon.Substring(0, pos);  // numero de empresa
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				inum = renglon.Substring(0, pos);  // numero
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
			
				inom = renglon.Substring(0, pos);  // nombre
				renglon="";

				if ( Convert.ToInt32(inum) > 0 && Global.nempresa > 0 )
				{
					DataRow[] rowFoundRow = dataset2.Tables["proveedor"].Select("numero = " + inum + " AND numemp = " + Global.nempresa.ToString());

					if (rowFoundRow.Length == 0) 
					{
						n++;
						string sele = "INSERT INTO proveedor (numemp,numero,nombre)"+
							" VALUES ( " + Global.nempresa + "," + Convert.ToInt32(inum) + ",'" + inom + "')";
						imporcomando.CommandText = sele;
						imporcomando.Connection = imporconexion;
						imporcomando.ExecuteNonQuery();
					}
				}
			}
		}

        private void importafam(ref int n, ref DataSet dataset2)
        {
            int l_pos;

            if (renglon.Length > 6)
            {
                if (renglon.IndexOf(cc) <= 0)
                {
                    l_pos = renglon.IndexOf(cc);
                    if (l_pos == 0)
                    { pos = renglon.IndexOf(cc); }
                    else { pos = renglon.Length; }
                }
                else { pos = renglon.IndexOf(cc, 0); }

                iemp = renglon.Substring(0, pos);  // numero de empresa
                renglon = renglon.Substring(pos + 1);

                if (renglon.IndexOf(cc) <= 0)
                {
                    l_pos = renglon.IndexOf(cc);
                    if (l_pos == 0)
                    { pos = renglon.IndexOf(cc); }
                    else { pos = renglon.Length; }
                }
                else { pos = renglon.IndexOf(cc, 0); }

                inum = renglon.Substring(0, pos);  // numero
                renglon = renglon.Substring(pos + 1);

                if (renglon.IndexOf(cc) <= 0)
                {
                    l_pos = renglon.IndexOf(cc);
                    if (l_pos == 0)
                    { pos = renglon.IndexOf(cc); }
                    else { pos = renglon.Length; }
                }
                else { pos = renglon.IndexOf(cc, 0); }

                inom = renglon.Substring(0, pos);  // nombre
                renglon = "";

                if (Convert.ToInt32(inum) > 0 && Global.nempresa > 0)
                {
                    DataRow[] rowFoundRow = dataset2.Tables["familia"].Select("familia = " + inum + " AND numemp = " + Global.nempresa.ToString());

                    if (rowFoundRow.Length == 0)
                    {
                        n++;
                        string sele = "INSERT INTO familia (numemp,familia,descripcion)" +
                            " VALUES ( " + Global.nempresa + "," + Convert.ToInt32(inum) + ",'" + inom + "')";
                        imporcomando.CommandText = sele;
                        imporcomando.Connection = imporconexion;
                        imporcomando.ExecuteNonQuery();
                    }
                }
            }
        }
		private void importaprod(ref int n,ref DataSet dataset2)
		{
			int l_pos;
			
			if (renglon.Length > 5)
			{
				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)
					{pos = renglon.IndexOf(cc);}
					else{pos =renglon.Length;}
				}
				else { pos = renglon.IndexOf(cc,0);}
		    
				iemp = renglon.Substring(0, pos);  // numero de empresa
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}
           
				inum = renglon.Substring(0, pos);  // numero de producto
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}
           
				inom = renglon.Substring(0, pos);  //descripcion del producto
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0)pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}
           
				ifam = renglon.Substring(0, pos);  // familia del producto
				renglon = renglon.Substring(pos + 1);

				if(renglon.IndexOf(cc) <= 0)
				{
					l_pos = renglon.IndexOf(cc);
					if (l_pos == 0) pos = renglon.IndexOf(cc);
					else pos =renglon.Length;
				}
				else { pos = renglon.IndexOf(cc,0);}
            
				ipre = renglon.Substring(0, pos);  //precio del producto
				renglon = "";
				if ( Convert.ToInt32(inum) > 0 && Global.nempresa > 0 )
				{
					DataRow[] rowFoundRow = dataset2.Tables["articulos"].Select("numero = " + inum + " AND numemp = " + Global.nempresa.ToString());
					if (rowFoundRow.Length == 0 ) 
					{
						n++;
						string sele = "INSERT INTO articulos (numemp,numero,descripcion,tarifa,familia)"+
							" VALUES ( " + Global.nempresa + "," + Convert.ToInt32(inum) + ",'" + inom + "'," + Convert.ToInt32(ipre) + "," + Convert.ToInt32(ifam) + ")";
						imporcomando.CommandText = sele;
						imporcomando.Connection = imporconexion;
						imporcomando.ExecuteNonQuery();
					}
					else
					{
						MessageBox.Show(rowFoundRow[0]["numero"]+","+Global.M_Error[111,Global.idioma].ToString());
					}
				}
			}	
		}

		private void exportadato(ref int n,ref OleDbDataReader tb,ref StreamWriter sr )
		{
			iemp = tb.GetInt16(0).ToString() + (char)9;
			inum = tb.GetInt32(1).ToString() + (char)9;
			inom = tb.GetString(2) + (char)9;
			sr.WriteLine(iemp + inum + inom);
			n++;
		}
		
		private void exportaprod(ref int n,ref OleDbDataReader tb,ref StreamWriter sr )
		{
			iemp = tb.GetInt16(0).ToString() + cc; //numero de empresa
			inum = tb.GetInt32(1).ToString() + cc;  //numero del producto
			inom = tb.GetString(2) + cc;       //nombre del producto
			ipre = tb.GetInt32(3).ToString() + cc;  //precio del producto
			ifam = tb.GetInt32(4).ToString() + cc;	//familia del producto
			sr.WriteLine(iemp + inum + inom + ifam + ipre);
			n++;
		}	
		
		private void exportatara(ref int n,ref OleDbDataReader tb,ref StreamWriter sr )
		{
			iemp = tb.GetInt16(0).ToString() + (char)9;
			inum = tb.GetString(1).ToString() + (char)9;
			inom = tb.GetString(2) + (char)9;
			itar = tb.GetString(3) + (char)9;
			sr.WriteLine(iemp + inum + inom + itar);
			n++;
		}

		
	}
}
