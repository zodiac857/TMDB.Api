module internal JsonHelper

    open System
    open System.Text.RegularExpressions
    
    let toSingleLineString (json: string) =
        Regex.Replace(json, "[\n\s\r]+", " ")