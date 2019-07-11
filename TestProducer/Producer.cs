using JereckNET.LicenseHerald;
using TestProducer.Properties;

[assembly: ComponentHerald("License Herald Test Producer",
    typeof(TestProducer.Producer),
    "https://github.com/JereckNET/LicenseHerald",
    typeof(Resources),
    nameof(Resources.Producer_License))]

namespace TestProducer {
    public class Producer {
        public Producer() {

        }
    }
}