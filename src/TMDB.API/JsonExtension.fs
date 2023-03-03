namespace TMDB.API

open FSharp.Json

module JsonExtension =
        
        let private parseSettings = JsonConfig.create(allowUntyped = true)

        let serialize (data: 'T) =
            Json.serializeEx parseSettings data

        let deserialize<'T> (json: string) =
            Json.deserializeEx<'T> parseSettings json