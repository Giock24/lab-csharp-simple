using ComplexAlgebra;
using System;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        /* if 1 show DisplayCalc else show only Operator*/

        private Complex _displayCal;
        private int _whatShow = 0; 
        private char _actualOp;
        private int _numCompl;
        private int _numOp;

        private Complex[] _allNumCom = new Complex[100];
        private char[] _opSaved = new char[100];
        public Complex DiplayCalc 
        { 
            get => _displayCal; 
            private set => _displayCal = value; 
        } 

        public Complex Value
        {
            get => DiplayCalc;
            set
            {
                _whatShow = 1;
                double? re = value.Real;
                double? im = value.Imaginary;

                _allNumCom[_numCompl] = new Complex(re, im);
                _numCompl++;
                DiplayCalc = new Complex(re, im);
            }
        }

        public char Operation
        {
            get => _actualOp;
            set
            {
                _opSaved[_numOp] = value;
                _numOp++;
                _actualOp = value;
                _whatShow = 0;
            }    
        }

        public void ComputeResult()
        {
            DiplayCalc = _allNumCom[0];
            int actualOp = 0;
            for (int i = 0; i < _numCompl || actualOp < _numOp; )
            {
                if (_opSaved[actualOp] == Calculator.OperationPlus)
                {
                    i++;
                    DiplayCalc = DiplayCalc.Plus(_allNumCom[i]);
                    actualOp++;
                }
                else if(_opSaved[actualOp] == Calculator.OperationMinus)
                {
                    i++;
                    DiplayCalc = DiplayCalc.Minus(_allNumCom[i]);
                    actualOp++;
                }
                else
                {
                    i++;
                }
            }
        }

        public void Reset()
        {
            DiplayCalc = new Complex(0, 0);

            _allNumCom.Initialize();
            _opSaved.Initialize();
            _numCompl = 0;
            _numOp = 0;
        }

        public override string ToString()
        {
            switch (_whatShow)
            {
                case 1:
                    return $"{DiplayCalc}";
                default:
                    return $"{Operation}";
            }
        }
    }
}