using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshEkran.Classlar
{
    public class Metotlar
    {
        public static void Ok(string Msj, string Title = "Ok...")
        {
            MessageBox.Show(Msj, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void No(string Msj, string Title = "No...")
        {
            MessageBox.Show(Msj, Title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult QuestionMesaj(string Msj, string Title = "Ok...")
        {
            return MessageBox.Show(Msj, Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
