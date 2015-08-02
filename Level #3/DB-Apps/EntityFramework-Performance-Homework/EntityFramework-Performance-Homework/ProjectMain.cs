namespace EntityFramework_Performance_Homework
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    class ProjectMain
    {
        static void Main()
        {
            var context = new AdsEntities();

            //Problem1GetAdsNoInclude(context);

            //Problem1GetAdsWithInclude(context);

            //context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            //Problem2GetAllAdsNonOptimized(context);

            //Problem2GetAllAdsOptimized(context);

            //context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            //Problem3PrintAdTitleNonOptimized(context);

            //Problem3PrintAdTitleOptimized(context);
        }

        private static void Problem3PrintAdTitleOptimized(AdsEntities context)
        {
            var sw = new Stopwatch();
            var count = context.Ads.Count();
            sw.Start();

            var ads = context.Ads
                .Select(a => new {a.Title})
                .ToList();

            //foreach (var ad in ads)
            //{
            //    //Console.WriteLine(ad.Title); //Slows the time!
            //}

            Console.WriteLine("Optimized: " + sw.Elapsed);
        }

        private static void Problem3PrintAdTitleNonOptimized(AdsEntities context)
        {
            var sw = new Stopwatch();
            var count = context.Ads.Count();
            sw.Start();

            var ads = context.Ads.ToList();

            //foreach (var ad in ads)
            //{
            //    //Console.WriteLine(ad.Title); //Slows the time!
            //}

            Console.WriteLine("Non optimized: " + sw.Elapsed);
        }

        private static void Problem2GetAllAdsOptimized(AdsEntities context)
        {
            var sw = new Stopwatch();
            var count = context.Ads.Count();
            sw.Start();
            var ads = context.Ads
                .Where(a => a.AdStatuses.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    Category = a.Categories,
                    Town = a.Towns
                })
                .ToList();
            Console.WriteLine("Optimized: " + sw.Elapsed);
        }

        private static void Problem2GetAllAdsNonOptimized(AdsEntities context)
        {
            var sw = new Stopwatch();
            var count = context.Ads.Count();
            sw.Start();
            var ads = context.Ads
                .ToList()
                .Where(a => a.AdStatuses.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    Category = a.Categories,
                    Town = a.Towns,
                    a.Date
                })
                .ToList()
                .OrderBy(a => a.Date);
            Console.WriteLine("Non optimized: " + sw.Elapsed);
        }

        private static void Problem1GetAdsWithInclude(AdsEntities context)
        {
            var ads = context.Ads
                .Include(a => a.AdStatuses)
                .Include(a => a.Categories)
                .Include(a => a.Towns)
                .Include(a => a.AspNetUsers);

            foreach (var ad in ads)
            {
                var category = ad.CategoryId == null ? "no category" : context.Categories.Find(ad.CategoryId).Name;
                var town = ad.TownId == null ? "no town" : context.Towns.Find(ad.TownId).Name;
                Console.WriteLine("Title: {0}\n" +
                                  "Status: {1}\n" +
                                  "Category: {2}\n" +
                                  "Town: {3}\n" +
                                  "User: {4}\n" +
                                  "-----------",
                    ad.Title,
                    ad.AdStatuses.Status,
                    category,
                    town,
                    ad.AspNetUsers.Name);
            }
        }

        private static void Problem1GetAdsNoInclude(AdsEntities context)
        {
            var ads = context.Ads;

            foreach (var ad in ads)
            {
                var category = ad.CategoryId == null ? "no category" : context.Categories.Find(ad.CategoryId).Name;
                var town = ad.TownId == null ? "no town" : context.Towns.Find(ad.TownId).Name;
                Console.WriteLine("Title: {0}\n" +
                                  "Status: {1}\n" +
                                  "Category: {2}\n" +
                                  "Town: {3}\n" +
                                  "User: {4}\n" +
                                  "-----------",
                    ad.Title,
                    ad.AdStatuses.Status,
                    category,
                    town,
                    ad.AspNetUsers.Name);
            }
        }
    }
}
