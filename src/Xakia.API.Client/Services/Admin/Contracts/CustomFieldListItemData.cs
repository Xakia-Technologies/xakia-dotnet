using System;
using System.Collections.Generic;
using System.Linq;

namespace Xakia.API.Client.Services.Admin.Contracts
{

    /// <summary>
    /// First Guid Key is a <see cref="CustomFieldListItemId"/>. Second Dictionary is keyed on <see cref="SupportedLanguageCode"/> and as a value has the translated text.
    ///
    /// This can be used to represent both dropdown lists and checkboxes. The main difference is that a dropdown list only has one selected at a time, but a checkbox can have 0 - n.  
    /// 
    /// </summary>
    public class CustomFieldListItemData : Dictionary<Guid, Dictionary<string, string>>
    {
        public CustomFieldListItemData()
        {

        }

        public CustomFieldListItemData(Guid customFieldListId, Dictionary<string, string> languageCodeAndTranslation)
        {
            Add(customFieldListId, languageCodeAndTranslation);
        }


        public CustomFieldListItemData((Guid customFieldListId, Dictionary<string, string> languageCodeAndTranslation)[] source)
        {
            foreach (var item in source)
                Add(item.customFieldListId, item.languageCodeAndTranslation);

        }
    }
}