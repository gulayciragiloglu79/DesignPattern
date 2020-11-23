/// Strategy - Tüm ödeme strategy'lerimiz bu interface'den türeyecek.
    /// 
    interface IPayment
    {
        void MakePayment();
    }

    /// ConcreteStrategy - Mail order yöntemi ile ödeme strategy'miz.
    /// 
    class MailOrderStrategy : IPayment
       {
       

        public void MakePayment()
          {
            Console.WriteLine("Mail order yöntemi ile ödeme yapıldı.");
          }
    }

    /// ConcreteStrategy - Havale yöntemi ile ödeme strategy'miz.
    /// 
    class BankTransferStrategy : IPayment
    {
        public void MakePayment()
        {
            Console.WriteLine("Havale yöntemi ile ödeme yapıldı.");
        }
    }


    /// ConcreteStrategy - Kredi kartı ile ödeme strategy'miz.
    /// 
    class CreditCardStrategy : IPayment
    {
        public void MakePayment()
        {
            Console.WriteLine("Kredi kartı yöntemi ile ödeme yapıldı.");
        }
    }
 

   /// Context'imiz. IPayment strategy'mizin içeriğindeki metotları sarmalar.
    /// 
    class PaymentOperation
    {
        private IPayment _odeme;
        public PaymentOperation(IPayment _odeme)
        {
            this._odeme = _odeme;
        }

        public void MakePayment()//operation
        {
            this._odeme.MakePayment();
        }
    }

public void strategy()
{
            PaymentOperation paymentOperation = null;

            // Client gelecek olan değere göre runtime'da istediği gibi ödeme tipini seçebilir.
            string paymentType = "BankTransfer";

            // If-Else bloklarını ise gerektiğinde bir kaç satır Reflection kodu ile aşabiliriz.
            // Fakat gerekmedikçe over architectur'ada kaçınılmaması gerekmektedir.
            // Attığımız taş, ürküttüğümüz kurbağaya değecek mi? Buna karar vererek. :)

            if (paymentType == "BankTransfer")
            {
                paymentOperation = new PaymentOperation(new BankTransferStrategy());
            }
            else if (paymentType == "CreditCard")
            {
                paymentOperation = new PaymentOperation(new CreditCardStrategy());
            }
            else if (paymentType == "MailOrder")
            {
                paymentOperation = new PaymentOperation(new MailOrderStrategy());
            }

            paymentOperation.MakePayment();

            Console.ReadLine();
}



