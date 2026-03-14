using System;
using System.Text;

namespace Algorithms.lab1;

class VectorStack<T> {
    private T[] _data;
    
    public int Top { get; private set; }
    public int Capacity => this._data.Length;

    public bool IsFull() => this.Top >= this.Capacity - 1;
    public bool IsEmpty() => this.Top == -1;

    public bool Push(T value) {
        if (this.IsFull()) return false;
        
        this._data[++this.Top] = value;
        return true;
    }

    public T Pop() {
        if (this.IsEmpty()) throw new InvalidOperationException("Stack is empty");
        
        T value = this._data[this.Top];
        this._data[this.Top] = default!; 
        this.Top--;
        return value;
    }

    public override string ToString() {
        var result = new StringBuilder("[ ");
        for (int i = this.Top; i >= 0; i--) {
            result.Append($"{this._data[i]} ");
        }
        result.Append(']');
        return result.ToString();
    }

    public VectorStack(int capacity = 10) {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        this._data = new T[capacity];
        this.Top = -1;
    }
}