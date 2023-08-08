using System;
using UnityEngine;


namespace Nirville.CarTestGame
{
    public class GameManager : MonoBehaviour
    {
        internal static GameManager Instance { get; private set; }

        public event Action OnCameraChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                OnCameraChanged?.Invoke();
            }
        }

    }
}

