module HttpTests

open System.Net
open System.Net.Http
open Swensen.Unquote
open TMDB.API
open Xunit

let testUrl = "https://www.google.com/"
let testClient = new HttpClient()


[<Fact>]
let ``createRequest should return a new HttpRequestMessage`` () =
    // arrange
    let method = HttpMethod.Post
    let url = "https://www.example.com/api/test"
    
    // act
    let request = Http.createRequest method url
    
    // assert
    test <@ request.Method = method @>
    test <@ request.RequestUri.ToString() = url @>

[<Fact>]
let ``withQueryParameter should add a query parameter to the request URL`` () =
    // arrange
    let parameter = "test"
    let value = "123"
    let expectedUrl = $"{testUrl}?{parameter}={value}"
    let testRequest = Http.createRequest HttpMethod.Get testUrl

    // act
    let resultRequest = Http.withQueryParameter parameter value testRequest
    
    // assert
    test <@ resultRequest.RequestUri.ToString() = expectedUrl @>

[<Fact>]
let ``withQueryParameters should add multiple query parameters to the request URL`` () =
    // arrange
    let parameters = dict [ "test1", "123"; "test2", "456" ]
    let expectedUrl = $"{testUrl}?test1=123&test2=456"
    let testRequest = Http.createRequest HttpMethod.Get testUrl

    // act
    let resultRequest = Http.withQueryParameters parameters testRequest
    
    // assert
    test <@ resultRequest.RequestUri.ToString() = expectedUrl @>

[<Fact>]
let ``getPayload should return the response content as a string`` () =
    // arrange
    let responseBody = "test response body"
    let response = new HttpResponseMessage(HttpStatusCode.OK)
    response.Content <- new StringContent(responseBody)

    // act
    let result = Http.getPayload { StatusCode = HttpStatusCode.OK; IsError = false; Payload = Some response }
    
    // assert
    test <@ result = responseBody @>