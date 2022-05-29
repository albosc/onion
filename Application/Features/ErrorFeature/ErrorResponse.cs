namespace Application.Features.ErrorFeature;

public class ErrorModel
{
    public string FieldName { get; set; } = null!;
    public string Message { get; set; } = null!;
}

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = new();

}
