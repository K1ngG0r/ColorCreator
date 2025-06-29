using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ColorCreator
{
    public class ColorViewModel :INotifyPropertyChanged
    {

        //Цвета и их свойства
        private byte _alpha = 255;
        public byte Alpha
        {
            get => _alpha;
            set { _alpha = value; UpdatePreview(); OnPropertyChanged(); }
        }

        private byte _red = 0;
        public byte Red
        {
            get => _red;
            set { _red = value; UpdatePreview(); OnPropertyChanged(); }
        }

        private byte _green = 0;
        public byte Green
        {
            get => _green;
            set { _green = value; UpdatePreview(); OnPropertyChanged(); }
        }

        private byte _blue = 0;
        public byte Blue
        {
            get => _blue;
            set { _blue = value; UpdatePreview(); OnPropertyChanged(); }
        }

        //Временный цвет
        private SolidColorBrush _previewBrush = Brushes.Black;
        public SolidColorBrush PreviewBrush
        {
            get => _previewBrush;
            set { _previewBrush = value; OnPropertyChanged(); }
        }
        private void UpdatePreview()
        {
            var color = Color.FromArgb(Alpha, Red, Green, Blue);
            PreviewBrush = new SolidColorBrush(color);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}