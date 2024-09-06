using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    public enum Colors { Red, Blue, Yellow };
    public Colors ballColor;

    private XRGrabInteractable grabInteractable;
    public bool isBeingHeld = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isBeingHeld = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isBeingHeld = false;
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
