using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Ember.Plugins
{
    public enum PluginType
    {
        Unknown,
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

        #region Events

        /// <summary>
        /// Occurs when a plugin wants to show a form on the UI thread.
        /// </summary>
        public event Events.ShowFormOnUIThreadHandler ShowFormOnUIThread;

        #endregion Events


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
        }

        #endregion Constructor


        #region Methods

        /// <summary>
        /// Loads and initialise plug-ins listed in the configuration file.
        /// </summary>
        public void LoadPlugins()
        {
            // Plug-ins loaded by Ember.Plugins.PluginSectionHandler
            List<IPlugin> loaded = (List<IPlugin>)ConfigurationManager.GetSection("plugins");
            if (loaded == null || loaded.Count == 0)
                return;

            foreach (IPlugin plugin in loaded)
            {
                bool enabled = true;
                int order = 0;

                string pluginProp = plugin.AssemblyName.Replace('.', '_');
                try
                {
                    string prop = String.Format("Plugin__{0}__Enabled", pluginProp);
                    object value = Settings[prop];
                    enabled = Convert.ToBoolean(value);
                }
                catch (SettingsPropertyNotFoundException) { }
                try
                {
                    string prop = String.Format("Plugin__{0}__Order", pluginProp);
                    object value = Settings[prop];
                    order = Convert.ToInt32(value);
                }
                catch (SettingsPropertyNotFoundException) { }

                PluginManager.EmberPlugin ePlugin = new PluginManager.EmberPlugin(plugin, enabled, order);
                if (PluginType.Unknown.Equals(ePlugin.Type))
                {
                    if (log.IsWarnEnabled)
                        log.WarnFormat(
                            "Load Plug-in :: Unknown plug-in. [{0}]",
                            plugin.GetType().Name);
                    continue;
                }
                if (plugins.Contains(ePlugin))
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

            plugins.Sort();
        }

        /// <summary>
        /// Show a form on the UI thread.
        /// </summary>
        /// <param name="plugin">The plugin making the call.</param>
        /// <param name="form">The form to show.</param>
        /// <param name="asDialog">if set to <c>true</c> as show as a dialog.</param>
        public void ShowForm(IPlugin plugin, Form form, bool asDialog)
        {
            if (ShowFormOnUIThread != null)
                ShowFormOnUIThread(plugin, new Events.ShowFormOnUIThreadEventArgs(form, asDialog));
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

                    foreach (Delegate d in ShowFormOnUIThread.GetInvocationList())
                        ShowFormOnUIThread -= (Events.ShowFormOnUIThreadHandler)d;
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
            : IComparable<EmberPlugin>, IEquatable<EmberPlugin>
        {

            #region Fields

            private IPlugin plugin;
            private PluginType type;
            private bool enabled;
            private int order;

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

            public int Order
            {
                get { return order; }
                set { order = value; }
            }

            #endregion Properties

            #region Constructor

            public EmberPlugin(IPlugin plugin, bool enabled, int order)
            {
                if (plugin == null)
                    throw new ArgumentNullException("plugin");

                this.plugin = plugin;
                this.enabled = enabled;
                this.order = order;

                if (plugin is Scraper.IMovieInfoScraper)
                    this.type = PluginType.Scraper_MovieInfo;
                else if (plugin is Scraper.IMovieImageScraper)
                    this.type = PluginType.Scraper_MovieImage;
                else if (plugin is Scraper.ITVInfoScraper)
                    this.type = PluginType.Scraper_TVInfo;
                else if (plugin is Scraper.ITVImageScraper)
                    this.type = PluginType.Scraper_TVImage;
                else
                    this.type = PluginType.Unknown;
            }

            #endregion Constructor

            #region IComparable<EmberPlugin>

            public int CompareTo(EmberPlugin other)
            {
                if (other == null)
                    return 0;

                return this.Order.CompareTo(other.Order);
            }

            #endregion IComparable<EmberPlugin>

            #region IEquatable<EmberPlugin>

            public bool Equals(EmberPlugin other)
            {
                if (Object.ReferenceEquals(this, other))
                    return true;

                if (Object.ReferenceEquals(other, null))
                    return false;

                return this.Plugin.GetType() == other.Plugin.GetType();
            }

            #endregion IEquatable<EmberPlugin>

        }

        #endregion PluginManager.Plugin

    }
}
