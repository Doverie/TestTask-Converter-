using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProgramLogic;

namespace TestProgramWinForms
{
    public partial class WinFormUI : Form
    {
        public WinFormUI()
        {
            InitializeComponent();
        }

        private void ButtonSourcePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select Source Path";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sourcePath.Text = fbd.SelectedPath;
            }
        }

        private void ButtonTargetPath_Click(object sender, EventArgs e)
        {
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.Description = "Select Target Path";
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    targetPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bool isIt = false;
            try
            {
                FileConverterService logic = new FileConverterService();
                logic.FillModels(@sourcePath.Text, @targetPath.Text);
                ErrorMessage.Text = "Successful";
                isIt = true;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (!isIt)
                {
                    ErrorMessage.Text = "Something went wrong";
                }
            }
        }
        }
}
