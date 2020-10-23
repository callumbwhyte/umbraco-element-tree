using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.ElementTree.Controllers;
using Umbraco.Core.Composing;
using Umbraco.Web.Trees;

namespace Our.Umbraco.ElementTree.Startup
{
    public class ElementTreeComponent : IComponent
    {
        public void Initialize()
        {
            TreeControllerBase.TreeNodesRendering += TreeController_TreeNodesRendering;
        }

        public void Terminate()
        {
            TreeControllerBase.TreeNodesRendering -= TreeController_TreeNodesRendering;
        }

        private void TreeController_TreeNodesRendering(TreeControllerBase sender, TreeNodesRenderingEventArgs e)
        {
            var elementTrees = GetTrees();

            var rootIds = elementTrees.Select(x => x.StartNodeId);

            e.Nodes.RemoveAll(x => rootIds.Contains(x.Id) || rootIds.Contains(x.ParentId));
        }

        private IEnumerable<IElementTree> GetTrees()
        {
            return Current.Factory.GetAllInstances<ElementTreeController>();
        }
    }
}