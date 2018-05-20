using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaratonaBotsBOT.BO
{
    public class Formata
    {
        public static string getRaca(string raca)
        {
            string a = raca;
            if (raca == "scottish fold")
            {
                a = "scottishfold";
            }
            else if (raca == "russo azul")
            {
                a = "russoazul";
            }
            return a;
        }
    }
}