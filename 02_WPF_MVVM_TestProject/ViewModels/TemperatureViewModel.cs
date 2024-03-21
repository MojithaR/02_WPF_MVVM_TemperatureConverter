using System;
using System.ComponentModel;
using System.Windows.Input;

namespace _02_WPF_MVVM_TestProject.ViewModels
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double celsius;
        public double Celsius
        {
            get { return celsius; }
            set { celsius = value; OnPropertyChanged(nameof(Celsius)); }
        }

        private double fahrenheit;
        public double Fahrenheit
        {
            get { return fahrenheit; }
            set { fahrenheit = value; OnPropertyChanged(nameof(Fahrenheit)); }
        }

        private double kelvin;
        public double Kelvin
        {
            get { return kelvin; }
            set { kelvin = value; OnPropertyChanged(nameof(Kelvin)); }
        }

        public TemperatureViewModel()
        {
            ConvertCommand = new RelayCommand(ConvertTemperatures);
            ClearCommand = new RelayCommand(ClearTemperatures);
        }

        public ICommand ConvertCommand { get; }
        public ICommand ClearCommand { get; }

        private void ConvertTemperatures(object obj)
        {
            Fahrenheit = (Celsius * 9.0 / 5.0) + 32;
            Kelvin = Celsius + 273.15;
        }

        private void ClearTemperatures(object obj)
        {
            Celsius = 0;
            Fahrenheit = 0;
            Kelvin = 0;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;

        public RelayCommand(Action<object> executeAction)
        {
            execute = executeAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}