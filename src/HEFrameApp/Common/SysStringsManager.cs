using HEFrameApp.Views;
using System.Collections.Generic;

namespace HEFrameApp.Common
{
    public class SysStringsManager
    {
        public static readonly string MainRegionName = "MainRegion";
        public static readonly string GlobalMessageToken = "GlobalMessageToken";
        public static readonly string PartMessageFromTopToken = "PartMessageFromTopToken";
        public static readonly string PartMessageFromBottomToken = "PartMessageFromBottomToken";
        public static readonly Dictionary<string, string> RegionViews;
        static SysStringsManager()
        {
            RegionViews = new Dictionary<string, string>()
            {
                {"按钮",nameof(ButtonView)},
                {"输入",nameof(InputView)},
                {"列表",nameof(ListDataView)},
                {"滑块",nameof(SliderView)},
                {"进度条",nameof(ProgressBarView)},
                {"选项卡",nameof(TabControlView)},
                {"菜单",nameof(MenuView)},
                {"提示",nameof(ToolTipView)},
                {"控件",nameof(ControlView)},
                {"数据",nameof(DataTableView)},
                {"消息卡片",nameof(MessageCardView)},
                {"加载动画",nameof(LoadingAnimationView)},
                {"过渡动画",nameof(TransitionAnimationView)},
                {"日期",nameof(DateView)},
                {"空白视图",nameof(BlankView)},
            };
        }
        public static readonly string NumberPattern = @"^[0-9]*$";
        public static readonly string EnglishPattern = @"^[A-Za-z]+$";
    }
}
