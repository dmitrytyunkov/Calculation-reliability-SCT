using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWork
{
    class Electricalradioelement
    {
        private string title;
        private int numbers;
        private double lambda;

        public Electricalradioelement(string title, double lambda)
        {
            SetTitle(title);
            SetNumbers(0);
            SetLambda(lambda);
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetNumbers(int numbers)
        {
            this.numbers = numbers;
        }

        public void SetLambda(double lambda)
        {
            this.lambda = lambda;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public int GetNumbers()
        {
            return this.numbers;
        }

        public double GetLambda()
        {
            return this.lambda;
        }
    }
}
