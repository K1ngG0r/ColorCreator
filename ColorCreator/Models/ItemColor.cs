using System.Windows.Media;

namespace ColorCreator.Models
{
    public class ItemColor
    {
        public byte Alpha {  get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }  

        public Color ActualColor =>
            Color.FromArgb(Alpha, Red, Green, Blue);

        public string HexCode =>ActualColor.ToString();
    }
}
