using HEFrameApp.Common;
using HEFrame.Core.Enums;
using HEFrame.Styles.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace HEFrameApp.ViewModels
{
    public class MessageCardViewModel : BindableBase
    {
        public MessageCardViewModel()
        {

        }

        private DelegateCommand<string> _showGlobalMessageCommand;
        private DelegateCommand<string> _showPartMessageFromTopCommand;
        private DelegateCommand<string> _showPartMessageFromBottomCommand;

        public DelegateCommand<string> ShowGlobalMessageCommand => _showGlobalMessageCommand ?? (_showGlobalMessageCommand = new DelegateCommand<string>(ShowGlobalMessage));
        
        public DelegateCommand<string> ShowPartMessageFromTopCommand => _showPartMessageFromTopCommand ?? (_showPartMessageFromTopCommand = new DelegateCommand<string>(ShowPartMessageFromTop));
        
        public DelegateCommand<string> ShowPartMessageFromBottomCommand => _showPartMessageFromBottomCommand ?? (_showPartMessageFromBottomCommand = new DelegateCommand<string>(ShowPartMessageFromBottom));

        private void ShowGlobalMessage(string messageType)
        {
            ShowMeeage(SysStringsManager.GlobalMessageToken, messageType);
        }
        private void ShowPartMessageFromTop(string messageType)
        {
            ShowMeeage(SysStringsManager.PartMessageFromTopToken, messageType);
        }
        private void ShowPartMessageFromBottom(string messageType)
        {
            ShowMeeage(SysStringsManager.PartMessageFromBottomToken, messageType);
        }
        private void ShowMeeage(string token, string messageType)
        {
            if (!Enum.TryParse(messageType, out MessageType message)) return;
            switch (message)
            {
                case MessageType.DefaultDark:
                    HEMessageService.ShowDefaultDark(token, "默认提示消息", "这是一个默认提示消息");
                    break;
                case MessageType.DefaultLight:
                    HEMessageService.ShowDefaultLight(token, "默认提示消息", "这是一个默认提示消息");
                    break;
                case MessageType.Info:
                    HEMessageService.ShowInfo(token, "提示消息", "这是一个提示消息");
                    break;
                case MessageType.Success:
                    HEMessageService.ShowSuccess(token, "成功消息", "这是一个成功提示消息");
                    break;
                case MessageType.Warn:
                    HEMessageService.ShowWarn(token, "警告消息", "这是一个警告提示消息");
                    break;
                case MessageType.Error:
                    HEMessageService.ShowError(token, "错误消息", "这是一个错误提示消息");
                    break;
                case MessageType.Custom:
                    HEMessageService.ShowCustom(token, "自定义消息", "这是一个自定义提示消息");
                    break;
                default:
                    break;
            }
        }
    }
}
