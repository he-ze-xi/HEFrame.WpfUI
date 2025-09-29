using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace HEFrameApp.ViewModels
{
    public class InputViewModel : BindableBase
    {
        public InputViewModel()
        {
            GenerateData();
        }
        #region Properties

        private string _checkBoxContent;
        private ObservableCollection<string> _users;
        public ObservableCollection<string> Users
        {
            get { return _users; }
            set { _users = value; RaisePropertyChanged(); }
        }
        public string CheckBoxContent
        {
            get { return _checkBoxContent; }
            set { _checkBoxContent = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Commands

        private DelegateCommand<bool?> _updateCheckedStateCommand;
        public DelegateCommand<bool?> UpdateCheckedStateCommand => _updateCheckedStateCommand ?? (_updateCheckedStateCommand = new DelegateCommand<bool?>(UpdateCheckedState));

        #endregion

        #region Methods

        private void UpdateCheckedState(bool? state)
        {
            if (state == null) CheckBoxContent = "未知状态";
            else if ((bool)state) CheckBoxContent = "选中";
            else CheckBoxContent = "未选中";
        }
        private void GenerateData()
        {
            CheckBoxContent = "未选中";
            Users = new ObservableCollection<string>()
            {
                "用户1",
                "用户2",
                "用户3",
                "用户4",
                "用户5",
                "用户6",
            };
        }

        #endregion
    }
}
