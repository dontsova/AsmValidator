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
            

            Console.WriteLine(Convert.ToInt32("0xFF"));
            

            Console.WriteLine("Write program: ");
            String line = Console.ReadLine();
            line = line + " ";

            string[] Operators = { "MOV", "ADD", "SUB", "DIV", "MUL" };
            string[] Registers = { "AX", "BX", "CX", "DX", "SI", "DI", "CI", "II" };

            List<AsmToken> TokenList = new List<AsmToken>();


            for (int i = 0; line.Length > i; i++)
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

                        AsmToken OperatorTokin = new AsmToken(Temp, "Operator");
                        TokenList.Add(OperatorTokin);
                        Temp = "";
                    }
                    if (Temp.Contains("[") || Temp.Contains("]"))
                    {
                        if (Registers.Contains(Temp.Substring(1,2)))
                        {
                            AsmToken AddressTokin = new AsmToken(Temp.Substring(1, 2), "Address");
                            TokenList.Add(AddressTokin);
                            Temp = "";
                        }
                    }
                    if (Registers.Contains(Temp))
                    {
                        AsmToken RegisterTokin = new AsmToken(Temp, "Register");
                        TokenList.Add(RegisterTokin);
                        Temp = "";
                    }
                    if (isInt)
                    {
                        AsmToken NumberTokin = new AsmToken(Temp, "DecNumber");
                        TokenList.Add(NumberTokin);
                        Temp = "";
                    } 
                }
            }

            for (int i = 0; TokenList.Count > i; i++)
            {
                AsmToken CurrentTokin = TokenList[i];
                Console.WriteLine("tag : " + CurrentTokin.TokenTag + " value : " + CurrentTokin.TokenValue + ";");
            }

            Console.ReadLine();


        }

       
    }
}
