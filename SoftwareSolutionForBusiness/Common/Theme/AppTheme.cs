using System.Drawing;

namespace SoftwareSolutionForBusiness.Common.Theme
{
    public static class AppTheme
    {
        public static string FontFamily = "Gabriola";
        public static Font SmallFont = new Font(FontFamily, 9);
        public static Font MiddleFont = new Font(FontFamily, 12);
        public static Font BigFont = new Font(FontFamily, 15);
        public static Color Background = ColorTranslator.FromHtml("#FFFFFF");
        public static Color ControlBackground = ColorTranslator.FromHtml("#CEFFF9");
        public static Color ActiveBackground = ColorTranslator.FromHtml("#00CC76");
        public static Color NegativeBackground = Color.MistyRose;
    }
}
