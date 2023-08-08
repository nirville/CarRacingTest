using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Nirville.CarTestGame
{

    public class HUDControl : MonoBehaviour
    {
        public TMP_Text speed;
        public TMP_Text drift;

        CarController carController;

        private void Awake()
        {
            carController = GetComponent<CarController>();
        }

        private void Update()
        {
            drift.gameObject.SetActive(carController.isDrifting);

            speed.text = "Speed: " + carController.CarSpeed.ToString("F0");

            if (carController.isDrifting)
                drift.text = "Drift: " + carController.driftScore.ToString("F0");
        }
    }
}
