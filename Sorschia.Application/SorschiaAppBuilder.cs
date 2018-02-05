using System;

namespace Sorschia.Application
{
    public class SorschiaAppBuilder : ISorschiaAppBuilder
    {
        private SorschiaAppEnvironment AppEnvironment;
        public ISorschiaAppSettingLoader SettingLoader { get; set; }

        public void SetEnvironment(SorschiaAppEnvironment environment)
        {
            AppEnvironment = environment;
        }

        public ISorschiaApp Build()
        {
            var app = new SorschiaApp(Environment.CurrentDirectory, AppEnvironment);

            try
            {
                if (SettingLoader != null)
                {
                    SettingLoader.Load(app.Settings);
                }
            }
            catch (Exception ex)
            {
                throw SorschiaAppException.BuildingError(ex);
            }

            return app;
        }
    }
}
