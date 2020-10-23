using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http.ModelBinding;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi.Filters;

namespace Our.Umbraco.ElementTree.Controllers
{
    public abstract class ElementTreeController : TreeController, IElementTree
    {
        private readonly TreeControllerBase _treeController;

        public ElementTreeController(TreeControllerBase treeController)
        {
            _treeController = treeController;
        }

        public virtual Type TreeControllerType => _treeController.GetType();

        public virtual string StartNodeId => "-1";

        public virtual bool HideRoot => false;

        public virtual bool HideOriginal => false;

        #region Base overrides

        protected override MenuItemCollection GetMenuForNode(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            PrepareRequest(ref queryStrings);

            return _treeController.GetMenu(id, queryStrings);
        }

        protected override TreeNodeCollection GetTreeNodes(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            PrepareRequest(ref queryStrings);

            return _treeController.GetNodes(id, queryStrings);
        }

        private void PrepareRequest(ref FormDataCollection queryStrings)
        {
            _treeController.Url = this.Url;

            var query = queryStrings.ToDictionary(x => x.Key, x => x.Value);

            if (query.TryGetValue("id", out string id) == true)
            {
                if (id == "-1")
                {
                    query["id"] = StartNodeId;
                }
            }

            query["startNodeId"] = StartNodeId;

            queryStrings = new FormDataCollection(query);
        }

        #endregion
    }
}