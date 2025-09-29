using HEFrame.Styles.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace HEFrameApp.ViewModels
{
    public class TabControlViewModel : BindableBase
    {
        public TabControlViewModel()
        {
            GenerateData();

        }

        #region Properties
        private ObservableCollection<HETabItem> _tabItems;
        public ObservableCollection<HETabItem> TabItems
        {
            get { return _tabItems; }
            set { _tabItems = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Commands
        private DelegateCommand _addTabItemCommand;
        public DelegateCommand AddTabItemCommand => _addTabItemCommand ?? (_addTabItemCommand = new DelegateCommand(AddTabItem));
        #endregion

        #region Methods

        private void AddTabItem()
        {
            if (TabItems == null) return;
            var tabItem = new HETabItem() { Header = $"新增选项卡{TabItems.Count}", Content = $"新增选项卡{TabItems.Count}" };
            tabItem.RemovedItemEvent -= TabItem_RemovedItemEvent;
            tabItem.RemovedItemEvent += TabItem_RemovedItemEvent;
            TabItems.Add(tabItem);
        }

        private void GenerateData()
        {
            TabItems = new ObservableCollection<HETabItem>();
            for (int i = 0; i < 3; i++)
            {
                var tabItem = new HETabItem() { Header = $"选项卡{i}", Content = $"选项卡{i}" };
                tabItem.RemovedItemEvent -= TabItem_RemovedItemEvent;
                tabItem.RemovedItemEvent += TabItem_RemovedItemEvent;
                TabItems.Add(tabItem);
            }
        }

        private void TabItem_RemovedItemEvent(HETabItem item)
        {
            if (TabItems.Contains(item))
                TabItems.Remove(item);
        }
        #endregion
    }
}
