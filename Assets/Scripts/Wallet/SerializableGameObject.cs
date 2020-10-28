using System;
using UnityEngine;

    [Serializable]
	public struct SerializableGameObject
	{
		public int Money;
        public int Crystal;

        public override string ToString()
		{
			return $"Money = {Money}; Crystal = {Crystal};";
		}
	}

	
