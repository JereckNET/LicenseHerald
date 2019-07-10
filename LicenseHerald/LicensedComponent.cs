using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JereckNET.LicenseHerald {
    public class LicensedComponent {
        public string Name {
            get;
            private set;
        }
        public Version Version {
            get;
            private set;
        }
        public string HomePage {
            get;
            private set;
        }
        public string License {
            get;
            private set;
        }

        internal LicensedComponent(string Name, Version Version, string HomePage, string License) {
            this.Name = Name;
            this.Version = Version;
            this.HomePage = HomePage;
            this.License = License;
        }

        internal static IList<LicensedComponent> FromAssembly(Assembly currentAssembly) {
            var components = from ComponentHeraldAttribute a
                             in currentAssembly.GetCustomAttributes(typeof(ComponentHeraldAttribute), false)
                             select a.Component;

            return components.ToList();
        }

        public override string ToString() {
            return Name;
        }
    }
}
