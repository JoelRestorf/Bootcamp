using FuncaoClipping.Dominio;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace FuncaoClipping
{
    public class NewsApi
    {
        private const string newsApiGoogle = "https://newsapi.org/v2/everything";
        private const string token = "a6b4a886693649f9ae4aa9f8653147df";
        private const string language = "pt";

        public static void BuscaNoticiasTermoPackage(string termo, DateTime dataInicial)
        {
            // init with your API key
            var newsApiClient = new NewsApiClient(token);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = termo,
                SortBy = SortBys.Relevancy,
                Language = Languages.PT,
                From = dataInicial
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);

                try
                {
                    using (var context = new Contexto.Contexto())
                    {
                        foreach (var article in articlesResponse.Articles)
                        {
                            if (article.Title != null)
                            {
                                context.Noticias.Add(new Contexto.Noticias
                                {
                                    Autor = article.Author,
                                    Conteudo = article.Content.Substring(0, article.Content.Length > 350 ? 349 : article.Content.Length - 1),
                                    DataPublicacao = article.PublishedAt ?? DateTime.Now,
                                    Descricao = article.Description.Substring(0, article.Description.Length > 250 ? 249 : article.Description.Length - 1),
                                    Fonte = article.Source.Name,
                                    ImagemURL = article.UrlToImage,
                                    Titulo = article.Title,
                                    URL = article.Url

                                });
                            }
                        }

                        context.SaveChanges();
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Erro:" + ex.Message);
                }
            }
        }
    }
}
