using System.Text.Encodings.Web;
using OrchardCore.ContentManagement;
using OrchardCore.XmlRpc;
using OrchardCore.XmlRpc.Models;
using OrchardCore.MetaWeblog;
using OrchardCore.RAQModule.Models;

namespace OrchardCore.RAQModule.RemotePublishing
{
    public class RAQModuleMetaWeblogDriver : MetaWeblogDriver
    {
        private readonly HtmlEncoder _encoder;

        public RAQModuleMetaWeblogDriver(HtmlEncoder encoder)
        {
            _encoder = encoder;
        }

        public override void BuildPost(XRpcStruct rpcStruct, XmlRpcContext context, ContentItem contentItem)
        {
            var raqPart = contentItem.As<RAQModulePart>();
            if (raqPart == null)
            {
                return;
            }

            rpcStruct.Set("title", _encoder.Encode(raqPart.ButtonTitle));
            rpcStruct.Set("email", _encoder.Encode(raqPart.EmailAddress));
        }

        public override void EditPost(XRpcStruct rpcStruct, ContentItem contentItem)
        {
            contentItem.DisplayText = rpcStruct.Optional<string>("title");
            //contentItem.DisplayText = rpcStruct.Optional<string>("email");
        }
    }
}
