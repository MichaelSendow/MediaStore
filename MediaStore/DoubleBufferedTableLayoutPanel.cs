using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace MediaStore
{


    /// <summary>
    /// Double Buffered layout panel - removes flicker during resize operations.
    /// https://www.richard-banks.org/2007/09/how-to-create-flicker-free.html
    /// [2020-04-19]
    /// </summary>
    public partial class DoubleBufferedTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferedTableLayoutPanel()
        : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public DoubleBufferedTableLayoutPanel(IContainer container) : base()
        {
            if (container != null)
                container.Add(this);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
    }
}
