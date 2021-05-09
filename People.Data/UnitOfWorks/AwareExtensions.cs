using People.Data.Entities.Interfaces;
using System;
using System.Threading;

namespace People.Data.UnitOfWorks
{
    public static class AwareExtensions
    {
        public static void SetCreated(this ICreateAware createAware)
        {
            createAware.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            createAware.CreatedOn = DateTimeOffset.UtcNow;
        }

        public static void SetModified(this IModifyAware modifyAware)
        {

            if (string.IsNullOrEmpty(modifyAware.CreatedBy))
                modifyAware.SetCreated();
            modifyAware.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;
            modifyAware.ModifiedOn = DateTimeOffset.UtcNow;
        }

        public static void SetDeleted(this IDeleteAware deleteAware)
        {
            if (deleteAware.Deleted)
                return;
            deleteAware.SetModified();
            deleteAware.Deleted = true;
        }

        public static bool IsDeleteAware(this Type type)
        {
            return type.GetInterface(nameof(IDeleteAware)) != null;
        }
        public static bool IsModifyAware(this Type type)
        {
            return type.GetInterface(nameof(IModifyAware)) != null;
        }

        public static bool IsCreateAware(this Type type)
        {
            return type.GetInterface(nameof(ICreateAware)) != null;
        }

        public static bool IsReadonly(this Type type)
        {
            return type.GetInterface(nameof(IReadonlyEntity)) != null;
        }

        public static bool CannotDelete(this Type type)
        {
            return type.GetInterface(nameof(ICannotDelete)) != null;
        }

    }
}
