using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasModel
{
   public class Validaciones
    {
     public static bool QueSeaSoloNumeros(string s)
        {
            bool esNum = true;
            foreach (char item in s)
            {
                if (!char.IsDigit(item))
                {
                    esNum = false;
                    break;
                }
            }
            return esNum;
        }

     public static bool QueSeaSoloLetras(string s)
        {
            bool esString = true;
            foreach (char item in s)
            {
                if (char.IsDigit(item))
                {
                    esString = false;
                    break;
                }
            }
            return esString;
        }
    }
}
