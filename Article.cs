namespace sivers_comments
{
    public class Article
    {
        string Title { get; set; }
        string Url { get; set; }

        public Article(string title, string url) {
            Title = title;
            Url = url;
        }

        public override string ToString()
        {
            return (Title + " || " + Url);
        }
    }
}
