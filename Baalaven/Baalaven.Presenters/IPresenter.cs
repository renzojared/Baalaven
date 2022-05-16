using Baalaven.UseCases.Common.Ports;

namespace Baalaven.Presenters
{
    public interface IPresenter<ResponseType, FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
