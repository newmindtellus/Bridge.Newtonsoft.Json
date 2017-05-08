Provides Bridge support for a limited subset of the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) API.

**NOTE:** Only the features listed below are supported.

## Installation

Install using [NuGet](https://www.nuget.org/):

```
Install-Package Bridge.Newtonsoft.Json
```

## JsonConvert.SerializeObject

http://www.newtonsoft.com/json/help/html/Overload_Newtonsoft_Json_JsonConvert_SerializeObject.htm

Name | Description
---- | ----
SerializeObject(Object) | Serializes the specified object to a JSON string.
?SerializeObject(Object, Formatting) | Serializes the specified object to a JSON string using formatting.
~~SerializeObject(Object, JsonConverter[])~~ | ~~Serializes the specified object to a JSON string using a collection of JsonConverter.~~
SerializeObject(Object, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings) | Serializes the specified object to a JSON string using JsonSerializerSettings.
~~SerializeObject(Object, Formatting, JsonConverter[])~~ | ~~Serializes the specified object to a JSON string using formatting and a collection of JsonConverter.~~
?SerializeObject(Object, Formatting, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Serializes the specified object to a JSON string using formatting and JsonSerializerSettings.
?SerializeObject(Object, Type, JsonSerializerSettings) | Serializes the specified object to a JSON string using a type, formatting and JsonSerializerSettings.
?SerializeObject(Object, Type, Formatting, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Serializes the specified object to a JSON string using a type, formatting and JsonSerializerSettings.

#### Example

```csharp
Product product = new Product();
 
product.Name = "Apple";
product.ExpiryDate = new DateTime(2008, 12, 28);
product.Price = 3.99M;
product.Sizes = new string[] { "Small", "Medium", "Large" };
 
string output = JsonConvert.SerializeObject(product);

//{
//  "Name": "Apple",
//  "ExpiryDate": "2008-12-28T00:00:00",
//  "Price": 3.99,
//  "Sizes": [
//    "Small",
//    "Medium",
//    "Large"
//  ]
//}
```

## JsonConvert.DeserializeObject

http://www.newtonsoft.com/json/help/html/Overload_Newtonsoft_Json_JsonConvert_DeserializeObject.htm

Name | Description
---- | ----
DeserializeObject(String) | Deserializes the JSON to a .NET object.
DeserializeObject<T>(String) | Deserializes the JSON to the specified .NET type.
~~DeserializeObject<T>(String, JsonConverter[])~~ | ~~Deserializes the JSON to the specified .NET type using a collection of JsonConverter.~~
DeserializeObject(String, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to a .NET object using JsonSerializerSettings.
DeserializeObject<T>(String, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to the specified .NET type using JsonSerializerSettings.
DeserializeObject(String, Type) | Deserializes the JSON to the specified .NET type.
~~DeserializeObject(String, Type, JsonConverter[])~~ | ~~Deserializes the JSON to the specified .NET type using a collection of JsonConverter.~~
DeserializeObject(String, Type, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to the specified .NET type using JsonSerializerSettings.

#### Example

```csharp
Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
```

## Bridge.Json (Existing)

https://deck.net/3b6d225b2487d12c5587c77e160c971e

```csharp
public class Program
{
    public static void Main()
    {
        Product product = new Product();

        product.Name = "Apple";
        product.ExpiryDate = new DateTime(2008, 12, 28);
        product.Price = 3.99M;
        product.Sizes = new string[] { "Small", "Medium", "Large" };
        
        string output = Bridge.Json.Serialize(product);
        
        Console.WriteLine(output);
        
        Product deserializedProduct = Bridge.Json.Deserialize<Product>(output);
        
        Console.WriteLine(deserializedProduct);
    }
}

[Reflectable]
public class Product
{
    public string Name { get; set; }
    
    public DateTime ExpiryDate { get; set; }
    
    public decimal Price { get; set; }
    
    public string[] Sizes { get; set; }
}
```

## Formatting

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Formatting.htm

Name | Value | Description
---- | ---- | ----
None | 0 | No special formatting is applied. This is the default.
Indented | 1 | Causes child objects to be indented according to the Indentation and IndentChar settings.

## JsonSerializerSettings

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm

### Supported

Name | Description
---- | ----
ContractResolver | IContractResolver | Gets or sets the contract resolver used by the serializer when serializing .NET objects to JSON and vice versa.
NullValueHandling | NullValueHandling | Gets or sets how null values are handled during serialization and deserialization.
TypeNameHandling | TypeNameHandling | Gets or sets how type name writing and reading is handled by the serializer.

### CamelCasePropertyNames > ContractResolver

http://www.newtonsoft.com/json/help/html/ContractResolver.htm#CamelCasePropertyNamesContractResolver

```csharp
new JsonSerializerSettings 
{ 
    ContractResolver = new CamelCasePropertyNamesContractResolver() 
});
```

### TypeNameHandling > TypeNameHandling

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_TypeNameHandling.htm

Name | Value | Description
---- | ---- | ----
None | 0 | Do not include the .NET type name when serializing types.
Objects | 1 | Include the .NET type name when serializing into a JSON object structure.
Arrays | 2 | Include the .NET type name when serializing into a JSON array structure.
All | 3 | Always include the .NET type name when serializing.
Auto | 4 | Include the .NET type name when the type of the object being serialized is not the same as its declared type. Note that this doesn't include the root serialized object by default. To include the root object's type name in JSON you must specify a root type object with SerializeObject(Object, Type, JsonSerializerSettings) or Serialize(JsonWriter, Object, Type).

### IgnoreNullValue > NullValueHandling

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_NullValueHandling.htm

Name | Value | Description
---- | ---- | ----
Include | 0 | Include null values when serializing and deserializing objects.
Ignore | 1 | Ignore null values when serializing and deserializing objects.
