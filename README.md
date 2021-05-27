# xakia-dotnet
The official .net library for Xakia

## Getting Started

### Retrieve your API details
- Navigate to Xakia Admin -> Developers Section
- Select the 'Create Key' button
- Note your Client Id, Secret and header values


### Create a XakiaClient

var xakiaClient = new XakiaClient(new XakiaClientOptions("clientId",
A `XakiaClient` is the foundation for API calls. Create a client using a new `XakiaClientOptions` with your API details:

```csharp
var xakiaClient = new XakiaClient(new XakiaClientOptions("clientId",
                "clientSecret",
                XakiaRegion.Australia,
                 Guid.Parse("tenantId"),
                 Guid.Parse("locationId")
            ));

```
Instantiate a service with the `XakiaClient` instance.

```csharp
var matterService = new MattersService(xakiaClient);
```

### Matter Examples

#### Get a list of open matters
```csharp
var matterService = new MattersService(xakiaClient);
var @params = new MattersQueryParams { Cancelled = false, Completed = false };
var matters = await matterService.GetMattersListAsync(@params);
```

### Document Examples
#### Get folders and documents on a Matter
```csharp
var matterId = Guid.Parse("matterId");
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();
var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);
var matterDocuments = await documentsService.GetMatterDocumentsAsync(matterId);
```

#### Create a folder on a Matter
```csharp
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();
var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);

var folder = new FolderMetadata { Name = "FolderName" };
var folderResponse = await documentsService.CreateMatterFolderAsync(matterId, folder);
```

#### Upload a document to a Matter
```csharp
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();
var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);

var file = new FileInfo("pathOfDocument");
using (var streamReader = new StreamReader(file.FullName))
{
     var documentContent = new DocumentContent
     {
          Filename = file.Name,
          Stream = streamReader.BaseStream
     };

     var folderResponse = await documentsService.CreateMatterDocumentAsync(matterId, documentContent);
}
```