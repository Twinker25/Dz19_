using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dz19_
{
    [DataContract]
    public class Journal
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Publisher { get; set; }

        [DataMember]
        public string PublicationDate { get; set; }

        [DataMember]
        public int PageCount { get; set; }

        [DataMember]
        public List<Article> Articles { get; set; }

        public Journal(string title, string publisher, string publicationDate, int pageCount)
        {
            Title = title;
            Publisher = publisher;
            PublicationDate = publicationDate;
            PageCount = pageCount;
            Articles = new List<Article>();
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }

        public void DisplayJournalInfo()
        {
            Console.WriteLine("Journal information:");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Publication Date: {PublicationDate}");
            Console.WriteLine($"Page Count: {PageCount}");
            Console.WriteLine();

            Console.WriteLine("Articles:");
            foreach (Article article in Articles)
            {
                article.DisplayArticleInfo();
                Console.WriteLine();
            }
        }
    }

    [DataContract]
    public class Article
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int CharacterCount { get; set; }

        [DataMember]
        public string Announcement { get; set; }

        public Article(string title, int characterCount, string announcement)
        {
            Title = title;
            CharacterCount = characterCount;
            Announcement = announcement;
        }

        public void DisplayArticleInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Character Count: {CharacterCount}");
            Console.WriteLine($"Announcement: {Announcement}");
        }
    }
}
