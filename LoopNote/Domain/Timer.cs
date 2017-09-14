using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace LoopNote.Domain
{
    public class Timer : MainWindow
    {
        public Timer()
        {
        }

        #region Properties

        public int Time = 3;

        #endregion

        public string StartTimer(int count)
        {

            if (count > 0)
                return String.Concat(count);

            return "";
        }

    }
}
