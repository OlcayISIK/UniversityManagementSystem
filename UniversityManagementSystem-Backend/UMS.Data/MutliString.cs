using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Data
{
    public class MultiString
    {
        public MultiString()
        {
            English = "[Translation missing]";
            Turkish = "[Çeviri yok]";
        }
        public string English { get; set; }
        public string Turkish { get; set; }

        public static void AssignValues(MultiString source, MultiString destination)
        {
            destination.English = source?.English;
            destination.Turkish = source?.Turkish;
        }
        /// <summary>
        /// Returns value according to language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string GetValue(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return English;
                case Language.Turkish:
                    return Turkish;
                default:
                    throw new ArgumentOutOfRangeException(nameof(language), language, null);
            }
        }

        public static implicit operator string(MultiString v)
        {
            throw new NotImplementedException();
        }
    }
}
