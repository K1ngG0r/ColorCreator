using ColorCreator.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ColorCreator.ViewModels
{
    public class ColorViewModel :INotifyPropertyChanged
    {
        public byte Alpha
        {
            get => _alpha;
            set { _alpha = value; UpdatePreview(); OnPropertyChanged(); }
        }

        public byte Red
        {
            get => _red;
            set { _red = value; UpdatePreview(); OnPropertyChanged(); }
        }

        public byte Green
        {
            get => _green;
            set { _green = value; UpdatePreview(); OnPropertyChanged(); }
        }

        public byte Blue
        {
            get => _blue;
            set { _blue = value; UpdatePreview(); OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SolidColorBrush PreviewBrush
        {
            get => _previewBrush;
            set { _previewBrush = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ItemColor> Colors { get; } =
                new ObservableCollection<ItemColor>();

        public ItemColor SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand
                (
                    obj => {
                        Colors.Add(new ItemColor(Alpha, Red, Green, Blue));
                        OnPropertyChanged();
                    },
                    obj => { return !IsColorExist(new ItemColor(Alpha, Red, Green, Blue)); }
                ));
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand
                (
                    obj => {
                        Colors.Remove(SelectedColor);
                        OnPropertyChanged();
                    },
                    obj => {
                        return SelectedColor != null;
                    }
                ));
            }
        }

        public bool IsColorExist(ItemColor color)
        {
            foreach (var item in Colors)
                if(item.ActualColor == color.ActualColor)
                    return true;

            return false;
        }

        private byte _alpha = 255;
        private byte _red = 0;
        private byte _green = 0;
        private byte _blue = 0;

        private SolidColorBrush _previewBrush = Brushes.Black;
        private ItemColor _selectedColor;

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;

        private void UpdatePreview()
        {
            var color = Color.FromArgb(Alpha, Red, Green, Blue);
            PreviewBrush = new SolidColorBrush(color);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}