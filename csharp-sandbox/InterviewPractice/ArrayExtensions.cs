using InterviewPractice;

public static class ArrayExtensions
{
    public static void Swap<T>(this T[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    public static string AsString<T>(this IEnumerable<T> arr)
    {
        return "[" + string.Join(", ", arr.Select(s => s.ToString())) + "]";
    }

    public static void LogEnumerable<T>(this IEnumerable<T> arr)
    {
        Console.WriteLine(arr.AsString());
    }

    public static void LogListNode(this ListNode node)
    {
        var cur = node;
        var res = new List<int>();
        while (cur != null)
        {
            res.Add(cur.val);
            cur = cur.next;
        }

        res.LogEnumerable();
    }
}