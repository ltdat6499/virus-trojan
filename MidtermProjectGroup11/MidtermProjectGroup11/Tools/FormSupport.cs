using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Tools
{
    public class FormSupport
    {
        private static FormSupport instance;

        public static FormSupport Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormSupport();
                return FormSupport.instance;
            }
            private set
            {
                FormSupport.instance = value;
            }
        }

        public Control GetControlByName(Control ParentCntl, string NameToSearch)
        {
            if (ParentCntl.Name == NameToSearch)
                return ParentCntl;

            foreach (Control ChildCntl in ParentCntl.Controls)
            {
                Control ResultCntl = GetControlByName(ChildCntl, NameToSearch);
                if (ResultCntl != null)
                    return ResultCntl;
            }
            return null;
        }
    }
}
