using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6_2
{
    internal class Mask
    {

        public static Regex MaskTransformToRegex(string Mask)
        {
            // Заменяем . на \.
            Mask = Mask.Replace(".", @"\." /* (".", "\\.") */);
            // Заменяем ? на .
            Mask = Mask.Replace("?", ".");
            // Заменяем * на .*
            Mask = Mask.Replace("*", ".*");
            // Указываем, что требуется найти точное соответствие маске
            Mask = "^" + Mask + "$";
           
            // Создание объекта регулярного выражения на основе маски
            Regex regMask = new Regex(Mask, RegexOptions.IgnoreCase);
            return regMask;
        }



    }
}
