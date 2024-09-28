class Transaction
{
    public int Id { get; set; }

    public User User { get; set; }

    public Subscription Subscription { get; set; }

    public DateTime Date { get; set; }
}