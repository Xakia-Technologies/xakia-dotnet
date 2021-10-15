﻿using System;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Identifies the type of control used for a custom field.
    /// </summary>

    public enum CustomFieldType_i18n
    {
        /// <summary>
        /// A dropdown list, also known as a combo box.
        /// </summary>
        Dropdown,
        /// <summary>
        /// A checkbox with a boolean value, on or off.
        /// </summary>
        Checkbox,
        /// <summary>
        /// Date.
        /// </summary>
        Date,
        /// <summary>
        /// Free text.
        /// </summary>
        FreeText,
        /// <summary>
        /// Custom text.
        /// This is a static label on the form.
        /// </summary>
        CustomText,
        /// <summary>
        /// Number only. I asked if she wanted both  integers and decimal and she said "one field that allows for numbers up to 2 decimal places". 
        /// </summary>
        Numeric,

        HtmlLink
    }
}
