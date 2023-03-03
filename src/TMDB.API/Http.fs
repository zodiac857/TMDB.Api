namespace TMDB.API

open System
open System.Collections.Generic
open System.Net
open System.Net.Http
open Microsoft.AspNetCore.WebUtilities
open Microsoft.FSharp.Control

type Response<'T> =
    { StatusCode: HttpStatusCode
      IsError: bool
      Payload: 'T option }

module Http =

    let private addQueryParameter (parameters: IDictionary<string, string>) (uri: Uri) =
        Uri(QueryHelpers.AddQueryString(uri.ToString(), parameters), UriKind.RelativeOrAbsolute)

    let createRequest (method: HttpMethod) (url: string) =
        new HttpRequestMessage(method = method, requestUri = Uri(url, UriKind.RelativeOrAbsolute))

    let withQueryParameter (parameter: string) (value: string) (request: HttpRequestMessage) =
        request.RequestUri <- (dict [ (parameter, value) ], request.RequestUri) ||> addQueryParameter
        request

    let withQueryParameters (parameters: IDictionary<string, string>) (request: HttpRequestMessage) =
        request.RequestUri <- addQueryParameter parameters request.RequestUri
        request

    let withRouteParameters (parameters: obj option) (request: HttpRequestMessage) =

        let interpolateUrl (request: HttpRequestMessage) (parameters: obj) =
            let currentUrl = request.RequestUri.ToString()
            let interpolatedUrl = StringInterpolation.interpolate currentUrl parameters
            Uri(interpolatedUrl, UriKind.RelativeOrAbsolute)

        request.RequestUri <-
            match parameters with
            | Some x -> interpolateUrl request x
            | None -> request.RequestUri

        request

    let getPayload (response: Response<HttpResponseMessage>) =
        response.Payload.Value.Content.ReadAsStringAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let send (client: HttpClient) (request: HttpRequestMessage) =
        backgroundTask {
            let! response = client.SendAsync request

            return
                if response.IsSuccessStatusCode then
                    { StatusCode = response.StatusCode
                      IsError = false
                      Payload = Some response }
                else
                    { StatusCode = response.StatusCode
                      IsError = true
                      Payload = Some response }
        }
