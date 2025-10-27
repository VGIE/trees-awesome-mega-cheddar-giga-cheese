namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.

using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Previous = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        return m_numItems;
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        
        ListNode<T> node = First;
            int length = Count();
            if (index >= length)
                return default;
            for (int i = 0; i < length; i++)
            {

                if (i == index)
                    return node.Value;
                node = node.Next;
            }
            return default;
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        if (Last == null)
        {
            First = new ListNode<T>(value);
            Last = First;
            m_numItems++;
        }
        else
        {
            Last.Next = new ListNode<T>(value);
            Last.Next.Previous = Last;
            Last = Last.Next;
            m_numItems++;
        }
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First; 
         if (index >= Count() || index < 0)
            return default;
            if (index == 0)
            {
                if(First.Next != null)
                    First.Next.Previous = null;
                node = First;
                First = First.Next;
                m_numItems--;
                return node.Value;
                
            }
            if (index == Count() - 1)
            {
                node = Last;
                Last.Previous = Last;
                m_numItems--;
                return node.Value;
            }
            int i = 0;
            while (i < index - 1)
            {
                node = node.Next;
                i++;
            }
        if (First != Last || index == m_numItems - 1)
        {
            Last = node;
        }
        T value = node.Next.Value;
        node.Next.Next.Previous = node;
        node.Next = node.Next.Next;
        m_numItems--;
        return value;
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        Last = null;
        m_numItems = 0;

    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        for (int i = 0; i < Count(); i++)
            {
                yield return Get(i);
            }
    }
}