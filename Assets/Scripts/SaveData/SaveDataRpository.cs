using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class SaveDataRpository
        {
        private readonly IData<HashSet<SavedData>> _data;
        private HashSet<SavedData> _hashList; //Создаём список с быстрым добавлением объектов

        private const string _floderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRpository()
            {
            //if(Application.platform == RuntimePlatform.WebGLPlayer)
            //    _data = new PlayerPrefsData();
            //else
            _data = new SerializableXMLData<HashSet<SavedData>>();

            _hashList = new HashSet<SavedData>();

            _path = Path.Combine(Application.dataPath, _floderName);
            }

        public void Save(ListExecuteObject interactiveObjects, PlayerBase player)
            {
            if(!Directory.Exists(Path.Combine(_path)))
                Directory.CreateDirectory(_path);

            foreach(var o in interactiveObjects) //Добавляем в список наши бонусы
                {
                if(o is BadBonus badBonus)
                    {
                    var saveObject = new SavedData
                        {
                        Position = badBonus.transform.position,
                        Name = badBonus.name,
                        IsEnabled = true
                        };
                    _hashList.Add(saveObject);
                    }
                if(o is GoodBonus goodBonus)
                    {
                    var saveObject = new SavedData
                        {
                        Position = goodBonus.transform.position,
                        Name = goodBonus.name,
                        IsEnabled = goodBonus.isActiveAndEnabled
                        };
                    _hashList.Add(saveObject);
                    }
                }

            var savePlayer = new SavedData
                {
                Position = player.transform.position,
                Name = player.name,
                IsEnabled = true
                };
            _hashList.Add(savePlayer); //Добавляем игорка в список
            
            _data.Save(_hashList, Path.Combine(_path, _fileName)); //Сериализуем все объекты в списке
            _hashList.Clear();
            }
        
        public void Load(ListExecuteObject interactiveObjects, PlayerBase player)
            {
            var file = Path.Combine(_path, _fileName);
            if(!File.Exists(file)) return;

            var newObjects = _data.Load(file);

            foreach(var o in newObjects)
                {
                if(o.Name == player.name)
                    {
                    player.transform.position = o.Position;
                    player.name = o.Name;
                    player.gameObject.SetActive(o.IsEnabled);
                    Debug.Log(o);
                    }
                foreach(var i in interactiveObjects)
                    {
                    if(i is BadBonus badBonus && o.Name == badBonus.name)
                        {
                        badBonus.transform.position = o.Position;
                        badBonus.name = o.Name;
                        badBonus.gameObject.SetActive(o.IsEnabled);
                        Debug.Log(o);
                        }
                    if(i is GoodBonus goodBonus && o.Name == goodBonus.name)
                        {
                        goodBonus.transform.position = o.Position;
                        goodBonus.name = o.Name;
                        goodBonus.IsInteractable = o.IsEnabled;
                        Debug.Log(o);
                        }
                    }
                }
            }
        }
    }