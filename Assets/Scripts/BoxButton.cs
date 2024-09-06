using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoxButton : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    public int maxBall = 3;  
    private Queue<GameObject> balls;

    [SerializeField] Transform box;
    Vector3 spawnPos;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Coroutine resetCoroutine;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        balls = new Queue<GameObject>();

        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add listener for button activation (to spawn balls)
        grabInteractable.activated.AddListener(SpawnBall);

        // Add listeners for when the button is picked up and dropped
        grabInteractable.selectExited.AddListener(OnDrop);
        grabInteractable.selectEntered.AddListener(OnPickup);

    }

    private void SpawnBall(ActivateEventArgs args)
    {
        spawnPos = new Vector3(box.position.x + Random.Range(-0.1f, 0.1f), box.position.y + .1f, box.position.z + Random.Range(-0.1f, 0.1f));

        GameObject newBall = Instantiate(ballPrefab, spawnPos, box.rotation);
        balls.Enqueue(newBall);

        if (balls.Count > maxBall)
        {
            GameObject oldBall = balls.Dequeue();
            Destroy(oldBall);
        }
    }

    private void OnDrop(SelectExitEventArgs args)
    {
        // Start the coroutine to reset the button if not picked up within 3 seconds
        resetCoroutine = StartCoroutine(ResetAfterDelay());
    }

    private void OnPickup(SelectEnterEventArgs args)
    {
        // Cancel the reset coroutine if the button is picked up again
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
    }

    private IEnumerator ResetAfterDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Reset the button position and rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    private void OnDestroy()
    {
        grabInteractable.activated.RemoveListener(SpawnBall);
        grabInteractable.selectExited.RemoveListener(OnDrop);
        grabInteractable.selectEntered.RemoveListener(OnPickup);
    }
}
