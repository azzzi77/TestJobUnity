using UnityEngine;

public class PlayerPrefsData : IData<SerializableGameObject>
{
		public void Save(SerializableGameObject data, string path = null)
		{
			PlayerPrefs.SetInt("Money", data.Money);
			PlayerPrefs.SetInt("Crystal", data.Crystal);
			

			//-----------------------------
			PlayerPrefs.Save();
		}

		public SerializableGameObject Load(string path = null)
		{
			var result = new SerializableGameObject();

			var key = "Money";
			if (PlayerPrefs.HasKey(key))
			{
				result.Money = PlayerPrefs.GetInt(key);
			}

			key = "Crystal";
			if (PlayerPrefs.HasKey(key))
			{
				result.Crystal = PlayerPrefs.GetInt(key);
			}

   		    return result;
		}

		public void Clear()
		{
			PlayerPrefs.DeleteAll();
		}
}
