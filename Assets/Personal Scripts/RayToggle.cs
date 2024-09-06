using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RayToggle : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    public InputActionReference primaryButtonAction;

    private void OnEnable()
    {
        primaryButtonAction.action.performed += OnPrimaryButtonPressed;
    }

    private void OnDisable()
    {
        primaryButtonAction.action.performed -= OnPrimaryButtonPressed;
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext context)
    {
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        foreach (GameObject obj in objectsToToggle)
        {

            obj.SetActive(!obj.activeSelf);
        }
    }
}