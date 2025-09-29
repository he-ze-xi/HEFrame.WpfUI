using HEFrameApp.Common;
using HEFrameApp.Models;
using HEFrame.Core.Enums;
using HEFrame.Styles.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HEFrameApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _currentView;
        private ObservableCollection<MenuBar> _meunBars;
        private readonly IRegionManager _regionManager;
        private TransitionAnimationType _transitionType;
        private ObservableCollection<HETabItem> _tabItems;
        private int _selectedIndex;
        public MainViewModel(IRegionManager regionManager)
        {
            GenerateMenus();
            _regionManager = regionManager;           
        }

        #region Properties

        /// <summary>
        /// 过度动画类型
        /// </summary>
        public TransitionAnimationType TransitionType
        {
            get { return _transitionType; }
            set { _transitionType = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 左侧菜单项
        /// </summary>
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _meunBars; }
            set { _meunBars = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 顶部菜单项
        /// </summary>
        public ObservableCollection<HETabItem> TabItems
        {
            get { return _tabItems; }
            set { _tabItems = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 顶部菜单项索引
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Commands
        private DelegateCommand<string> _pageSwitchCommand;
        private DelegateCommand<string> _switchPageCommand;
        /// <summary>
        /// 左侧菜单切换命令
        /// </summary>
        public DelegateCommand<string> PageSwitchCommand => _pageSwitchCommand ?? (_pageSwitchCommand = new DelegateCommand<string>(PageSwitch));
        /// <summary>
        /// 顶部菜单切换命令
        /// </summary>
        public DelegateCommand<string> SwitchPageCommand => _switchPageCommand ?? (_switchPageCommand = new DelegateCommand<string>(SwitchPage));  
        #endregion

        #region Methods
        private async void PageSwitch(string name)
        {
            if (name.Equals(_currentView)) return;
            _currentView = name;
            if (!SysStringsManager.RegionViews.ContainsKey(name) || string.IsNullOrEmpty(SysStringsManager.RegionViews[name])) return;
            TransitionType = TransitionAnimationType.GradientOut;
            await Task.Delay(300);
            _regionManager.Regions[SysStringsManager.MainRegionName].RequestNavigate(SysStringsManager.RegionViews[name]);
            TransitionType = TransitionAnimationType.GradientIn;
            var item = TabItems.FirstOrDefault(p => p.Header.ToString().Equals(name));
            if (item == null)
            {
                var tabItem = new HETabItem() { Header = name };
                tabItem.RemovedItemEvent -= TabItem_RemovedItemEvent;
                tabItem.RemovedItemEvent += TabItem_RemovedItemEvent;
                TabItems.Add(tabItem);
                SelectedIndex = TabItems.IndexOf(tabItem);
            }
            else
            {
                SelectedIndex = TabItems.IndexOf(item);
            }       
        }
        private async void SwitchPage(string name)
        {
            if (name.Equals(_currentView)) return;
            _currentView = name;
            if (!SysStringsManager.RegionViews.ContainsKey(name) || string.IsNullOrEmpty(SysStringsManager.RegionViews[name])) return;
            TransitionType = TransitionAnimationType.ZoomOut;
            await Task.Delay(300);
            _regionManager.Regions[SysStringsManager.MainRegionName].RequestNavigate(SysStringsManager.RegionViews[name]);
            TransitionType = TransitionAnimationType.ZoomIn;
        }
        private void TabItem_RemovedItemEvent(HETabItem item)
        {
            if (TabItems.Contains(item))
                TabItems.Remove(item);
            if (TabItems.Count > 0)
            {
                SwitchPage(TabItems[0].Header.ToString());
                SelectedIndex = 0;
            }
            else
            {
                SwitchPage("空白视图");
            }
        }
        private void GenerateMenus()
        {
            MenuBars = new ObservableCollection<MenuBar>()
            {
                new MenuBar("基本元素",new List<string>(){ "按钮", "输入", "列表", "滑块", "进度条","选项卡","菜单","提示", "控件"}),
                new MenuBar("其他元素",new List<string>(){ "消息卡片", "数据", "加载动画", "过渡动画", "日期"})
            };
            TabItems = new ObservableCollection<HETabItem>();
        }
        #endregion
    }
}
