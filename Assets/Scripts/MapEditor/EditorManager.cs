using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares.Editor
{
    public class EditorManager : MonoBehaviour
    {

        public static EditorManager Instance { get; protected set; }

        public Map CurrentMap { get; protected set; }

        // Start is called before the first frame update
        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one EditorManager in the scene!");
            }
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeMap(Map newMap)
        {
            CurrentMap = newMap;
        }

        void OnDestroy()
        {
            Instance = null;
        }

    }
}
