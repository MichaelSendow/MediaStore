using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaStore
{
    public interface ISearch
    {
        Stock Search(Stock stock, string searchString);
    }
}