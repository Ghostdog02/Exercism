using System;

namespace ComplexNumbers
{
    public struct ComplexNumber
    {
        private double m_Real;
        private double m_Imaginary;
        //static string RealOrImaginary = string.Empty;
        public ComplexNumber(double real, double imaginary = 0)
        {
            m_Real = real;
            m_Imaginary = imaginary;
        }

        public double Real()
        {
            return m_Real;
        }

        public double Imaginary()
        {
            return m_Imaginary;
        }

        public ComplexNumber Mul(ComplexNumber other)
        {
            double mulReal = Real() * other.Real() - Imaginary() * other.Imaginary();
            double mulImaginary = Imaginary() * other.Real() + Real() * other.Imaginary();
            return new ComplexNumber(mulReal, mulImaginary);
        }
        public ComplexNumber Mul(double real)
        {
            var complexNumber = new ComplexNumber(real);
            double mulReal = Real() * complexNumber.Real() - Imaginary() * complexNumber.Imaginary();
            double mulImaginary = Imaginary() * complexNumber.Real() + Real() * complexNumber.Imaginary();
            return new ComplexNumber(mulReal, mulImaginary);
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            double sumReal = Real() + other.Real();
            double sumImaginary = Imaginary() + other.Imaginary();
            return new ComplexNumber(sumReal, sumImaginary);
        }

        public ComplexNumber Add(double real)
        {
            var complexNumber = new ComplexNumber(real);
            double sumReal = Real() + complexNumber.Real();
            double sumImaginary = Imaginary() + complexNumber.Imaginary();
            return new ComplexNumber(sumReal, sumImaginary);
        }

        public ComplexNumber Sub(ComplexNumber other)
        {
            double subReal = Real() - other.Real();
            double subImaginary = Imaginary() - other.Imaginary();
            return new ComplexNumber(subReal, subImaginary);
        }

        public ComplexNumber Div(ComplexNumber other)
        {
            var divReal = (Real() * other.Real() + Imaginary() * other.Imaginary()) /
                (Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2));
            var divImaginary = (Imaginary() * other.Real() - Real() * other.Imaginary()) /
                (Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2));
            return new ComplexNumber(divReal, divImaginary);
        }

        public ComplexNumber Div(double real)
        {
            var complexNumber = new ComplexNumber(real);
            double divReal = (Real() * complexNumber.Real() + Imaginary() * complexNumber.Imaginary()) /
                (Math.Pow(complexNumber.Real(), 2) + Math.Pow(complexNumber.Imaginary(), 2)); ;
            var divImaginary = (Imaginary() * complexNumber.Real() - Real() * complexNumber.Imaginary()) /
                (Math.Pow(complexNumber.Real(), 2) + Math.Pow(complexNumber.Imaginary(), 2));
            return new ComplexNumber(divReal, divImaginary);

        }

        public double Abs()
        {
            //| z | = sqrt(a ^ 2 + b ^ 2)
            return Math.Sqrt(Math.Pow(Real(), 2) + Math.Pow(Imaginary(), 2));
        }

        public ComplexNumber Conjugate()
        {
            var real = Real();
            var imaginary = -Imaginary();
            return new ComplexNumber(real, imaginary);
        }

        public ComplexNumber Exp()
        {
            //e ^ (a + i * b) = e ^ a * e ^ (i * b)
            //e^(i * b) = cos(b) + i * sin(b)
            var real = Math.Pow(Math.E, Real());
            return new ComplexNumber(real * Math.Cos(Imaginary()), real * Math.Sin(Imaginary()));

        }

        static void Main()
        {
            var sut = new ComplexNumber(0, Math.PI);
            var expected = new ComplexNumber(-1, 0);
            var ssmt = sut.Exp().Real();
            var ssmt1 = sut.Exp().Imaginary();

        }
    }
}
