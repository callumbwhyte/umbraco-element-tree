using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.ElementTree.Startup
{
    public class ElementTreeComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<ElementTreeComponent>();
        }
    }
}