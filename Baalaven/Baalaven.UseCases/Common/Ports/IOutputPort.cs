using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.UseCases.Common.Ports
{
    public interface IOutputPort<InteractorResponseType>
    {
        void Handle(InteractorResponseType response);
    }
}
