using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWPF.Frames
{
    interface IFrameNavigator
    {
        string NextFrame
        {
            get;
            set;
        }

        EventHandler ChangeFrame
        {
            get;
            set;
        }
    }
}
