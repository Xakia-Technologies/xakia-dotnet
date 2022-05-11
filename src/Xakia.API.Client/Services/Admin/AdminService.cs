using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Helpers;
using Xakia.API.Client.Services.Admin.Contracts;

namespace Xakia.API.Client.Services.Admin
{
    /// <summary>
    /// Client service for interating with Xakia Admin service
    /// </summary>
    public class AdminService : Service
    {
        public override string BasePath { get; } = "/v2/location";

        public AdminService(IXakiaClient xakiaClient) : base(xakiaClient) { }


        /// <summary>
        /// Returns the DmsProvider
        /// </summary>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A List of <c>DmsProviderResponse</c> objects</returns>
        public async Task<List<DmsProviderResponse>> GetDmsProvidersAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<List<DmsProviderResponse>>(HttpMethod.Get, GetUrl(BasePath, "/dmsproviders"), cancellationToken);
        }

        /// <summary>
        /// Returns a <c>LocationSettingsContract</c> with meta data for a Location.
        /// </summary>
        /// <remarks>
        /// Meta data includes: Categories, Divsions, Groups, Features, External Firms and Custom fields
        /// </remarks>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>LocationSettingsContract</c> object of location settings</returns>
        public async Task<LocationSettingsContract> GetLocationSettingsAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<LocationSettingsContract>(HttpMethod.Get, GetUrl("/v2/locationsettings"), cancellationToken);
        }

        /// <summary>
        /// Returns a list of all Legal Request types 
        /// </summary>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>XakiageResponse</c> object</returns>
        public async Task<XakiageResponse> GetLegalRequestTypeListAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<XakiageResponse>(HttpMethod.Get, GetUrl("/v2/xakiage"), cancellationToken);
        }

        /// <summary>
        /// Gets the details for a Legal Request from the Legal Request TypeId
        /// </summary>
        /// <param name="legalRequestTypeId">The Legal Request TypeId</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>XakiageRequestTypeDetailResponse</c> with the legal request type definition</returns>
        /// <exception cref="ArgumentException">Thrown if the legalRequestTypeId is not a valid Guid</exception>
        public async Task<XakiageRequestTypeDetailResponse> GetLegalRequestTypeAsync(Guid legalRequestTypeId, CancellationToken cancellationToken = default)
        {
            if (legalRequestTypeId == Guid.Empty) throw new ArgumentException("Legal Request Id must be a valid Guid", nameof(legalRequestTypeId));

            var requestType = await _xakiaClient.RequestAsync<XakiageRequestTypeDetailResponse>(HttpMethod.Get, GetInstanceUrl("/v2/xakiage/{0}", legalRequestTypeId), cancellationToken);
            requestType.LegalRequestCustomFields = await _xakiaClient.RequestAsync<XakiageCustomFieldsContract>(HttpMethod.Get, GetInstanceUrl("/v2/xakiage/{0}/customfields", legalRequestTypeId), cancellationToken);
            return requestType;
        }


        /// <summary>
        /// Create or update a Custom Field and associated items
        /// </summary>
        /// <param name="customFieldCommand">The custom field content </param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>CreateOrUpdateCustomFieldDefinition_i18nCommand</c> command is null</exception>
        /// <exception cref="RequestValidationEvent">Thrown if the >CreateOrUpdateCustomFieldDefinition_i18nCommand</c> command  fails validation</exception>
        public async Task<CommandResult> CreateCustomFieldsAsync(CreateOrUpdateCustomFieldDefinition_i18nCommand customFieldCommand, CancellationToken cancellationToken = default)
        {
            _ = customFieldCommand ?? throw new ArgumentNullException(nameof(customFieldCommand));
            
            var validationEvents = customFieldCommand.Validate();
            if (validationEvents.Any()) throw new RequestValidationException("Custom field request failed validation.", validationEvents);

            return await _xakiaClient.RequestAsync<CommandResult, CreateOrUpdateCustomFieldDefinition_i18nCommand>(HttpMethod.Post, GetUrl("/v2/customfield_i18n"), customFieldCommand, cancellationToken);
        }
    }

}
