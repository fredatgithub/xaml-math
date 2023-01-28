using System;

namespace WpfMath
{
    public class FormulaNotFoundException : Exception
    {
        internal FormulaNotFoundException(string formulaName)
            : base(string.Format("Cannot find predefined formula with name '{0}'.", formulaName))
        {
        }
    }
}