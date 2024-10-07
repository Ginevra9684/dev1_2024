public class ProdottiViewModel
{
    public IEnumerable<Prodotto> Prodotti { get; set; }
    public int NumeroPagine { get; set; }
    public Prodotto? Prodotto { get; set; }
    public decimal? MinPrezzo { get; set; }
    public decimal? MaxPrezzo { get; set; }
}