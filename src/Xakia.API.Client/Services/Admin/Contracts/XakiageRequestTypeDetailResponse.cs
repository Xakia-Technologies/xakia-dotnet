using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Represents a complex Xakiage ( Legal Request ) definition
    /// </summary>
    public class XakiageRequestTypeDetailResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public XakiageRequestTypeDetailResponse()
        {
            Divisions = new List<XakiageEntityResponse>();
            Categories = new List<XakiageEntityResponse>();
            TeamMembers = new List<XakiageTeamMemberResponse>();
            CustomFields = new List<CustomFieldResponse>();
            Template = new XakiageTemplateResponse();
            Fields = new List<FieldResponse>();
            DocumentFields = new List<XakiageDocumentResponse>();
        }

        /// <summary>
        /// The unique Id of the Legal Request
        /// </summary>
        public Guid XakiageRequestTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Legal Request
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or set if the Legal Request is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The User who created the Legal Request
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Returns if the Legal Request should display Categories
        /// </summary>
        public bool ShowCategories { get; set; }

        /// <summary>
        /// Returns if the Legal Request should display Divisions
        /// </summary>
        public bool ShowDivisions { get; set; }

        /// <summary>
        /// Returns if the Legal Request should display Team Members
        /// </summary>
        public bool ShowTeamMembers { get; set; }

        /// <summary>
        /// Returns a List of Core fields and their configuration
        /// </summary>
        public List<FieldResponse> Fields { get; set; }

        /// <summary>
        /// Returns a list of Divisions to display if <see cref="ShowDivisions"/> is true
        /// </summary>
        public List<XakiageEntityResponse> Divisions { get; set; }

        /// <summary>
        /// Returns a list of Categories to display if <see cref="ShowCategories"/> is true
        /// </summary>
        public List<XakiageEntityResponse> Categories { get; set; }

        /// <summary>
        /// Returns a list of Team Members to display if <see cref="ShowTeamMembers"/> is true
        /// </summary>
        public List<XakiageTeamMemberResponse> TeamMembers { get; set; }

        /// <summary>
        /// Returns a list of Custom Fields on the Legal Request
        /// </summary>
        public List<CustomFieldResponse> CustomFields { get; set; }

        /// <summary>
        /// Returns the template values for a Legal Request
        /// </summary>
        public XakiageTemplateResponse Template { get; set; }


        /// <summary>
        /// Returns the xakiage uri id for a Legal Request
        /// </summary>
        public Guid XakiageUriId { get; set; }

        /// <summary>
        /// Returns if the Legal Request should include sub-div
        /// </summary>
        public bool IncludeSubDivision { get; set; }

        /// <summary>
        /// Returns if the Legal Request should include sub-cat
        /// </summary>
        public bool IncludeSubCategory { get; set; }

        /// <summary>
        /// Custom field sort option
        /// </summary>
        public int CustomFieldSortOption { get; set; }

        /// <summary>
        /// Returns a list of Xakiage document fields
        /// </summary>
        public List<XakiageDocumentResponse> DocumentFields { get; set; }

       
    }


    /// <summary>
    /// A Legal Request Template values
    /// </summary>
    public class XakiageTemplateResponse
    {
        /// <summary>
        /// Defines the size value on the Legal Requst
        /// </summary>
        public int Size { get; set; } = 0;

        /// <summary>
        /// Defines the risk value on the Legal Request
        /// </summary>
        public int Risk { get; set; } = 0;

        /// <summary>
        /// Defines the complexity value on the Legal Request
        /// </summary>
        public int Complexity { get; set; } = 0;

        /// <summary>
        /// Defines the stragegy value on the Legal Request
        /// </summary>
        public int Strategy { get; set; } = 0;
    }

    /// <summary>
    /// Legal Request Core field
    /// </summary>
    public class FieldResponse
    {
        /// <summary>
        /// The field Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns if the field should be displayed
        /// </summary>
        public bool Display { get; set; }

        /// <summary>
        /// Returns if the field should be renamed to a client specific name
        /// </summary>
        public bool Rename { get; set; }

        /// <summary>
        /// Return a field rename value when <see cref="Rename"/> is true
        /// </summary>
        public string RenameTo { get; set; }

        /// <summary>
        /// Instructions for field
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// Whether the field should be mandatory
        /// </summary>
        public bool Mandatory { get; set; }

    }

    /// <summary>
    /// Represents a Legal Request Custom field
    /// </summary>
    public class CustomFieldResponse
    {
        /// <summary>
        /// The custom field unqiue Id
        /// </summary>
        public Guid CustomFieldId { get; set; }

        /// <summary>
        /// The custom field control type
        /// </summary>
        /// <remarks>
        /// 1 = Checkbox, 2 = Text field, 3 = Date field, 4 = Dropdown list
        /// </remarks>
        public int ControlType { get; set; }

        /// <summary>
        /// Any predefined selections for a ControlType. Only valid when the 
        /// <see cref="ControlType"/> is 1 or 4
        /// </summary>
        public string Selections { get; set; }

        /// <summary>
        /// The Custom Field label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Returns if the custom field is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns any help information to display on the custom field
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Returns if the field is mandatory
        /// </summary>
        public bool Mandatory { get; set; }

        /// <summary>
        /// Sort Order of custom fields
        /// </summary>
        public int SortOrder { get; set; }
    }

    /// <summary>
    /// Represents a Legal Request meta data entity
    /// </summary>
    /// <remarks>
    /// An entity can be a category, sub category, division or sub division
    /// </remarks>
    public class XakiageEntityResponse
    {
        /// <summary>
        /// The entities unique Id
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Returns if the entity is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns if the entity should include its sub entities
        /// </summary>
        public bool IncludeSubEntity { get; set; }

        /// <summary>
        /// Name of entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contains a list of sub entities
        /// </summary>
        public List<XakiageSubEntityResponse> SubEntities { get; set; } = new List<XakiageSubEntityResponse>();
    }

    /// <summary>
    /// Sub-entities (sub-div or sub-cat)
    /// </summary>
    public class XakiageSubEntityResponse
    {
        /// <summary>
        /// The entities unique Id
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Returns if the entity is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Name of entity
        /// </summary>
        public string Name { get; set; }

       
    }

    /// <summary>
    /// Represents a Legal Request team member
    /// </summary>
    public class XakiageTeamMemberResponse
    {
        /// <summary>
        /// The users unique Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Returns if the User is active in the request and displayed in controls
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns if the user is a admin on the define Legal Request
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Returns user firstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Returns user LastName
        /// </summary>
        public string LastName { get; set; }
    }

    /// <summary>
    /// Represents either document instructions,
    /// document attachments
    /// document links
    /// </summary>
    public class XakiageDocumentResponse
    {
        /// <summary>
        /// Document field type
        /// </summary>
        public DocumentFieldType TypeId { get; set; }

        /// <summary>
        /// Whether the field is mandatory
        /// </summary>
        public bool Mandatory { get; set; }

        /// <summary>
        /// Returns if the field is active 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Instructions for fields
        /// </summary>
        public string Instructions { get; set; }

    }

    /// <summary>
    /// Type of document fields
    /// </summary>
    public enum DocumentFieldType
    {
        /// <summary>
        /// Document instructions type
        /// </summary>
        Instructions,

        /// <summary>
        /// Document Attachments type
        /// </summary>
        Attachments,

        /// <summary>
        /// Document links Type
        /// </summary>
        Links
    }
}
