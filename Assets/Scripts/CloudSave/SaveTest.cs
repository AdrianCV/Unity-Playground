using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.CloudSave;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    ICloudSaveDataClient _client = CloudSaveService.Instance.Data;

    CloudSaveClient Client;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    async void Save()
    {
        var data = new Dictionary<string, object> { { "my_key", "Some data goes here" } };
        await _client.ForceSaveAsync(data);
    }

    async void Load()
    {
        var query = await _client.LoadAsync(new HashSet<string> { "my_key" });
        var myData = query["my_key"];
    }

    async void ComplexSave()
    {
        var complexData = new ExampleObject { Some = "Example", Stuff = 420 };

        var data = new Dictionary<string, object> { { "complex_key", complexData } };
        await _client.ForceSaveAsync(data);
    }

    async void ComplexLoad()
    {
        var query = await _client.LoadAsync(new HashSet<string> { "complex_key" });
        var stringData = query["complex_key"];
        var deserialized = JsonConvert.DeserializeObject<ExampleObject>(stringData);
    }

    async void SaveWrapperUsage()
    {
        // Save primitive
        await Client.Save("one", "just a string");

        // Load
        var stringData = await Client.Load<string>("one");

        // Save complex
        await Client.Save("one", new ExampleObject { Some = "Example", Stuff = 420 });

        // Load Complex
        var objectData = await Client.Load<ExampleObject>("one");

        // Delete
        await Client.Delete("one");

        // Save multiple
        await Client.Save(("one", new ExampleObject { Some = "More", Stuff = 69 }),
            ("two", "string data"),
            ("three", "Another set"));

        // Load multiple. Restricted to same type
        var multipleData = await Client.Load<string>("two", "three");

        // Delete all
        await Client.DeleteAll();
    }
}
