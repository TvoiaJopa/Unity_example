using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] private AudioSettingsPopup popup;

    void Start()
    {
        popup.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);

            if (isShowing)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
