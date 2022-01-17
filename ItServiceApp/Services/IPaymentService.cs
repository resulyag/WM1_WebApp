namespace ItServiceApp.Services
{
    public interface IPaymentService
    {
        public void CheckInstallments(string binNumber, decimal price);
        public void Pay();
    }
}
