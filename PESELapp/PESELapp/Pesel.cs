using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESELapp
{
    class Pesel
    {
        public string peselNumber;

        private string dayPart;
        private string monthPart;
        private string yearPart;
        private string sexNumber;
        private readonly int peselLength = 11;


        public Pesel()
        {

        }

        public bool SetPeselWithVerification(string number)
        {
            if (this.IsPeselValid(number))
            {
                this.peselNumber = number;
                this.dayPart = this.setDayPart(number);
                this.monthPart = this.setMonthPart(number);
                this.yearPart = this.setYearPart(number);
                this.sexNumber = this.setSexNumber(number);
                return true;
            }
            else return false;

        }

        public void SetPeselWithoutVerification(string number)
        {
            this.peselNumber = number;
            this.dayPart = setDayPart(number);
            this.monthPart = setMonthPart(number);
            this.yearPart = this.setYearPart(number);
            this.sexNumber = setSexNumber(number);
        }

        public bool IsPeselValid(string number)
        {
            if (this.IsSumValid(number) && this.isDayAndMonthValid(number))
                return true;
            else
                return false;
        }

        private bool IsSumValid(string number)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (number.Length == 11)
            {
                int controlSum = CalculateControlSum(number, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(number[number.Length - 1].ToString());
                result = lastDigit == controlNum;
            }
            return result;

        }

        private int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }

        private bool isDayAndMonthValid(string number)
        {
            int day = int.Parse(number[4].ToString() + number[5].ToString());
            int month;
            if (this.isSecondMillenium(number))
            {
                month = (int.Parse(number[2].ToString() + number[3].ToString())) - 20;
            }
            else
                month = int.Parse(number[2].ToString() + number[3].ToString());



            if (this.isDayValid(day) && this.isMonthValid(month))
            {
                if ((month == 2 && day > 29) || (month == 4 && day > 30) || (month == 6 && day > 30) || (month == 9 && day > 30) || (month == 11 && day > 30))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        private bool isDayValid(int day)
        {
            if (day > 0 && day < 32)
                return true;
            else
                return false;

        }

        private bool isMonthValid(int month)
        {
            if (month > 0 && month < 13)
                return true;
            else
                return false;
        }

        private string setMonthPart(string number)
        {
            return number[2].ToString() + number[3].ToString();
        }

        private string setDayPart(string number)
        {
            return number[4].ToString() + number[5].ToString();
        }

        private string setYearPart(string number)
        {
            return number[0].ToString() + number[1].ToString();
        }

        private string setSexNumber(string number)
        {
            return number[9].ToString();
        }

        public string GetDayInfo()
        {
            return this.dayPart;
        }

        public string GetMonthInfo()
        {
            if (this.isSecondMillenium(this.peselNumber))
            {
                int month = int.Parse(this.monthPart);
                return (month - 20).ToString();
            }
            else
                return monthPart;
        }

        public string GetYearInfo()
        {
            if (this.isSecondMillenium(this.peselNumber))
                return "20" + this.yearPart.ToString();
            else return "19" + this.yearPart.ToString();
        }

        public string GetSexInfo()
        {
            if (int.Parse(this.sexNumber) % 2 == 0)
                return "Female";
            else
                return "Male";
        }

        private bool isSecondMillenium(string number)
        {
            if (number[2].ToString() == "2" || number[2].ToString() == "3")
                return true;
            else
                return false;
        }
    }
}
