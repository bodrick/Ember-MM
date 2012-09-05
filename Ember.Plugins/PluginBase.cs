namespace Ember.Plugins
{
    public abstract class PluginBase
        : IPlugin
    {

        #region IPlugin

        #region Fields

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PluginManager manager;

        #endregion Fields


        #region Properties

        public abstract string Name
        {
            get;
        }

        public string AssemblyName
        {
            get { return GetType().Assembly.GetName().Name; }
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        public PluginManager PluginManager
        {
            get { return manager; }
        }

        #endregion Properties


        #region Methods

        public virtual void InitPlugin(PluginManager manager)
        {
            this.manager = manager;

#if DEBUG
            if (log.IsDebugEnabled)
                log.Debug(string.Format(
                    "InitPlugin :: Assembly = {0}; Name = {1}; Version = {2}",
                    AssemblyName, Name, Version));
#endif
        }

        #endregion Methods

        #endregion IPlugin

    }
}
