using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjeArchivos
{
    public partial class AndresEjemploArchivos : Form
    {
        public AndresEjemploArchivos()
        {
            InitializeComponent();
        }

        //se invoca cuando el osuario oprime una tecla
        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            //determina si el usuario opimio la tecla enter

            if (e.KeyCode == Keys.Enter) {
                string name; // nombre del archivo

                //obtiene el archivo o directorio especifico por el usuario

                name = txtEntrada.Text;

                //determina si name es un archivo
                if (File.Exists(name))
                {
                    //obtiene la dfecha de creacion del archivo
                    // su fecha de modificaciont etc
                    txtSalida.Text = obtenerInformacion(name);


                    try
                    {
                        //OBTIENE LECTOR Y CONTENIDO DEL ARCHIVO
                        StreamReader sr = new StreamReader(name);
                        txtSalida.Text += sr.ReadToEnd();
                    }
                    //maneja exception si StreamReader no esta disponible
                    catch (IOException)
                    {
                        MessageBox.Show("Error al leer el archivo", "Error de archivo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                //determina si name es un directorio
                else if (Directory.Exists(name))
                {
                    string[] listaDirectorio; //arreglo para los directorios
                                              //obtiene la dfecha de creacion del archivo
                                              // su fecha de modificaciont etc
                    txtSalida.Text = obtenerInformacion(name);
                    //obtener la lista de los archivos/directorios del directorio especificado
                    listaDirectorio = Directory.GetDirectories(name);

                    txtSalida.Text += "\r\n\r\nContenido del directorio: \r\n";
                    //imprime en pantalla el contenido de la listaDirectorios

                    for (int i = 0; i < listaDirectorio.Length; i++)
                    {
                        txtSalida.Text += listaDirectorio[i] + "\r\n";
                    }

                }
                else {
                    //notific al usuario que no existe el directorio del archivo
                    MessageBox.Show(txtEntrada.Text + " no existe", "Error de archivo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


        }
        //obtiene informacion sobre el archivo o directorio
        private string obtenerInformacion(string name)
        {
            String informacion;

            // imprime mensaje indicando que existe el archivo o directorio
            informacion = name + " Existe\r\n\r\n";

            //imprime en pantalla la fecha de modificacion del archivo o directorio
            informacion += "Modificacion ultima: " + File.GetLastWriteTime(name) + "\r\n";

            //imprime en pantalla la fecha y hora de creacion del archivo o directorio
            informacion += "Creacion: " + File.GetCreationTime(name) + "\r\n";

            //imprime en pantalla el ultimo acceso del archivo o directorio
            informacion += "Ultimo acceso: " + File.GetLastAccessTime(name) + "\r\n";

            return informacion;


        }
    }
}
