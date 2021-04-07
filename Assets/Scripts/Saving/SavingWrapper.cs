using System;
using UnityEngine;

namespace Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string DefaultSaveFile = "savegame";
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.F8))
            {
                Load();
            }
        }

        private void Save()
        {
            GetComponent<SavingSystem>().Save(DefaultSaveFile);
        }

        private void Load()
        {
            GetComponent<SavingSystem>().Load(DefaultSaveFile);
        }
    }
}
