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
    }
}
