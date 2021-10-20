
using DailyShop.DA.SQL;
using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using DailyShop.Serv;
using System;
using Unity;

namespace DailyShop.UI
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

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<Product>, SQLRep<Product>>();
            container.RegisterType<IRepository<ProdCat>, SQLRep<ProdCat>>();
            container.RegisterType<IRepository<Trolly>, SQLRep<Trolly>>();
            container.RegisterType<IRepository<TrollyItem>, SQLRep<TrollyItem>>();
            container.RegisterType<IRepository<Consumer>, SQLRep<Consumer>>();
            container.RegisterType<IRepository<TrollyOrder>, SQLRep<TrollyOrder>>();
            container.RegisterType<ITrollyServ, TrollyServ>();
            container.RegisterType<ITOrderServ, TOrderServ>();
        }
    }
}