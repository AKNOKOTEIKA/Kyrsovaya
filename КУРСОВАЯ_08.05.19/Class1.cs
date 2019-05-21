using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КУРСОВАЯ_08._05._19
{
    public struct stock {
        string Name;        
        string Company;
        int CostForOne;        
        int Number;
        int NumberOfStock;
        int Minpartia;
        public string name
        {
            get { return Name; }
            set
            {                
                string s = value;
                if (ChekSTR(s) == true)
                {
                    Name = value;
                }
                else if (ChekSTR(s) == false)
                {
                    Name = "EROR!";
                }

            }
        }
        public string company
        {
            get { return Company; }
            set {
                string s = value;
                if (ChekSTR(s) == true)
                {
                    Company = value;
                }
                else if (ChekSTR(s) == false)
                {
                    Name = "EROR!";
                }
            }
        }
        public int costforone
        {
            get { return (CostForOne); }
            set {
                string s = Convert.ToString(value);
                if (ChekINT(s) == true)
                {
                    CostForOne = value;
                }
                else if (ChekINT(s) == false)
                {
                    CostForOne = -1;
                }
            }
        }
        public int number
        {
            get { return Number; }
            set {
                string s = Convert.ToString(value);
                if (ChekINT(s) == true)
                {
                    Number = value;
                }
                else if (ChekINT(s) == false)
                {
                    Number = -1;
                }
            }
        }
        public int numberofstock
        {
            get { return NumberOfStock; }
            set {
                string s = Convert.ToString(value);
                if (ChekINT(s) == true)
                {
                    NumberOfStock = value;
                }
                else if (ChekINT(s) == false)
                {
                    NumberOfStock = -1;
                }
            }
        }
        public int minpartia
        {
            get { return Minpartia; }
            set {
                string s = Convert.ToString(value);
                if (ChekINT(s) == true)
                {
                    Minpartia = value;
                }
                else if (ChekINT(s) == false)
                {
                    Minpartia = -1;
                }
            }
        }

        //string
        public bool ChekSTR(string x)
        {
            int erors = 0;
            
            for (int j = 0; j < x.Length - 1; j++)
            {
                if ((((int)x[j] >= 65 && (int)x[j] <= 90) || ((int)x[j] >= 97 && (int)x[j] <= 122)) || ((int)x[j] >= 1072 && (int)x[j] <= 1103) || ((int)x[j] >= 1040 && (int)x[j] <= 1071))
                {
                   
                }
                else
                {
                    erors++;
                    
                }

            }
            if (erors == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //integer
        public bool ChekINT(string x)
        {
            
            int erors = 0;
            for (int j = 0; j < x.Length - 1; j++)
            {
                if (((int)x[j] >= 48 && (int)x[j] <= 57) || (int)x[j] == 46)
                {
                    
                }
                else
                {
                    erors++;
                   
                }

            }
            if (erors == 0) { return true; }
            else return false;


        }


    };
}
