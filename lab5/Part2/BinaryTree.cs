using System;
using System.Collections.Generic;
namespace Algorithms.lab5;
public class BinaryTree<T, TKey> where TKey : IComparable<TKey> {
    public class Node(T value) {
        public T Value { get; internal set; } = value;
        public Node? Left { get; internal set; }
        public Node? Right { get; internal set; }
        public Node? Parent { get; internal set; }
    }

    private Func<T, TKey> _keySelector;
    public Node? Root { get; private set; }

    public BinaryTree(Func<T, TKey> keySelector) {
        this._keySelector = keySelector;
    }

    // Базова вставка
    private Node Insert(T value) {
        var node = new Node(value);
        if (this.Root is null) {
            this.Root = node;
            return node;
        }

        Node? current = this.Root;
        Node parent = null!;

        while (current is not null) {
            parent = current;
            if (this._keySelector(value).CompareTo(this._keySelector(current.Value)) < 0) {
                current = current.Left;
            } else {
                current = current.Right;
            }
        }
        node.Parent = parent;
        if (this._keySelector(value).CompareTo(this._keySelector(parent.Value)) < 0) {
            parent.Left = node;
        } else {
            parent.Right = node;
        }
        return node;
    }

    // Вставка у корінь дерева за допомогою ротацій
    public void InsertAtRoot(T value) {
        Node node = Insert(value);
        while (node.Parent is not null) {
            Node p = node.Parent;
            if (node == p.Left) RotateRight(p);
            else RotateLeft(p);
        }
    }

    public Node? Search(TKey key) {
        Node? current = this.Root;
        while (current is not null) {
            int comp = key.CompareTo(this._keySelector(current.Value));
            if (comp == 0) return current;
            else if (comp < 0) current = current.Left;
            else current = current.Right;
        }
        return null;
    }

    public void RotateLeft(Node x) {
        Node? y = x.Right;
        if (y is null) return;
        
        x.Right = y.Left;
        if (y.Left is not null) y.Left.Parent = x;

        y.Parent = x.Parent;

        if (x.Parent is null) this.Root = y;
        else if (x == x.Parent.Left) x.Parent.Left = y;
        else x.Parent.Right = y;

        y.Left = x;
        x.Parent = y;
    }

    public void RotateRight(Node x) {
        Node? y = x.Left;
        if (y is null) return;

        x.Left = y.Right;
        if (y.Right is not null) y.Right.Parent = x;

        y.Parent = x.Parent;
        if (x.Parent is null) this.Root = y;
        else if (x == x.Parent.Right) x.Parent.Right = y;
        else x.Parent.Left = y;

        y.Right = x;
        x.Parent = y;
    }

    // Обхід дерева у ширину (виводимо ключі)
    public void PrintBFS() {
        if (this.Root is null) return;
        var queue = new Queue<Node>();
        queue.Enqueue(this.Root);
        
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            Console.Write(_keySelector(curr.Value) + " ");
            if (curr.Left is not null) queue.Enqueue(curr.Left);
            if (curr.Right is not null) queue.Enqueue(curr.Right);
        }
        Console.WriteLine();
    }
}