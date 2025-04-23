namespace VHS.Client.Common
{
    public class TitleUrl
    {
        public string Title { get; }
        public string Url { get; }

        public TitleUrl(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
