using System;
using System.Text;

namespace Algorithms.lab2;

class SegmentHashTable {
    // Тепер масив зберігає просто відрізки, без обгорток для видалення
    private Segment[] _array;
    private int _size;
    public int Count { get; private set; }

    [cite_start]// Константа A для методу множення  (золотий переріз)
    private const float A = 0.6180339887f;

    public SegmentHashTable(int size = 7) {
        this._size = size;
        this._array = new Segment[this._size];
        this.Count = 0;
    }

    [cite_start]// Метод хешування: Множення 
    private int _hash(float key) {
        float fractionalPart = (key * A) % 1.0f;
        return (int)(this._size * fractionalPart);
    }

    [cite_start]// Вставка з відкритою адресацією (квадратичне зондування) 
    public bool Insert(Segment element) {
        if (this.Count >= this._size) return false;

        float key = element.GetLength();
        int initialIndex = this._hash(key);
        
        for (int i = 0; i < this._size; i++) {
            [cite_start]// Квадратичне зондування 
            int index = (initialIndex + i * i) % this._size;

            if (this._array[index] is null) {
                this._array[index] = element;
                this.Count++;
                return true;
            }
        }
        return false; // Не знайшли вільного місця (хоча при Count < _size це рідкість)
    }

    public Segment? GetSegment(float length) {
        const float MARGIN = 0.001f;
        int initialIndex = this._hash(length);

        for (int i = 0; i < this._size; i++) {
            int index = (initialIndex + i * i) % this._size;
            var currentSegment = this._array[index];

            if (currentSegment is null) return null; 
            
            if (MathF.Abs(currentSegment.GetLength() - length) < MARGIN) {
                return currentSegment;
            }
        }
        return null;
    }

    public void Clear() {
        this._array = new Segment[this._size];
        this.Count = 0;
    }

    public string GetFullContent() {
        var result = new StringBuilder("{\n");
        for (int i = 0; i < this._size; i++) {
            if (this._array[i] is null) {
                result.Append($"\t[{i}] = null\n");
            } else {
                result.Append($"\t[{i}] = {this._array[i]}\n");
            }
        }
        result.Append('}');
        return result.ToString();
    }
}