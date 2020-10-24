using Our.Umbraco.ElementTree.Controllers;
using Umbraco.Web.Trees;

namespace Our.Umbraco.ElementTree
{
    public class ElementTree<T> : ElementTree
        where T : TreeControllerBase
    {
        public ElementTree(string sectionAlias, string treeAlias, string startNodeId, string treeTitle = null, string treeGroup = null, int sortOrder = 0)
            : base(sectionAlias, treeAlias, typeof(ElementTreeController<T>), treeTitle, treeGroup, sortOrder)
        {
            StartNodeId = startNodeId;
        }
    }
}