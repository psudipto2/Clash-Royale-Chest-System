using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class CancelButtonContoller : MonoBehaviour
    {
        [SerializeField] private GameObject PopUp;
        [SerializeField] private Button cancelButton;
        private void Start()
        {
            cancelButton = cancelButton.GetComponent<Button>();
            cancelButton.onClick.AddListener(DisablePopup);
        }
        private void DisablePopup()
        {
            if (PopUp.activeInHierarchy)
            {
                PopUp.SetActive(false);
            }
        }
    }
}


