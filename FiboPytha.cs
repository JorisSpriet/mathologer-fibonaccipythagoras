using System;

namespace FibonacciPythagoras
{
    class FiboPytha
    {
        int _n, _a, _b, _c;
        /*
            | f11   f12  |
            | f21   f22  |
        */
        int[] fibonaccis = Array.Empty<int>();
        bool _calculated;        
        public int a => _a;
        public int b => _b;
        public int c => _c;

        int[] qtoa(Queue<int> q)
        {
            var r = new int[4];
            r[0] = q.Dequeue();
            r[1] = q.Dequeue();
            r[2] = q.Dequeue();
            r[3] = q.Dequeue();
            if(q.Count!=0)
                throw new InvalidOperationException("Bug : more than 4 Fibonacci numbers in queue");
            return r;
        }
        void GetFibonaccis()
        {
            var f = new Queue<int>(4);
            f.Enqueue(1);
            f.Enqueue(1);
            f.Enqueue(2);
            f.Enqueue(3);
            if (_n == 1)
            {
                fibonaccis = qtoa(f);
                return;
            }
            var f3 = 2;
            var f4 = 3;
            int i = _n - 1;
            while(i>0) {
                var nf = f3 + f4;
                f3 = f4;
                f4 = nf;
                f.Dequeue();
                f.Enqueue(nf);
                i--;
            }
            fibonaccis = qtoa(f);
        }

        void DemandCalculation()
        {
            if(_calculated)
                return;

            GetFibonaccis();
            var vp1 = fibonaccis[0] * fibonaccis[3];
            var vp2 = fibonaccis[1] * fibonaccis[2] * 2;
            var dp1 = fibonaccis[0] * fibonaccis[2];
            var dp2 = fibonaccis[1] * fibonaccis[3];

            _a = vp1;
            _b = vp2;
            _c = dp1 + dp2;
            _calculated = true;
        }

        public int Number => _n;

        public FiboPytha(int n)
        {
            _n = n;
        }
        public override string ToString()
        {
            DemandCalculation();
            return $" {fibonaccis[0]}  {fibonaccis[1]}\n" +  
                   $" {fibonaccis[3]}  {fibonaccis[2]}\n" +     
            $"{a}² + {b}² = {c}² ? {(a*a+b*b-c*c==0 ? "ok" : "oops")}\n\n";
        }
    }
}