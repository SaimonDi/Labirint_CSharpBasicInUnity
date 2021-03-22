using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class SaveAndLoadController : IExecute
        {
        private readonly SaveDataRpository _saveDataRpository;
        private readonly ListExecuteObject _interactiveObjects;
        private readonly PlayerBase _playerBase;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public SaveAndLoadController(ListExecuteObject interactiveObjects, PlayerBase player)
            {
            _saveDataRpository = new SaveDataRpository();
            _interactiveObjects = interactiveObjects;
            _playerBase = player;
            }

        public void Execute()
            {
            if(Input.GetKeyDown(_savePlayer)) _saveDataRpository.Save(_interactiveObjects, _playerBase);
            if(Input.GetKeyDown(_loadPlayer)) _saveDataRpository.Load(_interactiveObjects, _playerBase);
            }
        }
    }