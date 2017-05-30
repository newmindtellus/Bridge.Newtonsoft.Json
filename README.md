Provides [Bridge.NET](http://bridge.net/) support for a limited subset of the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) API.

**NOTE:** Only the features listed below are supported.

## Installation

Install using [NuGet](https://www.nuget.org/):

```
Install-Package Bridge.Newtonsoft.Json
```

## JsonConvert.SerializeObject

http://www.newtonsoft.com/json/help/html/Overload_Newtonsoft_Json_JsonConvert_SerializeObject.htm

Supported | Name | Description
---- | ---- | ----
:white_check_mark: | SerializeObject(Object) | Serializes the specified object to a JSON string.
:white_check_mark: | SerializeObject(Object, [Formatting](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#formatting)) | Serializes the specified object to a JSON string using formatting.
:white_check_mark: | SerializeObject(Object, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings) | Serializes the specified object to a JSON string using JsonSerializerSettings.
:white_check_mark: | SerializeObject(Object, [Formatting](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#formatting), [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Serializes the specified object to a JSON string using formatting and JsonSerializerSettings.
:negative_squared_cross_mark: | SerializeObject(Object, JsonConverter[]) | Serializes the specified object to a JSON string using a collection of JsonConverter.
:negative_squared_cross_mark: | SerializeObject(Object, [Formatting](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#formatting), JsonConverter[]) | Serializes the specified object to a JSON string using formatting and a collection of JsonConverter.
:negative_squared_cross_mark: | SerializeObject(Object, Type, JsonSerializerSettings) | Serializes the specified object to a JSON string using a type, formatting and JsonSerializerSettings.
:negative_squared_cross_mark: | SerializeObject(Object, Type, [Formatting](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#formatting), [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Serializes the specified object to a JSON string using a type, formatting and JsonSerializerSettings.

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

Supported | Name | Description
---- | ---- | ----
:white_check_mark: | DeserializeObject(String) | Deserializes the JSON to a .NET object.
:white_check_mark: | DeserializeObject<T>(String) | Deserializes the JSON to the specified .NET type.
:white_check_mark: | DeserializeObject(String, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to a .NET object using JsonSerializerSettings.
:white_check_mark: | DeserializeObject<T>(String, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to the specified .NET type using JsonSerializerSettings.
:white_check_mark: | DeserializeObject(String, Type) | Deserializes the JSON to the specified .NET type.
:white_check_mark: | DeserializeObject(String, Type, [JsonSerializerSettings](https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/blob/master/README.md#jsonserializersettings)) | Deserializes the JSON to the specified .NET type using JsonSerializerSettings.
:negative_squared_cross_mark: | DeserializeObject<T>(String, JsonConverter[]) | Deserializes the JSON to the specified .NET type using a collection of JsonConverter.
:negative_squared_cross_mark: | DeserializeObject(String, Type, JsonConverter[]) | Deserializes the JSON to the specified .NET type using a collection of JsonConverter.

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

Supported | Name | Value | Description
---- | ---- | ---- | ----
:white_check_mark: | None | 0 | No special formatting is applied. This is the default.
:white_check_mark: | Indented | 1 | Causes child objects to be indented according to the Indentation and IndentChar settings.

## JsonSerializerSettings

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm

### ContractResolver

http://www.newtonsoft.com/json/help/html/ContractResolver.htm#CamelCasePropertyNamesContractResolver

```csharp
new JsonSerializerSettings 
{ 
    ContractResolver = new CamelCasePropertyNamesContractResolver() 
});
```

### TypeNameHandling

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_TypeNameHandling.htm

Supported | Name | Value | Description
---- | ---- | ---- | ----
:white_check_mark: | None | 0 | Do not include the .NET type name when serializing types.
:white_check_mark: | Objects | 1 | Include the .NET type name when serializing into a JSON object structure.
:negative_squared_cross_mark: | Arrays | 2 | Include the .NET type name when serializing into a JSON array structure.
:negative_squared_cross_mark: | All | 3 | Always include the .NET type name when serializing.
:negative_squared_cross_mark: | Auto | 4 | Include the .NET type name when the type of the object being serialized is not the same as its declared type. Note that this doesn't include the root serialized object by default. To include the root object's type name in JSON you must specify a root type object with SerializeObject(Object, Type, JsonSerializerSettings) or Serialize(JsonWriter, Object, Type).

### NullValueHandling

http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_NullValueHandling.htm

Supported | Name | Value | Description
---- | ---- | ---- | ----
:white_check_mark: | Include | 0 | Include null values when serializing and deserializing objects.
:white_check_mark: | Ignore | 1 | Ignore null values when serializing and deserializing objects.
