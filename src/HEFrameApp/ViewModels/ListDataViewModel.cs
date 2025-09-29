using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace HEFrameApp.ViewModels
{
    public class ListDataViewModel : BindableBase
    {
        public ListDataViewModel()
        {
            GenerateData();
        }

        #region Properties

        private ObservableCollection<string> _items;

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Methods

        private void GenerateData()
        {
            Items = new ObservableCollection<string>();
            for (int i = 0; i < 5; i++)
            {
                Items.Add($"列表测试数据 {i}");
            }
        }

        #endregion
    }
}
