using JereckNET.LicenseHerald;

[assembly:ComponentHerald(
    "Newtonsoft.Json",
    typeof(Newtonsoft.Json.JsonConvert), // Can reference any type from the external component
    "https://www.newtonsoft.com/json",
    typeof(TestConsumer.Properties.Resources),
    nameof(TestConsumer.Properties.Resources.NewtonsoftJsonLicence)
    )]