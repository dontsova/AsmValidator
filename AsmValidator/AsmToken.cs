using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsmValidator
{
    class AsmToken
    {
        public string TokenValue;
        public string TokenTag;
        

        public AsmToken(string value, string tag)
        {
            TokenValue = value;
            TokenTag = tag;
        }
        
        ////// нужен метод для динамической генерации названий экземпляров
        ////// этот не работает 
        public AsmToken CreateTokin(string tokinName, string value, string tag)
        {
            AsmToken tokinName = new AsmToken(value, tag);
            return tokinName;
        }
    }
}
