using System;
using UnityEngine;

namespace _Theatre.Scripts.Services
{
    public static class SaveController
    {
        public static void SaveObject(Enum typeObject)
        {
            PlayerPrefs.SetString(typeObject.GetType().ToString(), typeObject.ToString());
            PlayerPrefs.Save();
        }

        public static void LoadObject()
        {
            
        }
    }
}