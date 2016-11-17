using System.Collections.Generic;

namespace DownloadLib
{
    public class FileTreeNode
    {
        public string NodeName;
        public string FullPath;
        public FileTreeNode ParentNode;
        public List<FileTreeNode> ChildNodes;

        public FileTreeNode()
        {
        }

        public FileTreeNode(string nodeName)
        {
            NodeName = nodeName;
        }
    }
}
