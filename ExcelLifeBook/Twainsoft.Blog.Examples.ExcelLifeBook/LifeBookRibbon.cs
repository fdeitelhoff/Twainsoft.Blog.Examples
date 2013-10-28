using Microsoft.Office.Tools.Ribbon;

namespace Twainsoft.DNP.Articles.ExcelLifeBook
{
    public partial class LifeBookRibbon
    {
        private void LifeBookRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void CreateLifeBook_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.LifeBook.CreateLifeBook();
        }
    }
}
