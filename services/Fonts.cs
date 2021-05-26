using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.services
{
    abstract class Fonts
    {

        private static PrivateFontCollection pfc;

        public static void initFonts() 
        {
            pfc = new PrivateFontCollection();
            addFontFamilly(Properties.Resources.SuisseIntl_Bold, ref pfc);
            addFontFamilly(Properties.Resources.SuisseIntl_Book, ref pfc);
            addFontFamilly(Properties.Resources.SuisseIntl_Medium, ref pfc);
            addFontFamilly(Properties.Resources.SuisseIntl_Regular, ref pfc);
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private static void addFontFamilly(byte[] fontdata, ref PrivateFontCollection pfc)
        {
            // Taille du fichier police
            int fontLength = fontdata.Length;

            // Création d'un bloc mémoire pour le fichier police
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // Copie des bits du fichier police dans le bloc mémoire
            Marshal.Copy(fontdata, 0, data, fontLength);

            // Bug .NET, ligne obligatoire pour que ça fonctionne correctement :
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            // Ajout de la police à la collection
            pfc.AddMemoryFont(data, fontLength);

            // Suppression du bloc mémoire
            Marshal.FreeCoTaskMem(data);
        }

        public static FontFamily bold
        {
            get { return pfc.Families[1]; }
        }

        public static FontFamily book
        {
            get { return pfc.Families[2]; }
        }

        public static FontFamily medium
        {
            get { return pfc.Families[3]; }
        }

        public static FontFamily regular
        {
            get { return pfc.Families[0]; }
        }

    }
}
