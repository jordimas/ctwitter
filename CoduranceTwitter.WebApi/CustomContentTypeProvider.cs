
using Microsoft.Owin.StaticFiles.ContentTypes;

namespace CoduranceTwitter.WebApi
{
    public class CustomContentTypeProvider : FileExtensionContentTypeProvider
    {
        public CustomContentTypeProvider()
        {
            Mappings.Add(".json", "application/json");
        }
    }
}
