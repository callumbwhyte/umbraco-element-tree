using Umbraco.Web.Trees;

namespace Our.Umbraco.ElementTree.Controllers
{
    public abstract class ElementTreeController<T> : ElementTreeController
        where T : TreeControllerBase
    {
        public ElementTreeController(T treeController)
            : base(treeController)
        {

        }
    }
}