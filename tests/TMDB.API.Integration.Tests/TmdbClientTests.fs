module TmdbClientTests

open System
open System.Net.Http
open System.Net.Http.Headers
open Swensen.Unquote
open TMDB.API
open Xunit

let bearerToken = "set yor token"
let httpClient = new HttpClient()
httpClient.BaseAddress <- Uri("https://api.themoviedb.org", UriKind.RelativeOrAbsolute)
httpClient.DefaultRequestHeaders.Authorization <- AuthenticationHeaderValue("Bearer", bearerToken);

[<Fact>]
let ``searchMovie should return the valid paged response, where first is Puss in Boots: The Last Wish`` () = task {
    // arrange
    let title = "Кіт"
    let page = Page(1)
    let language = Language.Ukrainian

    // act
    let! response = TmdbClient.searchMovie title page language httpClient

    // assert
    test <@ response.Page = 1 @>
    test <@ response.TotalPages = 2 @>
    test <@ response.TotalResults = 24 @>
    test <@ response.Results[0].Title = "Кіт у чоботях 2: Останнє бажання" @>
}

[<Fact>]
let ``searchTvShow should return the valid paged response, where first is Supernatural`` () = task {
    // arrange
    let title = "Надприро"
    let page = Page(1)
    let language = Language.Ukrainian

    // act
    let! response = TmdbClient.searchTvShow title page language httpClient

    // assert
    test <@ response.Page = 1 @>
    test <@ response.TotalPages = 1 @>
    test <@ response.TotalResults = 3 @>
    test <@ response.Results[0].Name = "Надприродне" @>
}

[<Fact>]
let ``getTvShowDetails should return the detailed information about Supernatural tv show`` () = task {
    // arrange
    let id = 1622
    let language = Language.Ukrainian

    // act
    let! response = TmdbClient.getTvShowDetails id language httpClient

    // assert
    test <@ response.Id = 1622 @>
    test <@ response.OriginalName = "Supernatural" @>
    test <@ response.NumberOfEpisodes = 327 @>
    test <@ response.NumberOfSeasons = 15 @>
}

[<Fact>]
let ``getMovieDetails should return the detailed information about Puss in Boots: The Last Wish movie`` () = task {
    // arrange
    let id = 315162
    let language = Language.Ukrainian

    // act
    let! response = TmdbClient.getMovieDetails id language httpClient

    // assert
    test <@ response.Id = 315162 @>
    test <@ response.OriginalTitle = "Puss in Boots: The Last Wish" @>
    test <@ response.ImdbId = "tt3915174" @>
}