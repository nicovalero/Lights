using DataStorage.Models.Interfaces;
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

        public static bool Save(ILinkSaveObject saveObject)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "mle files (*.mle)|*.mle|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string content = saveObject.JsonContent;
                string fileName = dialog.FileName;
                File.WriteAllText(fileName, content);
            }

            return true;
        }

        public static string Read()
        {
            string content = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mle files (*.mle)|*.mle|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using(StreamReader sr = new StreamReader(dialog.OpenFile()))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }
    }
}
