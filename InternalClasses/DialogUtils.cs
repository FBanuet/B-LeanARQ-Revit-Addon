using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEANarq.InternalClasses
{
    public class DialogUtils
    {

        public static string SelectFile()
        {
            var dialog = new OpenFileDialog()
            {
                DefaultExt = ".xlsx",
                Multiselect = false,

            };

            var result = dialog.ShowDialog();
            var filepath = dialog.FileName;
            return result != DialogResult.OK ? String.Empty : filepath;

        }
    }
}
