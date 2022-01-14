using BackupSqlDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoreAndBackupSqlDatabase
{
    public partial class Mainfrm : Form
    {
        public Mainfrm()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace("/", "-");

            mySaveDialog.DefaultExt = "BAK";
           mySaveDialog.FileName = "BackupFile-Date-" + datetime.Replace(":", "-");
           mySaveDialog.Filter = @"SQL Backup files (*.BAK) |*.BAK|All files (*.*) |*.*";
           mySaveDialog.FilterIndex = 1;
           mySaveDialog.OverwritePrompt = true;
           mySaveDialog.Title = "Backup SQL File";

            if (mySaveDialog.ShowDialog() == DialogResult.OK)
            {
                string strFileName = mySaveDialog.FileName;

                string check = SQL2019Backup.BackupSQL2019(strFileName, "SamanInsurance");
                if (check == "OK")
                {
                    MessageBox.Show("پشتیبانی پایگاه داده در مسیر مورد نظر با موفقیت انجام شد"
                        , "پیام موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("پشتیبانی پایگاه داده با خطا مواجه شد"
                       , "پیام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
