using MediatR;

namespace Management.Common
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
