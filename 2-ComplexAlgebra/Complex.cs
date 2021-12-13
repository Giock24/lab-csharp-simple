namespace ComplexAlgebra
{

    using System;
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double? Real { get; private set; } = null;
        public double? Imaginary { get; private set; } = null;

        public double? Modulus => Math.Sqrt(Real.Value * Real.Value + Imaginary.Value * Imaginary.Value);

        public double? Phase => Math.Atan2(Imaginary.Value, Real.Value);

        public Complex(double? real, double? imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public bool Equals(Complex num)
        {
            if (Real == num.Real && Imaginary == num.Imaginary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Complex Plus(Complex num) => new Complex(Real.Value + num.Real.Value, Imaginary.Value + num.Imaginary.Value);

        public Complex Minus(Complex num) => new Complex(Real.Value - num.Real.Value, Imaginary.Value - num.Imaginary.Value);

        public Complex Complement() => new Complex(Real.Value, -Imaginary.Value);

        public override String ToString()
        {
            if(IsNullable())
            {
                return "The Complex Number is null";
            }

            if ((Real != 0) && (Imaginary  != 0))
            {
                if (Imaginary == 1)
                {
                    return $"The actual rappresentation of this number is: {Real}+i; Modulus : {Modulus}; Phase : {Phase}";
                }
                else if (Imaginary == -1) 
                {
                    return $"The actual rappresentation of this number is: {Real}-i; Modulus : {Modulus}; Phase : {Phase}";
                }
                else
                {
                    if (Imaginary > 0)
                    {
                        return $"The actual rappresentation of this number is: {Real}+{Imaginary}i; Modulus : {Modulus}; Phase : {Phase}";
                    }
                    else
                    {
                        return $"The actual rappresentation of this number is: {Real}-{Imaginary}i; Modulus : {Modulus}; Phase : {Phase}";
                    }
                }
            }
            else if (Imaginary == 0)
            {
                return $"The actual rappresentation of this number is: {Real}+null ; Modulus : {Modulus}; Phase : {Phase}";
            }
            else if (Real == 0)
            {
                return $"The actual rappresentation of this number is: null+{Imaginary} ; Modulus : {Modulus}; Phase : {Phase}";
            }
            else if (Imaginary == -1)
            {
                return $"The actual rappresentation of this number is: -i; Modulus : {Modulus}; Phase : {Phase}";
            }
            else
            {
                return $"The actual rappresentation of this number is: i; Modulus : {Modulus}; Phase : {Phase}";
            }
        }

        private bool IsNullable()
        {
            if (!Real.HasValue || !Imaginary.HasValue)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}