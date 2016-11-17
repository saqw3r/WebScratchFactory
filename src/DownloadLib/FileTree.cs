using System.Collections.Generic;

namespace DownloadLib
{
    public class FileTree
    {
        public FileTreeNode RootNode = null;

        public FileTree(string rootPath)
        {
            int startRootNameIndex = rootPath.IndexOf('/') + 1;
            RootNode = new FileTreeNode()
            {
                FullPath = rootPath,
                ParentNode = null,
                NodeName = rootPath.Substring(startRootNameIndex, rootPath.Length - startRootNameIndex),
                ChildNodes = new List<FileTreeNode>()
            };
        }

        public void AddNode(FileTreeNode nodeToAdd, FileTreeNode childNode)
        {
            nodeToAdd.ChildNodes.Add(childNode);
        }

        public FileTreeNode CreateNewNode(FileTreeNode nodeToAdd, string newNodeName)
        {
            FileTreeNode node = new FileTreeNode(newNodeName);
            this.AddNode(nodeToAdd, node);
            return nodeToAdd;
        }
    }
}
