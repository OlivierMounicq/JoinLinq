public class Rate
{
    public int Id{get;set;}
    public int BaseCurrencyId{get;set;}
    public Currency BaseCurrency{get;set;}
    public int QuoteCurrencyId{get;set;}
    public Currency QuoteCurrency{get;set;}
    public double Value{get;set;}

    public Rate(int id, int baseCurrencyId, int quoteCurrencyId, double value)
    {
        Id = id;
        BaseCurrencyId = baseCurrencyId;
        QuoteCurrencyId = quoteCurrencyId;
        Value = value;
    }

    public override string ToString() 
    {
        return $"{Id} - [Base Currency : {BaseCurrency?.ToString()}] - [Quote Currency : {QuoteCurrency?.ToString()}] | {Value}";        
    }
}