using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTimesCS.controller
{
    class conexaoBD
    {
        public static string conectar()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\guilherme.salmeida16\source\repos\CrudTimesCS\CrudTimesCS\BDTimesCS.mdf;Integrated Security=True";
        }
    }
}
