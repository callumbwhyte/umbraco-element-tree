using System;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.ElementTree.Composing
{
    public static class CompositionExtensions
    {
        public static Composition AddElementTree(this Composition composition, IElementTree elementTree)
        {
            return composition.AddElementTree(elementTree, null, null, 0);
        }

        public static Composition AddElementTree(this Composition composition, IElementTree elementTree, string treeTitle = null, string treeGroup = null, int sortOrder = 0)
        {
            var tree = new ElementTree(elementTree)
            {
                TreeTitle = treeTitle,
                SortOrder = sortOrder
            };

            composition.Trees().AddTree(tree);

            composition.Register((factory) => tree);

            return composition;
        }

        public static Composition AddElementTree(this Composition composition, string sectionAlias, string treeAlias, Type treeControllerType)
        {
            var tree = new ElementTree(sectionAlias, treeAlias, treeControllerType);

            composition.Trees().AddTree(tree);

            composition.Register((factory) => tree);

            return composition;
        }
    }
}