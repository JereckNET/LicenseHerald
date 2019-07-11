using JereckNET.LicenseHerald;
using LicenseHerald.Properties;

[assembly: ComponentHerald("License Herald",
    typeof(ComponentHeraldAttribute),
    "https://github.com/JereckNET/LicenseHerald",
    typeof(License),
    nameof(License.LicenseHerald))]
