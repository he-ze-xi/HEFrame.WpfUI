using HEFrameApp.ViewModels;
using HEFrameApp.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace HEFrameApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {        
            containerRegistry.RegisterForNavigation<ButtonView, ButtonViewModel>();
            containerRegistry.RegisterForNavigation<InputView, InputViewModel>();
            containerRegistry.RegisterForNavigation<ListDataView, ListDataViewModel>();
            containerRegistry.RegisterForNavigation<SliderView, SliderViewModel>();
            containerRegistry.RegisterForNavigation<ProgressBarView, ProgressBarViewModel>();
            containerRegistry.RegisterForNavigation<TabControlView, TabControlViewModel>();
            containerRegistry.RegisterForNavigation<MenuView, MenuViewModel>();
            containerRegistry.RegisterForNavigation<ToolTipView, ToolTipViewModel>();
            containerRegistry.RegisterForNavigation<ControlView, ControlViewModel>();
            containerRegistry.RegisterForNavigation<MessageCardView, MessageCardViewModel>();
            containerRegistry.RegisterForNavigation<LoadingAnimationView, LoadingAnimationViewModel>();
            containerRegistry.RegisterForNavigation<TransitionAnimationView, TransitionAnimationView>();
            containerRegistry.RegisterForNavigation<DateView, DateViewModel>();
            containerRegistry.RegisterForNavigation<DataTableView, DataTableViewModel>();
            containerRegistry.RegisterForNavigation<BlankView>();

        }
    }
}
