using System;
using System.Collections.Generic;
using System.Text;

namespace Lahiye.TransfetMoneyAndEmployee
{
    public class Transfer_money
    {
        public double Withdrawal(double balance, double amount)
        {
            Console.WriteLine($"Withdrawal{0}",amount);
            return balance - amount;
        }
        public double Deposit(double balance,double amount)
        {
            Console.WriteLine($"Depositied{0}",amount);
            return balance + amount;
        }

    }
}
