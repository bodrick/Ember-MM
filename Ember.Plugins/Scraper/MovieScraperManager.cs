using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ember.Plugins.Scraper
{
    public class MovieScraperManager
        : IMovieInfoScraper, IMovieImageScraper
    {

        #region Fields

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PluginManager manager;

        #endregion Fields


        #region Constructor

        internal MovieScraperManager(PluginManager manager)
        {
            this.manager = manager;
        }

        #endregion Constructor


        #region IMovieInfoScraper

        public PluginActionResult ScrapeMovieInfo(MovieInfoScraperActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (manager.Plugins.Count == 0)
                return new PluginActionResult();

            PluginActionResult result = null;

            foreach (IMovieInfoScraper plugin in manager.Plugins
                .Where(p => PluginType.Scraper_MovieInfo.Equals(p.Type))
                .OrderBy(p => p.Order)
                .Select(p => p.Plugin))
            {
                result = plugin.ScrapeMovieInfo(context);
                if (result != null && result.BreakChain) break;
            }

            if (result == null)
                result = new PluginActionResult();

            return result;
        }

        #endregion IMovieInfoScraper

    }
}
