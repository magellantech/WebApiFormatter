

namespace WebApiFormatter.Helpers.Interfaces
{
    public interface IValidator
    {
        bool IsDataVald { get; }
        bool IsNumeric { get; }
        string GetData();
    }
}
