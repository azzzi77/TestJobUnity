using System;
using System.IO;

public sealed class StreamData : IData<SerializableGameObject>
{
		public void Save(SerializableGameObject data, string path = null)
		{
			if (path == null) return;
			using (var sw = new StreamWriter(path))
			{
				sw.WriteLine(data.Money);
				sw.WriteLine(data.Crystal);
			}
		}

		public SerializableGameObject Load(string path = null)
		{
			var result = new SerializableGameObject();

			using (var sr = new StreamReader(path))
			{
				while (!sr.EndOfStream)
				{
					result.Money = int.Parse(sr.ReadLine());
					result.Crystal = int.Parse(sr.ReadLine());
				}
			}
			return result;
		}
	
}