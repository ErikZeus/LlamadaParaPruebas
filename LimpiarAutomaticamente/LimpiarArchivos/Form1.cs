using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LimpiarArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
                System.IO.DirectoryInfo dinfo = null;
              string path = System.Configuration.ConfigurationSettings.AppSettings["borrar"];
            try
                {
                    dinfo = new System.IO.DirectoryInfo(path);
                }
                catch { return; /* If there is error, it's cause the dir doesn't exist or cause of security issues */ }

                System.IO.DirectoryInfo[] dinfo_folders = dinfo.GetDirectories();

                for (int i = 0; i < dinfo_folders.Length; i++)
                {
                    File.Delete(dinfo_folders[i].FullName);
                }

                System.IO.FileInfo[] dinfo_files = dinfo.GetFiles();

                for (int i = 0; i < dinfo_files.Length; i++)
                {
                    if (dinfo_files[i].Name.ToLower().EndsWith(".xml") || dinfo_files[i].Name.ToLower().EndsWith(".eob"))
                    {
                        try
                        {
                            System.IO.File.Delete(dinfo_files[i].FullName);
                        }
                        catch { /* File either doesn't exists, or got security issues */ }
                    }
                }
            }
      
    }
}
