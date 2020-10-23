using System;
using Umbraco.Web.Trees;

namespace Our.Umbraco.ElementTree
{
    public class ElementTree : Tree, IElementTree
    {
        public ElementTree(string sectionAlias, string treeAlias, Type treeControllerType)
            : this(sectionAlias, treeAlias, treeControllerType, null, null, 0)
        {

        }

        public ElementTree(IElementTree elementTree)
            : this(elementTree.SectionAlias, elementTree.TreeAlias, elementTree.TreeControllerType)
        {
            StartNodeId = elementTree.StartNodeId;
        }

        public ElementTree(string sectionAlias, string treeAlias, Type treeControllerType, string treeTitle = null, string treeGroup = null, int sortOrder = 0)
            : base(sortOrder, sectionAlias, treeGroup, treeAlias, treeTitle, TreeUse.Main | TreeUse.Dialog, treeControllerType, false)
        {
            TreeTitle = treeTitle;
            TreeGroup = treeGroup;
            SortOrder = sortOrder;
        }

        public string StartNodeId { get; }

        public new string TreeGroup { get; }
    }
}