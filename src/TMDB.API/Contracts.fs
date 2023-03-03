namespace TMDB.API

open FSharp.Json

type SearchMovieResult =
    { [<JsonField("adult")>]
      Adult: bool
      [<JsonField("backdrop_path")>]
      BackdropPath: string option
      [<JsonField("genre_ids")>]
      GenreIds: int list
      [<JsonField("id")>]
      Id: int
      [<JsonField("original_language")>]
      OriginalLanguage: string
      [<JsonField("original_title")>]
      OriginalTitle: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("popularity")>]
      Popularity: double
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("release_date")>]
      ReleaseDate: string
      [<JsonField("title")>]
      Title: string
      
      [<JsonField("vote_average")>]
      VoteAverage: double
      [<JsonField("vote_count")>]
      VoteCount: int }
    
type SearchTvShowResult =
    { [<JsonField("adult")>]
      Adult: bool
      [<JsonField("backdrop_path")>]
      BackdropPath: string option
      [<JsonField("genre_ids")>]
      GenreIds: int list
      [<JsonField("id")>]
      Id: int
      [<JsonField("origin_country")>]
      OriginCountry: string list
      [<JsonField("original_language")>]
      OriginalLanguage: string
      [<JsonField("original_name")>]
      OriginalName: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("popularity")>]
      Popularity: double
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("first_air_date")>]
      FirstAirDate: string
      [<JsonField("name")>]
      Name: string
      [<JsonField("vote_average")>]
      VoteAverage: double
      [<JsonField("vote_count")>]
      VoteCount: int }

type PagedResult<'T> =
    { [<JsonField("page")>]
      Page: int
      [<JsonField("results")>]
      Results: 'T list
      [<JsonField("total_pages")>]
      TotalPages: int
      [<JsonField("total_results")>]
      TotalResults: int }
    
type CreatorResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("credit_id")>]
      CreditId: string
      [<JsonField("name")>]
      Name: string
      [<JsonField("gender")>]
      Gender: int
      [<JsonField("profile_path")>]
      ProfilePath: string }
    
type GenreResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("name")>]
      Name: string }
    
type EpisodeToAirResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("name")>]
      Name: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("vote_average")>]
      VoteAverage: double
      [<JsonField("vote_count")>]
      VoteCount: int
      [<JsonField("air_date")>]
      AirDate: string
      [<JsonField("episode_number")>]
      EpisodeNumber: int
      [<JsonField("production_code")>]
      ProductionCode: string
      [<JsonField("runtime")>]
      Runtime: int option
      [<JsonField("season_number")>]
      SeasonNumber: int
      [<JsonField("show_id")>]
      ShowId: int
      [<JsonField("still_path")>]
      StillPath: string option }
    
type NetworkResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("logo_path")>]
      LogoPath: string
      [<JsonField("name")>]
      Name: string
      [<JsonField("origin_country")>]
      OriginCountry: string }
    
type ProductionCompanyResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("logo_path")>]
      LogoPath: string option
      [<JsonField("name")>]
      Name: string
      [<JsonField("origin_country")>]
      OriginCountry: string }
    
type ProductionCountryResult =
    { [<JsonField("iso_3166_1")>]
      Iso3166_1: string
      [<JsonField("name")>]
      Name: string }
    
type SeasonResult =
    { [<JsonField("air_date")>]
      AirDate: string
      [<JsonField("episode_count")>]
      EpisodeCount: int
      [<JsonField("id")>]
      Id: int
      [<JsonField("name")>]
      Name: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("season_number")>]
      SeasonNumber: int }
    
type SpokenLanguageResult =
    { [<JsonField("english_name")>]
      EnglishName: string
      [<JsonField("iso_639_1")>]
      Iso639_1: string
      [<JsonField("name")>]
      Name: string }
    
