using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Services.Admin;
using Xakia.API.Client.Services.Admin.Contracts;
using Xakia.API.Client.Services.Documents.Contracts;

namespace Xakia.API.Client.Documents
{
    public class DocumentsService : Service
    {
        public override string BasePath { get; } = "/v2/dms/{0}/matter/{1}";
        private LocationSettingsContract _locationSettings;

        public Guid DmsProviderId { get;  }

        public DocumentsService(IXakiaClient xakiaClient, Guid dmsProviderId) : base(xakiaClient) 
        {
            if (dmsProviderId == Guid.Empty) throw new ArgumentException("DmsProviderId must be a valid Guid", nameof(dmsProviderId));

            DmsProviderId = dmsProviderId;
        }


        /// <summary>
        /// Returns a List of <c>Folder</c> and <c>Document</c> objects on a Matter
        /// </summary>
        /// <param name="matterId">The Matter Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MatterDocuments> GetMatterDocumentsAsync( Guid matterId, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));

            return await _xakiaClient.RequestAsync<MatterDocuments>(HttpMethod.Get, 
                GetInstanceUrl(BasePath, "/documents", DmsProviderId, matterId), cancellationToken);
        }


        /// <summary>
        /// Creates a Folder on a Matter
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="folderMetadata"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FolderIdentifiers> CreateMatterFolderAsync(Guid matterId, FolderMetadata folderMetadata, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));
            _ = folderMetadata ?? throw new ArgumentNullException(nameof(folderMetadata));

            return await _xakiaClient.RequestAsync<FolderIdentifiers, FolderMetadata>(HttpMethod.Post, 
                GetInstanceUrl(BasePath, "/documents/folder", DmsProviderId, matterId), folderMetadata, cancellationToken);
        }


        /// <summary>
        /// Renames an existing Folder on a Matter
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="folderId"></param>
        /// <param name="folderNameRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FolderIdentifiers> RenameMatterFolderAsync(Guid matterId, Guid folderId, FolderNameRequest folderNameRequest, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));
            if (folderId == Guid.Empty) throw new ArgumentException("FolderId must be a valid Guid", nameof(folderId));

            return await _xakiaClient.RequestAsync<FolderIdentifiers, FolderNameRequest>(HttpMethod.Put, 
                GetInstanceUrl(BasePath, "/documents/folder/{2}/name", DmsProviderId, matterId, folderId), folderNameRequest, cancellationToken);
        }


        /// <summary>
        /// Renames an existing document on a Matter
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="documentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DocumentIdentifiers> RenameMatterDocumentAsync(Guid matterId, Guid documentId, DocumentNameRequest documentNameRequest, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));
            if (documentId == Guid.Empty) throw new ArgumentException("DocumentId must be a valid Guid", nameof(documentId));
            _ = documentNameRequest ?? throw new ArgumentNullException(nameof(documentNameRequest));

            return await _xakiaClient.RequestAsync<DocumentIdentifiers, DocumentNameRequest>(HttpMethod.Put,
                GetInstanceUrl(BasePath, "/document/{2}/name", DmsProviderId, matterId, documentId), documentNameRequest, cancellationToken);
        }


        /// <summary>
        /// Update the description for a document on a Matter
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="documentId"></param>
        /// <param name="documentDescriptionRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DocumentIdentifiers> UpdateMatterDocumentDescriptionAsync(Guid matterId, Guid documentId, DocumentDescriptionRequest documentDescriptionRequest, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));
            if (documentId == Guid.Empty) throw new ArgumentException("DocumentId must be a valid Guid", nameof(documentId));
            _ = documentDescriptionRequest ?? throw new ArgumentNullException(nameof(documentDescriptionRequest));

            return await _xakiaClient.RequestAsync<DocumentIdentifiers, DocumentDescriptionRequest>(HttpMethod.Put,
                GetInstanceUrl(BasePath, "/document/{2}/description", DmsProviderId, matterId, documentId), documentDescriptionRequest, cancellationToken);
        }


        /// <summary>
        /// Uploads a Document to a Matter specifying document metadata
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="documentMetadata"></param>
        /// <param name="documentContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DocumentIdentifiers> CreateMatterDocumentAsync(Guid matterId, DocumentMetadata documentMetadata, DocumentContent documentContent, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));
            _ = documentMetadata ?? throw new ArgumentNullException(nameof(documentMetadata));
            _ = documentMetadata.Description ?? throw new ArgumentNullException(nameof(documentMetadata.Description));

            if (string.IsNullOrWhiteSpace(documentMetadata.FileName)) documentMetadata.FileName = documentContent.Filename;
            if (documentMetadata.EncryptionKeyId == Guid.Empty) documentMetadata.EncryptionKeyId = (await GetLocationSetting()).CurrentEncryptionKeyId;

            return await _xakiaClient.RequestAsyncWithFile<DocumentIdentifiers>(HttpMethod.Post,
               GetInstanceUrl(BasePath, "/document", DmsProviderId, matterId), documentMetadata, documentContent, cancellationToken);
        }


        /// <summary>
        /// Uploads a Document to a Matter
        /// </summary>
        /// <param name="matterId"></param>
        /// <param name="documentContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DocumentIdentifiers> CreateMatterDocumentAsync(Guid matterId, DocumentContent documentContent, CancellationToken cancellationToken = default)
        {
            if (matterId == Guid.Empty) throw new ArgumentException("MatterId must be a valid Guid", nameof(matterId));

            var documentMetadata = new DocumentMetadata
            {
                FileName = documentContent.Filename,
                EncryptionKeyId = (await GetLocationSetting()).CurrentEncryptionKeyId,
                Description = "Document uploaded via API"
            };

            return await _xakiaClient.RequestAsyncWithFile<DocumentIdentifiers>(HttpMethod.Post,
               GetInstanceUrl(BasePath, "/document", DmsProviderId, matterId), documentMetadata, documentContent, cancellationToken);
        }


        private async Task<LocationSettingsContract> GetLocationSetting()
        {
            if (_locationSettings == null)
            {
                var adminService = new AdminService(_xakiaClient);
                _locationSettings = await adminService.GetLocationSettingsAsync();
            }

            return _locationSettings;
        }
    }
}
