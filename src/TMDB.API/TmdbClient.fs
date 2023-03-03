namespace TMDB.API

open System.Net.Http

module TmdbClient =

    let getResponse<'TResult> route httpClient routeParameters queryParameters =
        Http.createRequest HttpMethod.Get route
        |> Http.withRouteParameters routeParameters
        |> Http.withQueryParameters queryParameters
        |> Http.send httpClient
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> Http.getPayload
        |> JsonExtension.deserialize<'TResult>

    let searchMovie title page language httpClient =
        task {

            let queryParameters =
                dict
                    [ ("language", Language.value language)
                      ("query", title)
                      ("page", (Page.value page).ToString())
                      ("include_adult", "false") ]

            return getResponse<PagedResult<SearchMovieResult>> Routes.searchMovie httpClient None queryParameters
        }

    let searchTvShow title page language httpClient =
        task {

            let queryParameters =
                dict
                    [ ("language", Language.value language)
                      ("query", title)
                      ("page", (Page.value page).ToString())
                      ("include_adult", "false") ]

            return getResponse<PagedResult<SearchTvShowResult>> Routes.searchTvShow httpClient None queryParameters
        }

    let getTvShowDetails (id: int) (language: Language) (httpClient: HttpClient) =
        task {

            let queryParameters = dict [ ("language", Language.value language) ]
            let routeParameters = Some({| tv_id = id |} :> obj)

            return getResponse<TvShowDetailsResult> Routes.getTvShowDetails httpClient routeParameters queryParameters
        }
        
    let getMovieDetails (id: int) (language: Language) (httpClient: HttpClient) =
        task {

            let queryParameters = dict [ ("language", Language.value language) ]
            let routeParameters = Some({| movie_id = id |} :> obj)

            return getResponse<MovieDetailsResult> Routes.getMovieDetails httpClient routeParameters queryParameters
        }