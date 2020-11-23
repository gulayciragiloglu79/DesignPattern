class MotorOlusturucu
{
    public int x { get; set; }
    public int y { get; set; }
    public bool z { get; set; }
}
class ArabaOlusturucu
{
    
    public MotorOlusturucu Motor { get; set; }
    public ArabaOlusturucu(IskeletOlusturu Iskelet, MotorOlusturucu Motor)
    {
        this.Iskelet = Iskelet;
        this.Motor = Motor;
    }
 
    public Araba Olustur(Renkler renk)
    {
        return new Araba(Iskelet, Motor, renk);
    }
}

class FacadeUretici
{
    IskeletOlusturu iskelet;
    MotorOlusturucu motor;
    ArabaOlusturucu olustur;
 
    public FacadeUretici()
    {
      
  motor = new MotorOlusturucu() { x = 2, y = 4, z = false };
        olustur = new ArabaOlusturucu(iskelet, motor);
    }
 
    public void ArabaUret()
    {
        Araba uretilenAraba = olustur.Olustur(Renkler.Kırmızı);
    }
}
class Program
{
    
        FacadeUretici uretici = new FacadeUretici();
        uretici.ArabaUret();
 
        Console.Read();
 
}
