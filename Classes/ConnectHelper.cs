using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfInfoSecurity.Classes
{
    internal class ConnectHelper : DbContext
    {
        public static Frame frame;
        public ConnectHelper() : base("DefaultConnection")
        { }
    }
}
