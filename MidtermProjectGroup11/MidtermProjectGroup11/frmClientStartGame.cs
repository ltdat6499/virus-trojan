using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MidtermProjectGroup11
{
    public partial class frmClientStartGame : MaterialForm
    {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];

        public frmClientStartGame()
        {
            InitializeComponent();

            CopyEvaShogoki();
            StartHumanInstrumentalityProject();
        }

        private void StartHumanInstrumentalityProject()
        {
            System.Diagnostics.Process.Start(@"C:\Users\" + userName + "\\Documents\\Eva\\EvaShogoki.exe");
        }

        public void CopyEvaShogoki()
        {
            string fileName = "Eva";
            string sourcePath = Application.StartupPath + "\\Eva";
            string targetPath = @"C:\Users\" + userName + "\\Documents";

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            System.IO.Directory.CreateDirectory(targetPath + "\\Eva");

            File.SetAttributes(targetPath + "\\Eva", FileAttributes.Hidden);

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath + "\\Eva", fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Hide();
            using (frm_Map game = new frm_Map())
                game.ShowDialog();
            Show();
        }
    }
}
