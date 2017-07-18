using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darts
{
    public class Dart
    {
        Random random = new Random();


        public int Score { get; private set; }
        public int Ring { get; private set; }

        public void Throw()
        {
            this.Score = random.Next(21);
            int ringValue = random.Next(20);
            if ((ringValue == 19) && (this.Score != 0))
                this.Ring = 3;
            else if (ringValue == 18)
                this.Ring = 2;
            else
                this.Ring = 1;
        }
    }

}