namespace TMDB.API

type Language = Language of string

module Language =
    
    let value (Language input) = input
    
    let English = Language("en")
    
    let Ukrainian = Language("uk")

