using System;

using Unity;

namespace Dwelling.Api
{
    using Dwelling.Services;
    using Dwelling.IServices;
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
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IHouseService, HouseService>();
            container.RegisterType<IStyleService, StyleService>();
            container.RegisterType<IBuildingTypeService, BuildingTypeService>();
            container.RegisterType<IOrientationService, OrientationService>();
            container.RegisterType<ILeaseTypeService, LeaseTypeService>();
            container.RegisterType<IHabitableroomServices, HabitableRoomServices>();
            container.RegisterType<IPublishHouseService, PublishHouseService>();
            container.RegisterType<IFacilityService, FacilityService>();
            container.RegisterType<IPriceService, PriceService>();
            container.RegisterType<IAreaService, AreaService>();
            container.RegisterType<IImageService, ImageService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IPermissionService, PermissionService>();
            //container.RegisterType<IStyleService, StyleService>();
            //container.RegisterType<IStyleService, StyleService>();
        }
    }
}