type TvShowDetailsResult =
    { [<JsonField("adult")>]
      Adult: bool
      [<JsonField("backdrop_path")>]
      BackdropPath: string
      [<JsonField("created_by")>]
      CreatedBy: CreatorResult list
      [<JsonField("episode_run_time")>]
      EpisodeRunTime: int list
      [<JsonField("first_air_date")>]
      FirstAirDate: string
      [<JsonField("genres")>]
      Genres: GenreResult list
      [<JsonField("homepage")>]
      Homepage: string
      [<JsonField("id")>]
      Id: int
      [<JsonField("in_production")>]
      InProduction: bool
      [<JsonField("languages")>]
      Languages: string list
      [<JsonField("last_air_date")>]
      LastAirDate: string
      [<JsonField("last_episode_to_air")>]
      LastEpisodeToAir: EpisodeToAirResult
      [<JsonField("name")>]
      Name: string
      [<JsonField("next_episode_to_air")>]
      NextEpisodeToAir: EpisodeToAirResult option
      [<JsonField("networks")>]
      Networks: NetworkResult list
      [<JsonField("number_of_episodes")>]
      NumberOfEpisodes: int
      [<JsonField("number_of_seasons")>]
      NumberOfSeasons: int
      [<JsonField("origin_country")>]
      OriginCountry: string list
      [<JsonField("original_language")>]
      OriginalLanguage: string
      [<JsonField("original_name")>]
      OriginalName: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("popularity")>]
      Popularity: double
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("production_companies")>]
      ProductionCompanies: ProductionCompanyResult list
      [<JsonField("production_countries")>]
      ProductionCountries: ProductionCountryResult list
      [<JsonField("seasons")>]
      Seasons: SeasonResult list
      [<JsonField("spoken_languages")>]
      SpokenLanguages: SpokenLanguageResult list
      [<JsonField("status")>]
      Status: string
      [<JsonField("tagline")>]
      Tagline: string
      [<JsonField("type")>]
      Type: string
      [<JsonField("vote_average")>]
      VoteAverage: double
      [<JsonField("vote_count")>]
      VoteCount: int }
    
type BelongsToCollectionResult =
    { [<JsonField("id")>]
      Id: int
      [<JsonField("name")>]
      Name: string
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("backdrop_path")>]
      BackdropPath: string }
    
type MovieDetailsResult =
    { [<JsonField("adult")>]
      Adult: bool
      [<JsonField("backdrop_path")>]
      BackdropPath: string
      [<JsonField("belongs_to_collection")>]
      BelongsToCollection: BelongsToCollectionResult
      [<JsonField("budget")>]
      Budget: int
      [<JsonField("genres")>]
      Genres: GenreResult list
      [<JsonField("homepage")>]
      Homepage: string
      [<JsonField("id")>]
      Id: int
      [<JsonField("imdb_id")>]
      ImdbId: string
      [<JsonField("original_language")>]
      OriginalLanguage: string
      [<JsonField("original_title")>]
      OriginalTitle: string
      [<JsonField("overview")>]
      Overview: string
      [<JsonField("popularity")>]
      Popularity: double
      [<JsonField("poster_path")>]
      PosterPath: string
      [<JsonField("production_companies")>]
      ProductionCompanies: ProductionCompanyResult list
      [<JsonField("production_countries")>]
      ProductionCountries: ProductionCountryResult list
      [<JsonField("release_date")>]
      ReleaseDate: string
      [<JsonField("revenue")>]
      Revenue: int
      [<JsonField("runtime")>]
      Runtime: int
      [<JsonField("spoken_languages")>]
      SpokenLanguages: SpokenLanguageResult list
      [<JsonField("status")>]
      Status: string
      [<JsonField("tagline")>]
      Tagline: string
      [<JsonField("title")>]
      Title: string
      [<JsonField("video")>]
      HasVideo: bool
      [<JsonField("vote_average")>]
      VoteAverage: double
      [<JsonField("vote_count")>]
      VoteCount: int }

type Page = Page of int

module Page =

    let value (Page input) = input