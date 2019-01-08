using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 高级人事管理系统.部门模块.部门选择模块.其他部门.数据绑定类
{
    public class Shechi : INotifyPropertyChanged
    {

        private string _TSTR = "";
        public Shechi()
        {
            
        }

        public string TSTR {
            get { return _TSTR; }
            set
            {
                _TSTR = value;

                OnPropertyChanged("TSTR");
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
