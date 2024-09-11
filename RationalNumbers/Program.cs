using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    public int m_Numerator;
    public int m_Denominator;
    public RationalNumber(int numerator, int denominator)
    {
        m_Numerator = numerator;
        m_Denominator = denominator;
        var gcd = GetGreatestCommonDivisor(numerator, denominator);
        m_Numerator /= gcd;
        m_Denominator /= gcd;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.m_Numerator * r2.m_Denominator + r2.m_Numerator * r1.m_Denominator,
        r1.m_Denominator * r2.m_Denominator);


    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1.m_Numerator * r2.m_Denominator - r2.m_Numerator * r1.m_Denominator,
        r1.m_Denominator * r2.m_Denominator);


    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber((r1.m_Numerator * r2.m_Numerator),
        (r1.m_Denominator * r2.m_Denominator));

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => new RationalNumber((r1.m_Numerator* r2.m_Denominator),
        (r1.m_Denominator* r2.m_Numerator));
    
    public RationalNumber Abs() => new RationalNumber(Math.Abs(m_Numerator), Math.Abs(m_Denominator));

    public RationalNumber Reduce() => new RationalNumber(m_Numerator, m_Denominator);

    public RationalNumber Exprational(int power) 
    {
        return power >= 0 ? new RationalNumber((int)Math.Pow(m_Numerator, Math.Abs(power)), (int)Math.Pow(m_Denominator, Math.Abs(power)))
            : new RationalNumber((int)Math.Pow(m_Denominator, Math.Abs(power)), (int)Math.Pow(m_Numerator, Math.Abs(power)));

    }

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, ((double)m_Numerator / (double)m_Denominator));

    public int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            var oldB = b;
            b = a % b;
            a = oldB;
        }
        return a;
    }

    static void Main()
    {
        var test = 8.Expreal(new RationalNumber(4, 3));
    }
}