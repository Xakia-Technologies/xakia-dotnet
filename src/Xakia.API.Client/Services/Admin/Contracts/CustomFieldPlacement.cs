namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Defines where a custom field has been placed.
    /// </summary>
    public enum CustomFieldPlacement
    {
        /// <summary>
        /// Matter form
        /// </summary>
        MatterForm,
        /// <summary>
        /// Any legal intake request.
        /// </summary>
        LegalIntake,
        /// <summary>
        /// The matter status completion form.
        /// </summary>
        MatterCompletion,
        /// <summary>
        /// The matter dispute log form.
        /// </summary>
        DisputeLog
    };
}
