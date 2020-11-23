using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
 
namespace StatePattern
{
    // State tipi
    // abstract sınıf olabileceği gibi interface şeklinde de tasarlanabilir
    abstract class VendingMachineState
    {
        public abstract void HandleState(VendingMachine context);
    }
 
    // Concrete State tipi
    // Otomat start düğmesine basılarak çalıştırıldığında öncelikli olarak bir ön hazırlık yapacaktır.
    class InitializeState:VendingMachineState
    {
        public InitializeState()
        {
            Console.WriteLine("Initialize...");
        }
        public override void HandleState(VendingMachine context)
        {
            Console.WriteLine("Ön hazırlıklar yapılıyor");
            Thread.Sleep(2000);            
            // Makinenin durumu değiştiriliyor. Makine initialize edilmiş. Bekleme konumuna geçebilir.
            context.State=new WaitingState();     
        }
    }
 
    // Concrete State tipi
    class PreparingState : VendingMachineState
    {
        public PreparingState()
        {
            Console.WriteLine("Preparing...");
        }
        public override void HandleState(VendingMachine context)
        {
            Console.WriteLine("İstenilen ürün hazırlanıyor. Lütfen bekleyiniz");
            // Makienin durumu değiştiriliyor. Ürün hazırlanması bitmiş. Buna göre ürünü teslim etme durumuna geçiyor.
            context.State = new DeliveryState();
        }
    }
 
    // Concrete State tipi
    class WaitingState : VendingMachineState
    {
        public WaitingState()
        {
            Console.WriteLine("Waiting...");
        }        
        public override void HandleState(VendingMachine context)
        {
            int totalProduct=context.ProductList.Sum<Product>(p => p.Count);
 
            Console.WriteLine("Makine bekleme konumunda. Şu anda {0} adet ürün var.",totalProduct.ToString());
            // Makine bekleme konumundayken  aslında bir State değişikliği söz konusu değil. Değişimi sağlayacak olan aslında istemcinin vereceği bir aksiyon. Context tipi üzerindeki RequestProduct metodunun çağırılması bu anlamda düşünülebilir.
        }
    }
 
    // Concrete State tipi
    class DeliveryState 
          : VendingMachineState
    {
        public DeliveryState()
        {
            Console.WriteLine("Delivering...");
        }
        public override void HandleState(VendingMachine context)
        {
            Console.WriteLine("Ürün teslim ediliyor");
            // Makinin durumu değiştiriliyor. Ürün teslim edildikten sonra tekrar bekleme konumuna alınıyor.
            context.State = new WaitingState();
        }
    }
 
    // Context tipi
    class VendingMachine
    {
        public List<Product> ProductList = new List<Product>();
        // Context tipi, kendi içerisinde State nesne referanslarını değiştirebilir. Bunun için State tipinden bir özellik sunmaktadır
        private VendingMachineState _state;
 
        public VendingMachineState State
        {
            get { return _state; }
            set
            {
                // State değiştiğinde, üretilen State nesne örneğinin çalışma zamanındaki referansına ait HandleState metodu çalıştırılır. Parametre olarak o anki Context gönderilir.
                _state = value;
                // Burada durum değişimleri sonucu çalıştırılacak davranışların başlatılma noktasınıda merkezileştirmiş oluyoruz.
                _state.HandleState(this);
            }
        }       
 
        // Context nesnesi örneklenirken başlangıç durumu belirtilir.
        public VendingMachine()
        {
            // Test için makineye örnek ürünler yüklenir.
            ProductList.Add(new Product { Name = "Çikolata K", ListPrice = 10,Count=50 });
            ProductList.Add(new Product { Name = "Biskuvi Bis", ListPrice = 3.45 ,Count=50});
            ProductList.Add(new Product { Name = "Tuzlu mu tuzlu çıtır", ListPrice = 4.50 ,Count=35});
 
            // Makineye ürünleri yükledikten sonra durumunu değiştir
            State = new InitializeState();
        }
        public void RequestProduct(string productName,double money)
        {
            Console.WriteLine("Ürün siparişi geldi. {0} için atılan para : {1}",productName,money);
            Product prd = (from p in ProductList
                           where (p.Name == productName && (money >= p.ListPrice && p.Count >= 1))
                           select p).SingleOrDefault<Product>();
                         
            // Eğer talep edilen ürün stokta var ve atılan para yeterli ise 
            if (prd != null)
            {
                prd.Count--;
                // Makinenin durumunu değiştir
                State = new PreparingState();
            }
            else
                State = new WaitingState();
        }
    }
 
    // Yardımcı tip
    class Product
    {
        public string Name { get; set; }
        public double ListPrice { get; set; }
        public int Count { get; set; }
    }
 
    // Client
    class Program
    {
        
            // Context tipine ait nesne örneği oluşturulur
            VendingMachine machine = new VendingMachine();
 
            // İstemci bir ürün ister
            machine.RequestProduct("Çikolata K",10);
             
            machine.RequestProduct("Bsissi", 12); // Bu ürün olmadığı için vermeyecektir. Herhangibir aksiyon alınmayacaktır.
        
    }
}
