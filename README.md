# xakia-dotnet
The official .net library for Xakia

## Getting Started

### Retrieve your API details
- Navigate to Xakia Admin -> Developers Section
- Select the 'Create Key' button
- Note your Client Id, Secret and header values


### Create a XakiaClient

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

### Matter API Examples

#### Get a list of open matters
```csharp
var matterService = new MattersService(xakiaClient);
var @params = new MattersQueryParams { Cancelled = false, Completed = false };
var matters = await matterService.GetMattersListAsync(@params);
```

#### Get a matter by Id
```csharp
var matterId = Guid.Parse("matterId");
var matterService = new MattersService(xakiaClient);
var matter = await matterService.GetMatterAsync(matterId);
```

### Document API Examples

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

#### Create a sub-folder on a Matter

```csharp
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();
var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);
var matterDocuments = await documentsService.GetMatterDocumentsAsync(matterId);

var folder = new FolderMetadata { Name = "SubFolderName", ParentId = matterDocuments.Folders.First().FolderId };
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

     var documentResponse = await documentsService.CreateMatterDocumentAsync(matterId, documentContent);
}
```

#### Upload a document to a sub-folder on a Matter

```csharp
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();
var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);
 var matterDocuments = await documentsService.GetMatterDocumentsAsync(matterId);

var file = new FileInfo("pathOfDocument");
using (var streamReader = new StreamReader(file.FullName))
{
     var documentContent = new DocumentContent
     {
          Filename = file.Name,
          Stream = streamReader.BaseStream
     };
      var documentMetaData = new DocumentMetadata
     {
         Description = "Document uploaded via API",
         FolderId = matterDocuments.Folders.First().FolderId.ToString()
     };

     var documentResponse = await documentsService.CreateMatterDocumentAsync(matterId, documentMetaData, documentContent);
}
```


#### Rename a document on a Matter

```csharp
var adminService = new AdminService(xakiaClient);
var dmsProviders = await adminService.GetDmsProvidersAsync();

var documentsService = new DocumentsService(xakiaClient, dmsProviders.First().DmsProviderId);
var matterDocuments = await documentsService.GetMatterDocumentsAsync(MatterId);
var document = matterDocuments.Documents.First();
var documentRequest = new DocumentNameRequest
{
     Name = $"Updated_{document.Filename}"
};

var documentResponse = await documentsService.RenameMatterDocumentAsync(MatterId, document.DocumentId, documentRequest);
```