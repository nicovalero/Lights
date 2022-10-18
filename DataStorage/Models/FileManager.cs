using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStorage.Models
{
    public static class FileManager
    {

        public static bool Save(string content)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "mlef files (*.mlef)|*.mlef|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                File.WriteAllText(fileName, content);
            }

            return true;
        }
    }
}
