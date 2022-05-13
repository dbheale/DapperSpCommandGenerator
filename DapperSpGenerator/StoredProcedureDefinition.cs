namespace DapperSpGenerator;

internal class StoredProcedureDefinition
{
    public string? Schema { get; set; }
    public string? Procedure { get; set; }
    public string? ParameterName { get; set; }
    public string? Type { get; set; }
    public string? Length { get; set; }
    public int Precision { get; set; }
    public int Scale { get; set; }
    public bool IsNullable { get; set; }
    public int ParameterOrder { get; set; }
    public bool? IsOutput { get; set; }
}