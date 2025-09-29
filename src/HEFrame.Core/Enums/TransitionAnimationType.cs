using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEFrame.Core.Enums
{
    /// <summary>
    /// 过渡动画类型
    /// </summary>
    public enum TransitionAnimationType
    {
        /// <summary>
        /// 默认无效果
        /// </summary>
        Default,
        /// <summary>
        /// 缩放入
        /// </summary>
        ZoomIn,
        /// <summary>
        /// 缩放出
        /// </summary>
        ZoomOut,
        /// <summary>
        /// 渐变入
        /// </summary>
        GradientIn,
        /// <summary>
        /// 渐变出
        /// </summary>
        GradientOut,
        /// <summary>
        /// 左滑入
        /// </summary>
        SlideFromLeft,
        /// <summary>
        /// 左滑出
        /// </summary>
        SlideToLeft,
        /// <summary>
        /// 右滑入
        /// </summary>
        SlideFromRight,
        /// <summary>
        /// 右滑出
        /// </summary>
        SlideToRight,
        /// <summary>
        /// 上滑入
        /// </summary>
        SlideFromTop,
        /// <summary>
        /// 上滑出
        /// </summary>
        SlideToTop,
        /// <summary>
        /// 下滑入
        /// </summary>
        SlideFromBottom,
        /// <summary>
        /// 下滑出
        /// </summary>
        SlideToBottom,
        /// <summary>
        /// 绕左上角旋转入
        /// </summary>
        RotateIn,
        /// <summary>
        /// 绕左上角旋转出
        /// </summary>
        RotateOut,
    }
}
