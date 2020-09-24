using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mayordomo.ViewModels.Base
{
    public class BindableNotify : INotifyPropertyChanged
    {
        #region NotifyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
