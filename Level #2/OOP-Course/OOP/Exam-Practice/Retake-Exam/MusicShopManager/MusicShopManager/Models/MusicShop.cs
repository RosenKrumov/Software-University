﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class MusicShopClass : IMusicShop
    {
        public MusicShopClass(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name { get; set; }

        public IList<IArticle> Articles { get; set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name).AppendLine();
            if (this.Articles.Count == 0)
            {
                result.Append("The shop is empty. Come back soon.");
            }
            else
            {
                var menu = new List<string>();

                var microphones = this.Articles.Where(r => r is IMicrophone);
                AppendArticlesToMenu(menu, "Microphones", microphones);

                var drums = this.Articles.Where(r => r is IDrums);
                AppendArticlesToMenu(menu, "Drums", drums);

                var electricGuitars = this.Articles.Where(r => r is IElectricGuitar);
                AppendArticlesToMenu(menu, "Electric guitars", electricGuitars);

                var acousticGuitars = this.Articles.Where(r => r is IAcousticGuitar);
                AppendArticlesToMenu(menu, "Acoustic guitars", acousticGuitars);

                var bassGuitars = this.Articles.Where(r => r is IBassGuitar);
                if (bassGuitars.Any())
                {
                    AppendArticlesToMenu(menu, "Bass guitars", bassGuitars);
                }

                result.Append(string.Join(Environment.NewLine, menu));
            }

            return result.ToString();
        }

        private static void AppendArticlesToMenu(ICollection<string> menu, string title, IEnumerable<IArticle> articles)
        {
            if (articles.Any())
            {
                var sortedArticles = articles.OrderBy(a => a.Make + " " + a.Model).ToList();
                var articlestr = string.Format("{0} {1} {0}{2}{3}",
                    new string('-', 5),
                    title,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, sortedArticles));
                menu.Add(articlestr);
            }
        }
    }
}
