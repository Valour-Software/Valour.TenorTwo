// This program file is for testing the client

using System.Text.Json;
using Valour.TenorTwo;
using Valour.TenorTwo.Models;

var apiKey = "";

var formats = new List<MediaFormatType>() { MediaFormatType.gif, MediaFormatType.tinygif };

TenorClient client = new TenorClient(apiKey);
var test = client.Search( "egg", 1, formatFilter: formats);

Console.WriteLine(JsonSerializer.Serialize(test));