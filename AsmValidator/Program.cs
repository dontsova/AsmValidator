using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsmValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string Temp = "";

            Console.WriteLine("Write program: ");
            String line = Console.ReadLine();

            string[] Operators = { "MOV", "ADD", "SUB", "DIV", "MUL" };
            string[] Registers = { "AX", "BX", "CX", "DX", "SI", "DI", "CI", "II" };

            List<AsmToken> TokenList = new List<AsmToken>();


            for (int i = 0; i < line.Length; i++)
            {

                if (line.Substring(i, 1) != " ")
                {
                    Temp = Temp + line.Substring(i, 1);
                }
                else
                {
                    uint res;
                    bool isInt = UInt32.TryParse(Temp, out res);

                    if (Operators.Contains(Temp))
                    {
                        AsmToken OperatorToken = new AsmToken(Temp, "Operator");
                        TokenList.Add(OperatorToken);
                        Temp = "";
                    }
                    if (Temp.Contains("[") && Temp.Contains("]"))
                    {
                        if (Registers.Contains(Temp))
                        {
                            AsmToken AddressToken = new AsmToken(Temp, "Address");
                            TokenList.Add(AddressToken);
                            Temp = "";
                        }
                    }
                    if (Registers.Contains(Temp))
                    {
                        AsmToken RegisterToken = new AsmToken(Temp, "Register");
                        TokenList.Add(RegisterToken);
                        Temp = "";
                    }
                    if (isInt)
                    {
                        AsmToken NumberToken = new AsmToken(Temp, "Number");
                        TokenList.Add(NumberToken);
                        Temp = "";
                    }
                }
            }

            for (int i = 0; TokenList.Count > i; i++)
            {
                AsmToken CurrentToken = TokenList[i];
                Console.WriteLine("tag : " + CurrentToken.TokenTag + " value : " + CurrentToken.TokenValue + ";");
            }

            Console.ReadLine();


        }
    }
}
