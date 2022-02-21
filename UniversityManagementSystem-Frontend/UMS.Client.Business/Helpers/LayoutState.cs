using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Business.Helpers
{
    public class LayoutState
    {
        string currentValue;
        public string CurrentValue
        {
            get => currentValue;
            set
            {
                if (currentValue == value) return;
                currentValue = value;
                CurrentValueChanged?.Invoke(this, value);
            }

        }
        public event EventHandler<string> CurrentValueChanged;
    }
}
