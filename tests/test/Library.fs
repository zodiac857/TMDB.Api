module TelegramNotificationReportFactoryTest

open System
open System.Net.Http
open TMDB.API
open Xunit

[<Fact>]
let ``Test TMDB`` =
    // arrange
    let title = "Кіт"
    let page = Page(1)
    let language = Language.Ukrainian
    use httpClient = new HttpClient()
    let configuration = {
        BaseUrl = "https://api.themoviedb.org/3/search/movie"
        ApiKey = "f2b04d022cfe7dda48ab7ee2d80bf8af"
    }

    // act
    let response = TMDBClient.searchMovie title page language httpClient configuration

    // assert
    Assert.NotNull(response)