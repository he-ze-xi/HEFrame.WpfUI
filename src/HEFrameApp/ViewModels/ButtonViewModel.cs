using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEFrameApp.ViewModels
{
    public class ButtonViewModel : BindableBase
    {
        public ButtonViewModel()
        {

        }

        #region Properties

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Commands

        private DelegateCommand _beginLoadCommand;
        public DelegateCommand BeginLoadCommand => _beginLoadCommand ?? (_beginLoadCommand = new DelegateCommand(BeginLoad));

        #endregion
        private async void BeginLoad()
        {
            IsLoading = true;
            //do something
            await Task.Delay(3000);
            IsLoading = false;
        }
    }
}
