namespace TMDB.API

open Microsoft.FSharp.Reflection

module StringInterpolation =
    
    let interpolate (input: string) (parameters: obj) =
        let fields = FSharpType.GetRecordFields(parameters.GetType())
        fields
            |> Seq.map (fun field ->
                let value = FSharpValue.GetRecordField(parameters, field).ToString()
                field.Name, value)
            |> dict
            |> Seq.fold (fun (state: string) parameter -> state.Replace( $"{{%s{parameter.Key}}}", parameter.Value)) input