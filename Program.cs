using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace sivers_comments
{
    public class Program
    {
        const string SITE_URL = @"https://sive.rs";
        const string BLOG_URL = SITE_URL + @"/blog";
        const string ARTICLE_LIST_NODE = @"//div[@id='content']/ul/li";

        public static void Main(string[] args)
        {
            // ----- Get the web page ------
            HtmlWeb web = new HtmlWeb();
            var blogPage = web.Load(BLOG_URL);
            var blogArticles = blogPage.DocumentNode.SelectNodes(ARTICLE_LIST_NODE);

            // ----- Extract the articles and put them into the article list -----
            List<Article> articleList = new List<Article>();
            foreach(HtmlNode article in blogArticles)
            {
                articleList.Add(new Article(
                    HtmlEntity.DeEntitize(article.InnerText),
                    (SITE_URL + article.FirstChild.Attributes["href"].Value))
                );
            }

            // ----- Print the list of article titles with the url -----
            foreach (Article article in articleList) {
                Console.WriteLine(article);
            }
        }   
    }
}
