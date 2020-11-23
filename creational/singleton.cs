class Singleton
    {
        private Singleton()
        {
 
        }
        private static Singleton nesne;
        //static metodun içinde bu referansı kullanabilmemiz için static olması gerekiyor.
        //static metodun içinde sadece static metodlar kullanılabilir.
        public static Singleton NesneVer()
        {
            //multithread olursa buraya lock koy
            if (nesne==null)
            {
                nesne = new Singleton();
            }
            return nesne;
        }
    }
