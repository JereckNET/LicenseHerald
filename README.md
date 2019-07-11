# ![License Herald Logo](images/Herald.png) License Herald

License Herald makes it easy to retrive the license information of the components used in your .NET project.

* [Installation](#installation)
* [User Guide](#user-guide)
  * [For the component developper](#for-the-component-developper)
  * [For the component consumer](#for-the-component-consumer)
  * [Components not using LicenceHerald](#components-not-using-LicenceHerald)
* [License](#license)

## Installation

| Component                     | Package                                                                                                                                              |
|-------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| `JereckNET.LicenseHerald` | [![LicenseHerald NuGet Package](https://img.shields.io/nuget/v/JereckNET.LicenseHerald.svg)](https://www.nuget.org/packages/JereckNET.LicenseHerald) |

Install License Herald by searching for 'LicenseHerald'  in the NuGet package manager, or using the Package Manager Console:

```
PM > Install-Package JereckNET.LicenseHerald
```


## User Guide

### For the component developper
First, you need to install the LicenseHerald package (see [Installation]("installation)).

Then you need to add  a public resource file in your project, and a string resource containing the text of your license.
![Public resource file](docs/PublicResource.png)

Finally, in your `AssemblyInfo.cs` file (for .NET Framework), or in any code file (for .NET Standard), add a reference to the License Herald namespace and the ComponentHerald attribute :
```csharp
using JereckNET.LicenseHerald;
...
[assembly: ComponentHerald("{Your project name}", typeof({YourComponentClass}), "{Your project homepage URL}", typeof({YourResourceClass}),  nameof({YourResourceLicenseName}))]
```

#### Sample `AssemblyInfo.cs`
```csharp
using JereckNET.LicenseHerald;
...
[assembly: ComponentHerald("My Project", 
    typeof(MyNamespace.MyProjectClass), 
    "https://www.exemple.com/MyProject", 
    typeof(MyProject.Properties.Resources), 
    nameof(MyProject.Properties.Resources.MyProject_License))]
```

### For the component consumer
First, you need to install the LicenseHerald package (see [Installation]("#installation)).

Anywhere in your code, you can call the extension method `GetLicensedComponent()` added to the `Assembly` class.

That method will iterate through the target assembly and all of its referenced assemblies and will return a `IList<LicensedComponent>` value.

The `LicensedComponent` class has four public properties :

Property | Description
-------- | -----------
Name | The name of the component, as described in the component's assembly's ComponentHerald attribute ;
Version | The version of the component, directly extracted from the component's assembly ;
HomePage | The project homepage url, as described in the component's assembly's ComponentHerald attribute ;
License | The text of the component's license, extracted from the component's public resource.

#### Sample consumer usage
![Sample "Licenses" form ](docs/LicenseForm.png)

As `GetLicensedComponent()`returns an `IList` object, it can be used to fill a drop-down list through its DataSource property.

```csharp
using JereckNET.LicenseHerald;
...
public Form1(){
    var components = Assembly.GetExecutingAssembly().GetLicensedComponent();

    comboBox1.DataSource = components;
}
...
private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e) {
	LicensedComponent component = comboBox1.SelectedItem as LicensedComponent;

	label1.Text = component.Version.ToString();
	linkLabel1.Text = component.HomePage;
	linkLabel1.Links.Clear();
	linkLabel1.Links.Add(new LinkLabel.Link {
		LinkData = component.HomePage
	});
	textBox1.Text = component.License;
}

```

### Components not using LicenceHerald
Let's be honest : not everyone is already using LicenseHerald (as of this writing, there is a total of one component : this one).

It is possible for a developper to add a LicensedComponent for an external component to his/her project by adding any number of `ComponentHeraldAttribute` to the project's `AssemblyInfo.cs` file.

The components declared within the executing assembly (i.e. your project's application assembly) will also be returned by `GetLicensedComponent()`.

#### Sample with Newtonsoft.Json
```csharp
using JereckNET.LicenseHerald;
...
[assembly:ComponentHerald(
    "Newtonsoft.Json",
    typeof(Newtonsoft.Json.JsonConvert), // Can reference any type from the external component
    "https://www.newtonsoft.com/json",
    typeof(MyProject.Properties.Resources),
    nameof(MyProject.Properties.Resources.NewtonsoftJsonLicence)
    )]
```

## License

License Herald is licensed under the MIT License - the details are at [LICENSE.md](LICENSE.md)