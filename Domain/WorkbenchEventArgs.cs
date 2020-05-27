using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkbenchEventArgs : EventArgs
    {
        private readonly Workbench _workbench;

        public WorkbenchEventArgs(Workbench workbench)
        {
            _workbench = workbench;
        }

        public Workbench Workbench => _workbench;
    }
}
