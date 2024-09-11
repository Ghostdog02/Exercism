using System;
using Xunit;

namespace HyperiaForex
{
    public struct CurrencyAmount
    {
        private decimal amount;
        private string currency;

        public CurrencyAmount(decimal amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public static bool operator !=(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                if (amountA.amount != amountB.amount)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static bool operator ==(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                if (amountA.amount != amountB.amount)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static bool operator <(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                if (amountA.amount < amountB.amount)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static bool operator >(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                if (amountA.amount > amountB.amount)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static decimal operator +(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                return amountA.amount + amountB.amount;
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static CurrencyAmount operator -(CurrencyAmount amountA, CurrencyAmount amountB)
        {
            if (amountA.Equals(amountB))
            {
                return amountA - amountB;
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public static explicit operator double(CurrencyAmount amountA) => (double)amountA.amount;

        public static implicit operator decimal(CurrencyAmount amountA) => (decimal)amountA.amount;

        public static bool operator *(CurrencyAmount amountA, int num)
        {
            return amountA * num;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            var second = (CurrencyAmount)obj;
            return currency == second.currency;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static void Main()
        {
            decimal value1 = 100.5M;
            decimal value2 = 505.5M;
            var amount1 = new CurrencyAmount(value1, "HD");
            var amount2 = new CurrencyAmount(value2, "USD");
            Assert.Throws<ArgumentException>(() => amount1 + amount2);
        }

    }
}
