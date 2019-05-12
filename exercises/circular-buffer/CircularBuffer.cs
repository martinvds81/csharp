using System;

public class CircularBuffer<T>
{
    private T[] _buffer;

    protected int count = 0;
    protected int start = 0;
    protected int end = 0;
    protected int capacity = 0;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        _buffer = new T[capacity];
    }

    public T Read()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("No items in buffer");
        }

        var item = _buffer[start];
        start = (start + 1) % capacity;
        count--;
        return item;
    }

    public void Write(T value)
    {
        if (count >= capacity)
        {
            throw new InvalidOperationException("Buffer is full");
        }

        AddToBuffer(value, false);
    }

    public void Overwrite(T value)
    {
        AddToBuffer(value, count >= capacity);
    }

    protected void AddToBuffer(T value, bool overwrite)
    {
        if (overwrite)
        {
            start = (start + 1) % capacity;
        }
        else
        {
            count++;
        }
        _buffer[end] = value;
        end = (end + 1) % capacity;
    }

    public void Clear()
    {
        start = 0;
        end = 0;
        count = 0;

        _buffer = new T[capacity];
    }
}