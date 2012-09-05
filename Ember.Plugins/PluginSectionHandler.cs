using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace Ember.Plugins
{
    /// <summary>
    /// A class to parse plugins section from Application Config
    /// </summary>
    public class PluginSectionHandler
        : IConfigurationSectionHandler
    {

        #region Fields

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginSectionHandler"/> class.
        /// </summary>
        public PluginSectionHandler()
        {
        }

        #endregion


        #region IConfigurationSectionHandler

        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>
        /// The created section handler object.
        /// </returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<IPlugin> plugins = new List<IPlugin>();

            if (!Properties.Settings.Default.AllowPlugins)
            {
#if DEBUG
                if (log.IsDebugEnabled) log.Debug("Load Plug-in :: Plug-ins disabled.");
#endif
                return plugins;
            }

            foreach (XmlNode node in section.ChildNodes)
            {
                string className = null;
                try
                {
                    className = node.Attributes["class"].Value;
                    if (string.IsNullOrEmpty(className)) continue;

#if DEBUG
                    if (log.IsDebugEnabled)
                        log.Debug(string.Format("Load Plug-in :: ClassName = {0}", className));
#endif

                    object pluginObject = Activator.CreateInstance(Type.GetType(className));
                    if (pluginObject == null || !(pluginObject is IPlugin)) continue;

                    IPlugin plugin = (IPlugin)pluginObject;
                    plugins.Add(plugin);
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled) {
                        string mesg;
                        if (className == null)
                            mesg = "Plug-in configuration error.";
                        else
                            mesg = String.Format("Unable to load plug-in {0}", className);

                        log.Error(mesg, ex);
                    }
                }
            }

            return plugins;
        }

        #endregion

    }
}
