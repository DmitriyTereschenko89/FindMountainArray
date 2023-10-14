MountainArray mountainArray1 = new(new int[] { 1, 2, 3, 4, 5, 3, 1 });
MountainArray mountainArray2 = new(new int[] { 0, 1, 2, 4, 2, 1 });
MountainArray mountainArray3 = new(new int[] { 1, 5, 2 });
Solution solution = new();
Console.WriteLine(solution.FindInMountainArray(3, mountainArray1));
Console.WriteLine(solution.FindInMountainArray(3, mountainArray2));
Console.WriteLine(solution.FindInMountainArray(0, mountainArray3));

class MountainArray
{
	private readonly int[] array;
	public MountainArray(int[] array)
	{
		this.array = array;
	}

	public int Get(int index) => array[index];

	public int Length() => array.Length;
}


class Solution
{
	public int FindInMountainArray(int target, MountainArray mountainArr)
	{
		int left = 0;
		int right = mountainArr.Length() - 2;
		// Find Peak Index
		while (left < right)
		{
			int middle = (left + right) / 2;
			if (mountainArr.Get(middle) < mountainArr.Get(middle + 1))
			{
				left = middle + 1;
			}
			else
			{
				right = middle;
			}
		}
		// Find index in increasing part
		int low = 0;
		int high = left;
		while (low < high)
		{
			int middle = (low + high) / 2;
			if (mountainArr.Get(middle) < target)
			{
				low = middle + 1;
			}
			else
			{
				high = middle;
			}
		}
		if (mountainArr.Get(low) == target)
		{
			return low;
		}
		// Find index in decreasing part
		low = left;
		high = mountainArr.Length() - 1;
		while (low < high)
		{
			int middle = (low + high) / 2;
			if (mountainArr.Get(middle) > target)
			{
				low = middle + 1;
			}
			else
			{
				high = middle;
			}
		}
		if (mountainArr.Get(low) == target)
		{
			return low;
		}
		return -1;
	}
}