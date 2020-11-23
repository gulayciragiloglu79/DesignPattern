class DateTimeAggregate : IAggregate
{
    public DateTime startDate;
    public DateTime endDate;
    public IIterator CreateIterator() => new DateTimeIterator(this);
}
class DateTimeIterator : IIterator
{
    DateTimeAggregate aggregate;
    DateTime currentDate;
    public DateTimeIterator(DateTimeAggregate aggregate)
    {
        this.aggregate = aggregate;
        currentDate = aggregate.startDate;
    }
    public DateTime CurrentDate() => currentDate;
    public bool HasDate()
    {
        if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
        {
            int dayCount = currentDate.DayOfWeek == DayOfWeek.Saturday ? 1 : 6;
            currentDate = currentDate.AddDays(dayCount);
        }
        else
        {
            int dayCount = (int)currentDate.DayOfWeek;
            currentDate = currentDate.AddDays(6 - dayCount);
            /*6'dan ilgili günün haftalık sayısını çıkarırsak eğer 
             Cumartesi gününe kalan günü hesaplamış oluruz.
             Haliyle bu hesabı ilgili tarihe eklersek eğer
             o haftanın hafta sonuna ulaşmış oluruz.*/
        }
        return currentDate < aggregate.endDate;
    }
}
class Method
{
    DateTimeAggregate tarih = new DateTimeAggregate();
    tarih.startDate = new DateTime(2017, 01, 01);
    tarih.endDate = DateTime.Now;
    IIterator iterator = tarih.CreateIterator();
    while (iterator.HasDate())
    {
        Console.WriteLine(iterator.CurrentDate());
    }
 
    Console.Read();
}
