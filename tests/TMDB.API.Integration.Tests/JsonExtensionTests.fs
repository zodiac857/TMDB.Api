module JsonExtensionTest

open Swensen.Unquote
open TMDB.API
open Xunit

type Person = { Name: string; Age: int }

[<Fact>]
let ``serialize should produce a valid json string based on given object`` () =
    // Arrange
    let person = { Name = "John"; Age = 30 }
    let expectedJson = """{ "Name": "John", "Age": 30 }"""
    
    // Act
    let json = JsonExtension.serialize person |> JsonHelper.toSingleLineString
    
    // Assert
    test <@ json <> "" @>
    test <@ json = expectedJson @>

[<Fact>]
let ``deserialize should produce the corresponding object based on given json string`` () =
    // Arrange
    let expectedPerson = { Name = "John"; Age = 30 }
    let json = """{ "Name": "John", "Age": 30 }"""

    // Act
    let person = JsonExtension.deserialize<Person> json

    // Assert
    test <@ person = expectedPerson @>

