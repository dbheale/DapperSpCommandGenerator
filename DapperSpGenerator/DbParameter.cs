namespace DapperSpGenerator;

public class DbParameter
{
    public DbParameter(string parameter, string parameterProper, string parameterType, string sqlType, string dbType, bool isOutput, int parameterIndex, string size)
    {
        Parameter = parameter;
        ParameterProper = parameterProper;
        ParameterType = parameterType;
        SqlType = sqlType;
        DbType = dbType;
        IsOutput = isOutput;
        ParameterIndex = parameterIndex;
        Size = size;
    }

    public string Parameter { get; }
    public string ParameterProper { get; }
    public string ParameterType { get; }
    public string SqlType { get; }
    public string DbType { get; }
    public bool IsOutput { get; }
    public int ParameterIndex { get; }
    public string Size { get; }

    public string Definition => $"{ParameterType} @{ParameterProper}";
    public string ConstructorDefinition => $"{ParameterType} @{ParameterProper.ToLowerFirstCharacter()}";
    public string ConstructorSetValues => $"this.{ParameterProper} = @{ParameterProper.ToLowerFirstCharacter()};";
    public string String => $"{ParameterProper}:{{{ParameterProper}}}";
    public string ParamString => $"@{ParameterProper} = {{{ParameterProper}}}";
    public string SetPropertiesBack => IsOutput ? $"{ParameterProper} = parameters.Get<{ParameterType}>(\"{Parameter}\");" : string.Empty;
    public string Properties => $"public {ParameterType} {ParameterProper} {{ get; {(IsOutput ? "internal set; " : string.Empty)}}}";
    public string SpParameter => $@"p.Add(""{Parameter}"", {ParameterProper}{(IsOutput ? $", direction: ParameterDirection.Output, size: {Size}, dbType: {DbType}" : string.Empty)});";
}
