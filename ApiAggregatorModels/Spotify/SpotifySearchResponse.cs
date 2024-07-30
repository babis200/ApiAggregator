using Newtonsoft.Json;

namespace ApiAggregatorModels.Spotify
{
    //TODO - split the models to different files
    public class SpotifySearchResponse
    {
        [JsonProperty("artists")]
        public ArtistsResponse Artists { get; set; }

        [JsonProperty("albums")]
        public AlbumsResponse Albums { get; set; }

        [JsonProperty("tracks")]
        public TracksResponse Tracks { get; set; }
    }

    public class ArtistsResponse
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<Artist> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Artist
    {
        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class AlbumsResponse
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<Album> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Album
    {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class TracksResponse
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<Track> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Track
    {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        [JsonProperty("external_ids")]
        public ExternalIds ExternalIds { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")]
        public object Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Image
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class ExternalIds
    {
        [JsonProperty("isrc")]
        public string Isrc { get; set; }
    }



}
