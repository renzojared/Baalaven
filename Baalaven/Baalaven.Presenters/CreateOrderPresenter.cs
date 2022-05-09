using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
