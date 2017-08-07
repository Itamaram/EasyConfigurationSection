# EasyConfigurationSection
This package attempts to greatly reduce the (boilerplate) code required to add a custom configuration section to a project.
Using EasyConfigurationSection, there's no need to create any object inherting from `ConfigurationSection` or `ConfigurationElement`. As long as your configuration object is deserialisable by `System.Xml.Serialization.XmlSerializer`, you're good to go! (Using your own custom parser is also supported)

# Example
## app.config
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="EasyConfiguration" type="EasyConfigurationSection.EasyConfigurationSection, EasyConfigurationSection" />
  </configSections>
  <EasyConfiguration>
    <MyConfiguration>
      <Foo>Bar</Foo>
    </MyConfiguration>
  </EasyConfiguration>
</configuration>
```
## Configuration Object Definition
```cs
public class Foo
{
    [XmlText]
    public string Content { get; set; }
}
```
## Consumption code
```cs
new EasyConfiguration().GetSection<Foo>("MyConfiguration").Content //returns "Bar";
```

# More features
It is possible to declare mlutiple sections under the `configSections` element, and then simply load them up via `new EasyConfiguration(name)`. Each `EasyConfiguration` can in turn contain several of its own sections.
Note: If no name is provided, the default `"EasyConfiguration"` is used, as in the above example
