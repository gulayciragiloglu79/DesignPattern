using System;
 
namespace ConsoleApplication9 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            GameReporter reporter = null;
 
            reporter = new XmlReporter(); 
            reporter.WriteSummary(); 
            Console.WriteLine();
 
            reporter = new TextReporter(); 
            reporter.WriteSummary(); 
            Console.WriteLine();
 
            reporter = new ConsoleReporter(); 
            reporter.WriteSummary(); 
        } 
    }
 
    abstract class GameReporter 
    {        
        public void GetResults() 
        { 
            Console.WriteLine("Oyuncuların istatistikleri toplanıyor"); 
        }
 
        public void ParseResults() 
        { 
            Console.WriteLine("İstatistikler ayrıştırılıyor"); 
        }
 
        public abstract void WriteResults();
 
        public void WriteSummary() 
        { 
            GetResults(); 
            ParseResults(); 
            WriteResults(); 
        } 
    }
 
    class XmlReporter : GameReporter 
    { 
        public override void WriteResults() 
        { 
            Console.WriteLine("İstatistikler XML dosyasına yazılıyor."); 
        } 
    }
 
    class TextReporter : GameReporter 
    { 
        public override void WriteResults() 
        { 
            Console.WriteLine("İstatistikler TEXT dosyasına yazdırılıyor."); 
        } 
    }
 
    class ConsoleReporter : GameReporter 
    { 
        public override void WriteResults() 
        { 
            Console.WriteLine("İstatistikler CONSOLE ekranına basılıyor."); 
        } 
    } 
}
