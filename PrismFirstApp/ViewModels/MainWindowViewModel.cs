using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;

namespace PrismFirstApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        readonly MyMathModel _model = new MyMathModel();
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            //таким нехитрым способом мы пробрасываем изменившиеся свойства модели во View
            _model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str => {
                //проверка на валидность ввода - обязанность VM
                int ival;
                if (int.TryParse(str, out ival)) _model.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i => {
                if (i.HasValue) _model.RemoveValue(i.Value);
            });
        }
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public int Sum => _model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _model.MyPublicValues;
    }
}
