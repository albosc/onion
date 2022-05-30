using System.Collections.ObjectModel;

namespace Application;

public class ResponseWrapper
{
    private readonly IList<string> _messages = new List<string>();

    public IEnumerable<string> Errors { get; }
    public object? Result { get; }

    public ResponseWrapper() => Errors = new ReadOnlyCollection<string>(_messages);

    public ResponseWrapper(object result) : this() => Result = result;

    public ResponseWrapper AddError(string message)
    {
        _messages.Add(message);
        return this;
    }
}
