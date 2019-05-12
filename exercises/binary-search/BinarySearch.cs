public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int left = 0;
        int right = input.Length - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (input[middle] < value)
            {
                left = middle + 1;
            }
            else if (input[middle] > value)
            {
                right = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }
}