using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nirville.CarTestGame
{
    public class CameraController : MonoBehaviour
    {
        public GameObject FPSCam;
        public GameObject TPSCam;
        private void Start()
        {
            GameManager.Instance.OnCameraChanged += SwitchCamera;
        }

        void SwitchCamera()
        {
            Debug.Log("Switched");
            if(TPSCam.activeInHierarchy)
            {
                TPSCam.SetActive(false);
                FPSCam.SetActive(true);
            }
            else
            {

                TPSCam.SetActive(true);
                FPSCam.SetActive(false);
            }
        }
    }
}