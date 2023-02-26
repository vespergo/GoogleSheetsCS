using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

string[] Scopes = { SheetsService.Scope.Spreadsheets };
string spreadSheetId = "1eKZXETNwRb9L41fgbD8e4JZJVGwumW6YzaNioQlss-I";
string ApplicationName = "Test";
string sheet = "Sheet1";
SheetsService service;


// goto google sheet and share with the email in client_secret.json file, csharp@vercelstorage.iam.gserviceaccount.com
GoogleCredential credential;
using(var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
{
    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
}

service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = ApplicationName
});

void ReadEntries()
{
    var range = $"{sheet}!A:F";
    SpreadsheetsResource.ValuesResource.GetRequest request =
            service.Spreadsheets.Values.Get(spreadSheetId, range);

    var response = request.Execute();
    IList<IList<object>> values = response.Values;
    if (values != null && values.Count > 0)
    {
        foreach (var row in values)
        {
            if(row.Count > 0)
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
        }
    }
    else
    {
        Console.WriteLine("No data found.");
    }

}

void CreateEntry() {
    var range = $"{sheet}!A:F";
    var valueRange = new ValueRange();

    var oblist = new List<object>() { "Hello!", "This", "was", "insertd", "via", "C#" };
    valueRange.Values = new List<IList<object>> { oblist };

    var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadSheetId, range);
    appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
    var appendReponse = appendRequest.Execute();
}

void UpdateEntry()
{
    var range = $"{sheet}!D1";
    var valueRange = new ValueRange();

    var oblist = new List<object>() { "updated" };
    valueRange.Values = new List<IList<object>> { oblist };

    var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadSheetId, range);
    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
    var appendReponse = updateRequest.Execute();
}

void DeleteEntry()
{
    var range = $"{sheet}!A1:F1";
    var requestBody = new ClearValuesRequest();

    var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, spreadSheetId, range);
    var deleteReponse = deleteRequest.Execute();
}
for (int i = 0; i < 2; i++)
{
    CreateEntry();
}
ReadEntries();
UpdateEntry();
DeleteEntry();