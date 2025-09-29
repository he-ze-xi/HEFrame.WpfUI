using HEFrame.Core.Enums;
using HEFrame.Styles.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HEFrame.Styles.Services
{
    /// <summary>
    /// 消息服务
    /// </summary>
    public class HEMessageService
    {
        /// <summary>
        /// 管理所有被注册的消息容器主机
        /// </summary>
        internal static readonly Dictionary<string, HEMessageCardHost> _messageHost = new Dictionary<string, HEMessageCardHost>();
        /// <summary>
        /// 消息主机Token附加属性
        /// </summary>
        public static readonly DependencyProperty MessageHostTokenProperty = 
            DependencyProperty.RegisterAttached("MessageHostToken", typeof(string), typeof(HEMessageService),new FrameworkPropertyMetadata(OnHostTokenChanged));
        private static readonly  object _locker = new object();
        public static string GetToken(DependencyObject dp)
        {
            return (string)dp.GetValue(MessageHostTokenProperty);
        }
        public static void SetToken(DependencyObject dp, string token)
        {
            dp.SetValue(MessageHostTokenProperty, token);
        }
        private static void OnHostTokenChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (!(dp is HEMessageCardHost host)) return;
                var token = GetToken(dp);
                if (string.IsNullOrWhiteSpace(token)) throw new ArgumentException("HostToken属性不能为空");
                lock (_locker)
                {
                    if (!_messageHost.ContainsKey(token))
                    {
                        _messageHost.Add(token, host);
                    }
                }                     
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        /// <summary>
        /// 显示默认消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowDefaultDark(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.DefaultDark);
        /// <summary>
        /// 显示默认消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowDefaultLight(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0 )
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.DefaultLight);
        /// <summary>
        /// 显示提示消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowInfo(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.Info);
        /// <summary>
        /// 显示成功消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowSuccess(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.Success);
        /// <summary>
        /// 显示警告消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowWarn(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.Warn);
        /// <summary>
        /// 显示错误消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowError(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken,content, description, isAutoClose, delayTime, MessageType.Error);
        /// <summary>
        /// 显示自定义消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        public static void ShowCustom(string hostToken, string content, string description, bool isAutoClose = true, double delayTime = 3.0)
                                    => ShowMessage(hostToken, content, description, isAutoClose, delayTime, MessageType.Custom);
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="hostToken">消息主机Token</param>
        /// <param name="content">消息内容</param>
        /// <param name="description">消息描述</param>
        /// <param name="isAutoClose">是否自动关闭消息卡片</param>
        /// <param name="delayTime">自动关闭消息卡片延时</param>
        /// <param name="type">消息类型</param>
        private static void ShowMessage(string hostToken, string content, string description, bool isAutoClose, double delayTime, MessageType type)
        {
            if (string.IsNullOrWhiteSpace(hostToken)) return;
            lock (_locker)
            {
                if (!_messageHost.ContainsKey(hostToken)) return;
                if (!(_messageHost[hostToken] is HEMessageCardHost host)) return;
                host.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                {
                    var card = new HEMessageCard(type, content, description, isAutoClose, delayTime);
                    if (type == MessageType.Custom)
                    {
                        card.MessageContent = string.Empty;
                        card.CustomContent = content;
                    }
                    host.MessageContainer.Items.Add(card);
                }));
            }
        }
    }
}
