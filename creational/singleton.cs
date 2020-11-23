using System;
using System.IO;

abstract class Oyun
{
    public abstract void Platform();
}
class Atari : Oyun
{
    public override void Platform()
    {
        Console.WriteLine("Bu oyun ATARİ platformunda çalışmaktadır.");
    }
}
class PC : Oyun
{
    public override void Platform()
    {
        Console.WriteLine("Bu oyun PC platformunda çalışmaktadır.");
    }
}
class PS : Oyun
{
    public override void Platform()
    {
        Console.WriteLine("Bu oyun PS platformunda çalışmaktadır.");
    }
}
enum Oyunlar
{
    Atari,
    PC,
    PS
}
class Creater
{
      public Oyun FactoryMethod(Oyunlar OyunTipi)
    {
        Oyun oyun = null;
        switch (OyunTipi)   // if else de olur ayrım burdan kaynaklıdır
        {
            case Oyunlar.Atari:
                oyun = new Atari();
                break;
            case Oyunlar.PC:
                oyun = new PC();
                break;
            case Oyunlar.PS:
                oyun = new PS();
                break;
        }
        return oyun;
    }
}
class Program
{
       Creater creater = new Creater();
       // Oyun atariOyunu = creater.FactoryMethod(Oyunlar.Atari);
       //Oyun pcOyunu = creater.FactoryMethod(Oyunlar.PC);
       //Oyun psOyunu = creater.FactoryMethod(Oyunlar.PS);
 
       /* atariOyunu.Platform();
        pcOyunu.Platform();
        psOyunu.Platform();
 */
        //Console.ReadLine();
}
