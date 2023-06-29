using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dz19_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("\nEnter task (1 - 2): ");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Fraction[] fractions;
                        Console.Write("\nEnter the number of fractions: ");
                        int count = int.Parse(Console.ReadLine());
                        fractions = new Fraction[count];

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Fraction {i + 1}:");
                            Console.Write("Number: ");
                            int numerator = int.Parse(Console.ReadLine());
                            Console.Write("Denominator: ");
                            int denominator = int.Parse(Console.ReadLine());

                            fractions[i] = new Fraction(numerator, denominator);
                        }

                        string path = @"D:\Games\Visual Studio\Dz19_\Dz19_\drib.dat";
                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            DataContractSerializer dcs = new DataContractSerializer(typeof(Fraction[]));
                            dcs.WriteObject(fs, fractions);
                        }
                        Console.WriteLine("Array was serialized");

                        path = @"D:\Games\Visual Studio\Dz19_\Dz19_\drib.dat";
                        Fraction[] loadedFractions;
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            DataContractSerializer dcs = new DataContractSerializer(typeof(Fraction[]));
                            loadedFractions = (Fraction[])dcs.ReadObject(fs);
                        }
                        Console.WriteLine("Array was loaded from file");

                        Console.WriteLine("Fractions loaded:");
                        foreach (Fraction fraction in loadedFractions)
                        {
                            Console.WriteLine(fraction);
                        }
                        break;
                    case 2:
                        Journal[] journals;

                        Console.Write("\nEnter the number of journals: ");
                        int number = int.Parse(Console.ReadLine());
                        journals = new Journal[number];

                        for (int i = 0; i < number; i++)
                        {
                            Console.WriteLine($"Journal {i + 1}:");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Publisher: ");
                            string publisher = Console.ReadLine();
                            Console.Write("Publication date: ");
                            string publicationDate = Console.ReadLine();
                            Console.Write("Page count: ");
                            int pageCount = int.Parse(Console.ReadLine());

                            Journal journal = new Journal(title, publisher, publicationDate, pageCount);

                            Console.Write("Enter the number of articles: ");
                            int articleCount = int.Parse(Console.ReadLine());

                            for (int j = 0; j < articleCount; j++)
                            {
                                Console.WriteLine($"Article {j + 1}:");
                                Console.Write("Title: ");
                                string articleTitle = Console.ReadLine();
                                Console.Write("Character count: ");
                                int characterCount = int.Parse(Console.ReadLine());
                                Console.Write("Announcement: ");
                                string announcement = Console.ReadLine();

                                Article article = new Article(articleTitle, characterCount, announcement);
                                journal.AddArticle(article);
                            }
                            journals[i] = journal;
                            Console.WriteLine();
                        }

                        string path2 = @"D:\Games\Visual Studio\Dz19_\Dz19_\journals.dat";
                        using (FileStream fs = new FileStream(path2, FileMode.Create))
                        {
                            DataContractSerializer dcs = new DataContractSerializer(typeof(Journal[]));
                            dcs.WriteObject(fs, journals);
                        }

                        Console.WriteLine("Array of journals was serialized\n");
                        Journal[] loadedJournals;
                        using (FileStream fs = new FileStream(path2, FileMode.Open))
                        {
                            DataContractSerializer dcs = new DataContractSerializer(typeof(Journal[]));
                            loadedJournals = (Journal[])dcs.ReadObject(fs);
                        }
                        Console.WriteLine("Array of journals was loaded from file\n");

                        Console.WriteLine("Journals loaded:\n");
                        foreach (Journal journal in loadedJournals)
                        {
                            journal.DisplayJournalInfo();
                            Console.WriteLine();
                        }
                        break;
                    default: Console.WriteLine("Error!"); break;
                }
            }
        }
    }
}