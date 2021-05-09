using AutoMapper;
using People.Data;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System;
using System.Data.Entity;
using Unity;

namespace Agents.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterInstance<DbContext>(new CompanyContext());
            container.RegisterType<IDataManagerUoW<Client>, DataManagerUoW<Client>>();
            container.RegisterType<IDataProviderUoW<Client>, DataProviderUoW<Client>>();
            container.RegisterType<IDataManagerUoW<Meeting>, DataManagerUoW<Meeting>>();
            container.RegisterInstance<IConfigurationProvider>(MapperConfig.CreateMapper(), new Unity.Lifetime.SingletonLifetimeManager());

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static class MapperConfig
        {
            public static MapperConfiguration CreateMapper()
            {
                var config = new MapperConfiguration(cfg=>
                {
                    cfg.AddMaps("People.Models");
                });
                return config;
            }
        }
    }
}