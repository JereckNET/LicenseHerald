using System.Collections.Generic;
using System.Reflection;

namespace JereckNET.LicenseHerald {
    public static class ComponentHeraldExtensions {
        private static Dictionary<string, List<LicensedComponent>> _cache = new Dictionary<string, List<LicensedComponent>>();

        public static IList<LicensedComponent> GetLicensedComponent(this Assembly sourceAssembly) {
            string sourceAssemblyName = sourceAssembly.GetName().FullName;

            if (!_cache.ContainsKey(sourceAssemblyName)) {
                List<LicensedComponent> components = new List<LicensedComponent>();

                components.AddRange(LicensedComponent.FromAssembly(sourceAssembly));

                foreach (AssemblyName referencedAssemblyName in sourceAssembly.GetReferencedAssemblies()) {
                    Assembly referencedAssembly = Assembly.Load(referencedAssemblyName);

                    components.AddRange(LicensedComponent.FromAssembly(referencedAssembly));
                }

                _cache.Add(sourceAssemblyName, components);
            }

            return _cache[sourceAssemblyName];
        }
    }
}
