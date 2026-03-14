using System;
using System.Text;

namespace Algorithms.lab1;

class LinkedQueue<T> {
    public class Node {
        public T Data { get; set; }
        public Node? Next { get; internal set; }
        
        public Node(T value) {
            this.Data = value;
        }
    }

    private Node? _head;
    private Node? _tail;

    public bool IsEmpty() => this._head == null;

    public bool Enqueue(T value) {
        var newNode = new Node(value);
        if (this.IsEmpty()) {
            this._head = newNode;
            this._tail = newNode;
        } else {
            this._tail!.Next = newNode;
            this._tail = newNode;
        }
        return true;
    }

    public T Dequeue() {
        if (this.IsEmpty()) throw new InvalidOperationException("Queue is empty");
        
        T value = this._head!.Data;
        this._head = this._head.Next;
        
        if (this._head == null) {
            this._tail = null;
        }
        return value;
    }

    public override string ToString() {
        var result = new StringBuilder("[ ");
        var current = this._head;
        while (current != null) {
            result.Append($"{current.Data} ");
            current = current.Next;
        }
        result.Append(']');
        return result.ToString();
    }
}