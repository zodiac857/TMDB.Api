module StringInterpolationTests

open Swensen.Unquote
open TMDB.API
open Xunit

[<Fact>]
let ``interpolate should return interpolated string with one parameter`` () =
    // Arrange
    let stringWithParameters = "Hello my name is {name}"
    let parameters = {|name = "F#"|}
    let expectedString = $"Hello my name is {parameters.name}"
    
    // Act
    let resultString = StringInterpolation.interpolate stringWithParameters parameters
    
    // Assert
    test <@ resultString = expectedString @>
    
[<Fact>]
let ``interpolate should return interpolated string with two parameters`` () =
    // Arrange
    let stringWithParameters = "Hello my name is {first_name} {second_name}"
    let parameters = {|first_name = "F#"
                       second_name = "from Microsoft"|}
    let expectedString = $"Hello my name is {parameters.first_name} {parameters.second_name}"
    
    // Act
    let resultString = StringInterpolation.interpolate stringWithParameters parameters
    
    // Assert
    test <@ resultString = expectedString @>
    
[<Fact>]
let ``interpolate should return the same string when no parameters`` () =
    // Arrange
    let stringWithParameters = "Hello my name is"
    let parameters = {|first_name = "F#"
                       second_name = "from Microsoft"|}
    let expectedString = $"Hello my name is"
    
    // Act
    let resultString = StringInterpolation.interpolate stringWithParameters parameters
    
    // Assert
    test <@ resultString = expectedString @>
    
[<Fact>]
let ``interpolate should return interpolated string with one correct parameters`` () =
    // Arrange
    let stringWithParameters = "Hello my name is {first_name} from some inc."
    let parameters = {|first_name = "F#"
                       second_name = "from Microsoft"|}
    let expectedString = $"Hello my name is {parameters.first_name} from some inc."
    
    // Act
    let resultString = StringInterpolation.interpolate stringWithParameters parameters
    
    // Assert
    test <@ resultString = expectedString @>

