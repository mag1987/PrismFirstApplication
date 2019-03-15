using PrismFirstApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;


namespace PrismFirstApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

    }
    public class MyMathModel : BindableBase
    {
        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();
        public readonly ReadOnlyObservableCollection<int> MyPublicValues;
        public MyMathModel()
        {
            MyPublicValues = new ReadOnlyObservableCollection<int>(_myValues);
        }
        //добавление в коллекцию числа и уведомление об изменении суммы
        public void AddValue(int value)
        {
            _myValues.Add(value);
            RaisePropertyChanged("Sum");
        }
        //проверка на валидность, удаление из коллекции и уведомление об изменении суммы
        public void RemoveValue(int index)
        {
            //проверка на валидность удаления из коллекции - обязанность модели
            if (index >= 0 && index < _myValues.Count) _myValues.RemoveAt(index);
            RaisePropertyChanged("Sum");
        }
        public int Sum => MyPublicValues.Sum(); //сумма
    }
}
