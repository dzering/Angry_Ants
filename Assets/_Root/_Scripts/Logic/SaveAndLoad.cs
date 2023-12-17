using System.IO;
using UnityEngine;

namespace _Root._Scripts.Logic
{
    public class SaveAndLoad<T> where T : new()
    {
        private readonly string _path;

        public SaveAndLoad(string path)
        {
            _path = path;
        }

        public void Save(T result)
        {
            string json = JsonUtility.ToJson(result);
            File.WriteAllText(_path, json);
        }

        public T Load()
        {
            if (!File.Exists(_path))
                return new T();

            string readAllText = File.ReadAllText(_path);
            return JsonUtility.FromJson<T>(readAllText);
        }
    }
}