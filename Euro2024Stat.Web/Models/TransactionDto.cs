namespace Euro2024Stat.Web.Models
{
    public class TransactionDto
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDatetime { get; set; }

        public TransactionDto(string userID, string userName, string transactionType, decimal amount)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.TransactionDatetime = DateTime.Now;
        }
    }
}
