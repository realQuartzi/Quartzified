namespace Quartzified
{
	public static class Mathematics
	{
		public static class Numbers
		{
			///<summary>
			///Return the Sum of all inputs added together
			///</summary>
			///<param name="inputs"></param>
			///<returns></returns>
			public static int GetSum(int[] inputs)
			{
				int sum = 0;
				for (int i = 0; i < inputs.Length; i++)
				{
					sum += inputs[i];
				}
				return sum;
			}


			public static int GetAverage(int[] inputs)
			{
				int average = GetSum(inputs) / inputs.Length;
				return average;
			}

			public static long ClampLong(long value, long min, long max)
			{
				if (value < min) return min;
				if (value > max) return max;
				return value;
			}
			
			public static int GetRandomInt(int min = 0, int max = 100)
			{
				System.Random r = new System.Random();
				
				int rnd = r.Next(min, max + 1);
				
				return rnd;
			}
			
			public static float GetRandomFloat(float min = 0f, float max = 100f)
			{
				System.Random r = new System.Random();
				
				float rnd = (float)(r.NextDouble() * (max - min) + min);
				
				return rnd;
			}
			
			public static double GetRandomDouble(double min = 0.0, double max = 100.0)
			{
				System.Random r = new System.Random();
				
				double rnd = r.NextDouble() * (max - min) + min;
				
				return rnd;
			}
			
			public static bool GetRandomIntThreshold(int min = 0, int max = 100, int threshold = 50)
			{
				int rnd = GetRandomInt(min, max);
				
				return rnd < threshold ? true : false;
			}
			
			public static bool GetRandomFloatThreshold(float min = 0f, float max = 100f, float threshold = 50f)
			{
				float rnd = GetRandomFloat(min, max);
				
				return rnd < threshold ? true : false;
			}
			
			public static bool GetRandomDoubleThreshold(double min = 0.0, double max = 100.0, double threshold = 50.0)
			{
				double rnd = GetRandomDouble(min, max);
				
				return rnd < threshold ? true : false;
			}
		}
	}
}
