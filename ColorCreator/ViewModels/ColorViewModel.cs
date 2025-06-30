using ColorCreator.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
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

        public ObservableCollection<ItemColor> Items { get; } =
                new ObservableCollection<ItemColor>();

        private ItemColor _selectedColor;
        public ItemColor SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand =
                    new RelayCommand
                    (
                        obj =>
                        {
                            _AddColor(Alpha, Red, Green, Blue);

                            OnPropertyChanged();
                        },
                        obj =>
                        {
                            return !_ColorExist(Alpha, Red, Green, Blue);
                        }
                    ));
            }
        }

        private RelayCommand _removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand =
                   new RelayCommand
                    (
                        obj =>
                        {
                            Items.Remove(SelectedColor);

                            OnPropertyChanged();
                        },
                        obj =>
                        {
                            return SelectedColor != null;
                        }
                    ));
            }
        }

        private void _AddColor(byte Alpha, byte Red, byte Green, byte Blue)
        {

            Items.Add(new ItemColor
            {
                Alpha = Alpha,
                Red = Red,
                Green = Green,
                Blue = Blue
            });
        }
        private bool _ColorExist(byte Alpha, byte Red, byte Green, byte Blue )
        {
            ItemColor color = new ItemColor()
            {
                Alpha = Alpha,
                Red = Red,
                Green = Green,
                Blue = Blue
            };

            foreach (var item in Items)
            {
                if(item.ActualColor == color.ActualColor)
                    return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}