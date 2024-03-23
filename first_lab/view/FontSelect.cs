using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_lab.view
{
    public class FontSelect : IFontSelect
    {
        public Font SelectFont()
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult result = fontDialog.ShowDialog();

            // Применяем выбранный шрифт к RichTextBox
            if (result == DialogResult.OK)
            {
                return fontDialog.Font;
            }
            return null;
        }
    }

}
