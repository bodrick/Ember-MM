using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Ember.Plugins
{
    public enum PluginType
    {
        Scraper_MovieInfo,
        Scraper_MovieImage,
        Scraper_TVInfo,
        Scraper_TVImage,
    }

    /// <summary>
    /// The plug-in manager for Ember Media Manager.
    /// </summary>
    public class PluginManager
        : IDisposable
    {

        #region Fields

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<PluginManager.EmberPlugin> plugins = new List<PluginManager.EmberPlugin>();

        #endregion


        #region Properties

        public List<PluginManager.EmberPlugin> Plugins
        {
            get { return plugins; }
        }

        public Properties.Settings Settings
        {
            get { return Properties.Settings.Default; }
        }

        #endregion Properties


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        public PluginManager()
        {
            LoadPlugins();
        }

        #endregion Constructor


        #region Methods

        /// <summary>
        /// Loads and initialise plug-ins listed in the configuration file.
        /// </summary>
        private void LoadPlugins()
        {
            // Plug-ins loaded by Ember.Plugins.PluginSectionHandler
            List<IPlugin> loaded = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
            if (loaded == null || loaded.Count == 0)
                return;

            PluginManager.PluginComparer comparer = new PluginManager.PluginComparer();
            foreach (IPlugin plugin in loaded)
            {
                PluginType type;
                bool enabled = true;

                if (plugin is Scraper.IMovieInfoScraper)
                    type = PluginType.Scraper_MovieInfo;
                else if (plugin is Scraper.IMovieImageScraper)
                    type = PluginType.Scraper_MovieImage;
                else if (plugin is Scraper.ITVInfoScraper)
                    type = PluginType.Scraper_TVInfo;
                else if (plugin is Scraper.ITVImageScraper)
                    type = PluginType.Scraper_TVImage;
                else
                {
                    if (log.IsWarnEnabled)
                        log.WarnFormat(
                            "Load Plug-in :: Unknown plug-in {0}",
                            plugin.GetType().Name);
                    continue;
                }

                try
                {
                    string enabledProp = String.Format("Plugin__{0}__Enabled",
                        plugin.AssemblyName.Replace('.', '_'));
                    object value = Settings[enabledProp];
                    enabled = Convert.ToBoolean(value);
                }
                catch (SettingsPropertyNotFoundException) { }

                PluginManager.EmberPlugin ePlugin = new PluginManager.EmberPlugin(plugin, type, enabled);
                if (plugins.Contains(ePlugin, comparer))
                {
#if DEBUG
                    if (log.IsDebugEnabled)
                        log.DebugFormat(
                            "Load Plug-in :: Plugin already loaded. [{0}]",
                            plugin.GetType().Name);
#endif
                    continue;
                }

                plugins.Add(ePlugin);
                ePlugin.Plugin.InitPlugin(this);
            }
        }

        #endregion


        #region IDisposable

        #region Fields

        private bool disposed = false;

        #endregion


        #region Properties

        public bool IsDisposed
        {
            get { return disposed; }
        }

        #endregion Properties


        #region Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                disposed = true;

                // Free other state (managed objects).
                foreach (PluginManager.EmberPlugin plugin in plugins)
                {
                    if (plugin.Plugin is IDisposable)
                    {
                        IDisposable disposable = (IDisposable)plugin.Plugin;
                        disposable.Dispose();
                    }
                    plugins.Remove(plugin);
                }
            }

            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }

        ~PluginManager()
        {
            Dispose(false);
        }

        #endregion Methods

        #endregion IDisposable


        #region PluginManager.EmberPlugin

        public class EmberPlugin
        {

            #region Fields

            private IPlugin plugin;
            private PluginType type;
            private bool enabled;

            #endregion Fields

            #region Properties

            public IPlugin Plugin
            {
                get { return plugin; }
            }

            public PluginType Type
            {
                get { return type; }
            }

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            #endregion Properties

            #region Constructor

            public EmberPlugin(IPlugin plugin, PluginType type, bool enabled)
            {
                if (plugin == null)
                    throw new ArgumentNullException("plugin");

                this.plugin = plugin;
                this.type = type;
                this.enabled = enabled;
            }

            #endregion Constructor

        }

        private class PluginComparer
            : IEqualityComparer<EmberPlugin>
        {

            #region IEqualityComparer<Plugin>

            public bool Equals(EmberPlugin x, EmberPlugin y)
            {
                if (Object.ReferenceEquals(x, y)) return true;

                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return x.Plugin.GetType() == y.Plugin.GetType();
            }

            public int GetHashCode(EmberPlugin plugin)
            {
                if (Object.ReferenceEquals(plugin, null))
                    return 0;

                return plugin.Plugin.GetHashCode();
            }

            #endregion IEqualityComparer<Plugin>

        }

        #endregion PluginManager.Plugin

    }
}
