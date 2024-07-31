
namespace Core.Results.Abstracts
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
