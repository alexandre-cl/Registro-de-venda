using System;
using System.Collections.Generic;
using System.Linq;

namespace Prova_Estrutura_Sequencial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<Product.productVO> productList = new();
            bool execute = true;
            
            while (execute)
            {
                Product.productVO pvo = new Product.productVO();
                pvo.Codigo = Program.GetProductCode(productList);
                pvo.Qtd = Program.GetProductQtd();
                pvo.Valor = Program.GetProductVal();
                productList.Add(pvo);
                execute = Program.Registrar();
                Console.Clear();
            }

            Program.DisplayGenerator(productList);

        }

        private static void DisplayGenerator(List<Product.productVO> pvoList)
        {
            ConsoleColor _PRODUCTCOLOR_ = ConsoleColor.Yellow;
            ConsoleColor _TABLECOLOR_ = ConsoleColor.Green;
            ConsoleColor _TOTALCOLOR_ = ConsoleColor.Red;
            ConsoleColor _STDCOLOR_ = ConsoleColor.White;



            decimal total;
            total = Program.Calculate(pvoList);
            pvoList.ForEach(product =>
            {
                string line = "| ";
                line += "Código: " + product.Codigo.ToString() + " | ";
                line += "Quantidade: " + product.Qtd.ToString() + "un | ";
                line += "Valor: R$" + product.Valor.ToString() + " | ";
                line += "Total: R$" + (product.Valor * product.Qtd) + " |";
                int lineSize = line.Length;

                Console.ForegroundColor = _TABLECOLOR_;
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", lineSize)));

                Console.ForegroundColor = _PRODUCTCOLOR_;
                Console.WriteLine(line);

                Console.ForegroundColor = _TABLECOLOR_;
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", lineSize)));

            });
            Console.ForegroundColor = _TOTALCOLOR_;
            Console.WriteLine("Total a pagar: R$" + total);
            Console.ForegroundColor = _STDCOLOR_;
        }

        private static decimal Calculate(List<Product.productVO> pvoList)
        {
            decimal total = 0;
            pvoList.ForEach(pvo =>
            {
                total += pvo.Qtd * pvo.Valor;
            });

            return total;
        }

        private static int GetProductCode(List<Product.productVO> productList)
        {
            bool correct;
            int cod;
            do
            {
                Console.Write("Digite o código do produto: ");
                
                correct = Int32.TryParse(Console.ReadLine(), out cod);
                if (!correct)
                {
                    Console.Clear();
                    Console.WriteLine("Código inválido!");
                }else if (productList.Count != 0)
                {
                    productList.ForEach(product =>
                    {
                        if(product.Codigo == cod)
                        {
                            correct = false;
                            Console.Clear();
                            Console.WriteLine("Código já registrado!");
                        }
                    });
                }
            } while (!correct);

            return cod;
        }

        private static int GetProductQtd()
        {
            bool correct;
            int qtd;
            do
            {
                Console.Write("Digite a quantidade do produto: ");
                
                correct = Int32.TryParse(Console.ReadLine(), out qtd);
                if (!correct)
                {
                    Console.Clear();
                    Console.WriteLine("Quantidade inválida!");
                }
            } while (!correct);

            return qtd;
        }

        private static decimal GetProductVal()
        {
            bool correct;
            decimal val;
            do
            {
                Console.Write("Digite o valor deste produto: ");

                correct = Decimal.TryParse(Console.ReadLine(), out val);
                if (!correct)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido!");
                }
            } while (!correct);

            return val;
        }

        private static bool Registrar()
        {
            bool correct;
            bool result = false;
            do
            {

                Console.WriteLine("Registrar outro produto na venda? (s/n)");
                string choice = Console.ReadLine();
                correct = choice == "s" || choice == "n";
                if (!correct)
                {
                    Console.Clear();
                    Console.WriteLine("Somente será aceito o valor s ou n.");
                }
                else
                {
                    result = choice == "s";    
                }
                
            } while (!correct);

            return result;
        }
    }
}
