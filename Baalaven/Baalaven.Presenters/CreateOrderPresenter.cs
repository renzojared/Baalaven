namespace Baalaven.Presenters
{
    public class CreateOrderPresenter : IPresenter<int, string>
    {
        public string Content { get; private set; }

        public void Handle(int response)
        {
            Content = $"Order ID: {response}";
        }
    }
}