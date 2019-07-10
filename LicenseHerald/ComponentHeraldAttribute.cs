﻿using System;
using System.Reflection;
using System.Resources;

namespace JereckNET.LicenseHerald {
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ComponentHeraldAttribute : Attribute {
        private readonly string name;
        private readonly Type component;
        private readonly Type resources;
        private readonly string homePage;
        private readonly string licenseKey;

        public LicensedComponent Component {
            get {
                ResourceManager rm = new ResourceManager(resources.FullName, resources.Assembly);
                string license = rm.GetString(licenseKey);

                Version componentVersion = Assembly.GetAssembly(component).GetName().Version;

                return new LicensedComponent(name, componentVersion, homePage, license);
            }
        }

        public ComponentHeraldAttribute(string Name, Type Component, string HomePage, Type Resources, string LicenseKey) {
            name = Name;
            component = Component;
            homePage = HomePage;
            resources = Resources;
            licenseKey = LicenseKey;
        }
    }
}
