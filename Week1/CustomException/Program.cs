using System;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            //CatchAndRethrow();
            CatchAndRethrowEx();
            //JustCatch();
        }

        static double Divide(double x, double y)
        {
            if (y.Equals(x))
                throw new DivideBySelfException("Division by itself not allowed");
            return x / y;
        }

        static void CatchAndRethrow()
        {
            try
            {
                double a = Divide(1, 1);
            }
            catch (DivideBySelfException e)
            {
                throw;
            }
        }

        static void CatchAndRethrowEx()
        {
            try
            {
                double a = Divide(1, 1);
            }
            catch (DivideBySelfException e)
            {
                throw e;
            }
        }

        static void JustCatch()
        {
            try
            {
                double a = Divide(1, 1);
            }
            catch (DivideBySelfException e)
            {
            }
        }
    }
}
