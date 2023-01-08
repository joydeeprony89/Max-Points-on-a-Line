// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Solution s = new Solution();
var points = new int[7][] { new int[] { 2, 1 }, new int[] { 3, 2 }, new int[] { 2, 1 },
  new int[] { 4, 1 }, new int[] { 5, 4 }, new int[] { 2, 1 }, new int[] { 2, 1 } };

var answer = s.MaxPoints(points);
Console.WriteLine(answer);

public class Solution
{
  public int MaxPoints(int[][] points)
  {
    int n = points.Length;
    if (n <= 2) return n;
    int result = 0;
    for (int i = 0; i < n; i++)
    {
      var cache = new Dictionary<double, int>();
      int samePoint = 0;
      int sameXPoint = 1; // Why initialize with 1 ? coz if we find another point which has same x axis value our count should be 2,
                          // coz two points are on same vertical line, instead of incrementing +2 , we have initialized with 1 and if a point is found in the same x asix 
                          // vertical will increment +1 , so at the end will have count as 2.
      for (int j = 0; j < n; j++)
      {
        if (i != j)
        {
          var currentPoint = points[j];
          var prevPoint = points[i];
          // if prev and current points are same
          if (currentPoint[0] == prevPoint[0] && currentPoint[1] == prevPoint[1])
          {
            samePoint++;
          }

          // if prev and current point are on same vertical line, when x values of multiple points are same 
          // we say they are on same vertical line
          if (currentPoint[0] == prevPoint[0])
          {
            sameXPoint++;
            continue; // we dont do anything further coz, if in same vertical line, the difference bw x axis values would be 0
            // during calculating slope (y2 - y1) / (x2 - x1), its not possible to divide by 0 as the x2 and x1 are same.
          }

          // we can calculate the slope
          var slope = (double)(currentPoint[1] - prevPoint[1]) / (double)(currentPoint[0] - prevPoint[0]);
          if (!cache.ContainsKey(slope)) cache.Add(slope, 2);
          else cache[slope]++;
          result = Math.Max(result, cache[slope] + samePoint); 
        }
      }
      result= Math.Max(result, sameXPoint);  
    }
    return result;
  }
}
