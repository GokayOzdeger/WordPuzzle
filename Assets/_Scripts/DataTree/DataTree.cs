using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LinkedTree<TData> 
{
    public TreeNode<TData> Root => _root;
    private TreeNode<TData> _root;

    public LinkedTree()
    {
        _root = new TreeNode<TData>(default(TData));
    }
}


public class TreeNode<TData>
{
    public int Id { get; set; }
    public HashSet<TreeNode<TData>> ChildNodes { get; private set; } = new HashSet<TreeNode<TData>>();
    public TreeNode<TData> ParentNode { get; set; }

    public TData Data
    {
        get => _data;
        set => _data = value;
    }

    private TData _data;

    public TreeNode(TData data)
    {
        _data = data;
    }

    public bool HasChild(TData data)
    {
        foreach (TreeNode<TData> node in ChildNodes) if (node.Data.Equals(data)) return true;
        return false;
    }

    public void RemoveChild(TreeNode<TData> node)
    {
        ChildNodes.Remove(node);
    }

    public void RemoveChild(TData data)
    {
        ChildNodes.RemoveWhere((node)=> node.Data.Equals(data));
    }

    public TreeNode<TData> AddChild(TreeNode<TData> node)
    {
        node.ParentNode = this;
        ChildNodes.Add(node);
        return node;
    }

    public TreeNode<TData> AddChild(TData data)
    {
        TreeNode<TData> node = new TreeNode<TData>(data);
        node.ParentNode = this;
        ChildNodes.Add(node);
        return node;
    }
}
