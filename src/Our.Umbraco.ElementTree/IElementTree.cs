using System;

namespace Our.Umbraco.ElementTree
{
    public interface IElementTree
    {
        string SectionAlias { get; }

        string TreeAlias { get; }

        Type TreeControllerType { get; }

        string StartNodeId { get; }
    }
}