using System;
using System.Collections.Generic;
 
namespace Observer
{
    /// <summary>
    /// Subject class
    /// </summary>
    internal abstract class HeadQuarters
    {
        private string _information;
        private List<IOperator> _operators=null;
 
        protected HeadQuarters(string information)
        {
            _operators = new List<IOperator>();
            Information = information;
        }
 
        public string Information
        {
            get { return _information; }
            set { 
                _information = value; 
                NotifyOperators();
            }
        }
 
        public void AddOperator(IOperator opt)
        {
            _operators.Add(opt);
        }
        public void RemoveOperator(IOperator opt)
        {
            _operators.Remove(opt);
        }
        public void NotifyOperators()
        {
            foreach (IOperator opt in _operators)
            {
                opt.Update(this);
            }
        }
    }
 
    /// <summary>
    /// Concrete Subject class
    /// </summary>
    internal class RedFleetBase :HeadQuarters
    {
        public RedFleetBase(string information)
           :base(information)
        {
             
        }
 
        public RedFleetBase()
            :base("...")
        {
             
        }
    }
 
    /// <summary>
    /// Observer class
    /// </summary>
    internal interface IOperator
    {
        void Update(HeadQuarters headQuarters);
    }
 
    /// <summary>
    /// Concrete Observer class
    /// </summary>
    internal class PlatoonOperator :IOperator
    {
        public string OperatorName { get; set; }
 
        #region IOperator Members
 
        public void Update(HeadQuarters headQuarters)
        {
            Console.WriteLine("[{0}] : {1}",OperatorName,headQuarters.Information);
        }
 
        #endregion
    }
 
    /// <summary>
    /// Concrete Observer Class
    /// </summary>
    internal class TankOperator : IOperator
    {
        public int TankId  { get; set; }
        #region IOperator Members
 
        public void Update(HeadQuarters headQuarters)
        {
            Console.WriteLine("[{0}] : {1}", TankId, headQuarters.Information);
        }
 
        #endregion
    }
 
 
    /// <summary>
    /// Client App
    /// </summary>
    class Program
    {
        static void Main()
        {
            RedFleetBase redFleetBase = new RedFleetBase {Information = "Süper işlemciler piyasada"};
            redFleetBase.Information = "İşlemciler gelişiyor";
 
            redFleetBase.AddOperator(new PlatoonOperator { OperatorName="Azman"} );
            redFleetBase.AddOperator(new PlatoonOperator { OperatorName = "Kara Şahin"});
            redFleetBase.AddOperator(new PlatoonOperator { OperatorName="Kartal Kondu"});
 
            redFleetBase.Information = "Tüm birlikler Sarı Alarma! Sarı Alarma!";
 
            Console.WriteLine("");
 
            redFleetBase.Information = "Emir iptal! Emir iptal!";
 
            Console.WriteLine("");
 
            redFleetBase.AddOperator(new TankOperator{TankId=701});
            redFleetBase.AddOperator(new TankOperator{TankId=801});
            redFleetBase.Information = "Sınır ihlali.";
        }
    }
}
