using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models
{
    public class AnnouncementsInfo : BaseResponse
    {
        [JsonPropertyName("result")]
        public ContentAnnouncements Result { get; set; }
    }

    public class ContentAnnouncements
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("list")]
        public List<ContentAnnouncement> Announcements { get; set; }
    }

    public class ContentAnnouncement
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("dateTimestamp")]
        public long DateTimestamp { get; set; }

        [JsonPropertyName("startDateTimestamp")]
        public long StartDateTimestamp { get; set; }

        [JsonPropertyName("endDateTimestamp")]
        public long EndDateTimestamp { get; set; }
    }
}
