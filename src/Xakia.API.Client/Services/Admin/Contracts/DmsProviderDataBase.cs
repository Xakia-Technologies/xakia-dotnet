

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Base class for data that is specific to an instance of a DMS provider.
    /// </summary>
    public abstract class DmsProviderDataBase
    {
        /// <summary>
        /// The type of DMS provider.
        /// This field is used as a polymorphism discriminator during deserialization.
        /// </summary>
        public string DmsProviderType { get; set; }
    }
}
