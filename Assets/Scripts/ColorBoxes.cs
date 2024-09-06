using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorBoxes : MonoBehaviour
{

    
   













    /*
    
    I've decided to go a different direction with this

    public XRDirectInteractor handInteractor;
    private XRGrabInteractable grabInteractable; 

    // Start is called before the first frame update
    private void Start()
    {
        balls = new Queue<GameObject>();

        grabInteractable = GetComponent<XRGrabInteractable>();  
        grabInteractable.selectEntered.AddListener(SpawnBall);  
    }

    public void SpawnBall(SelectEnterEventArgs args)
    {
        GameObject newBall = Instantiate(ballPrefab, handInteractor.transform.position, handInteractor.transform.rotation);

        XRGrabInteractable newBallInteractable = newBall.GetComponent<XRGrabInteractable>();
        if (newBallInteractable == null)
        {
            newBallInteractable = newBall.AddComponent<XRGrabInteractable>();
        }

        StartCoroutine(GrabObjectAfterSpawn(newBallInteractable));

        balls.Enqueue(newBall);

        if (balls.Count > maxBall)
        {
            GameObject oldBall = balls.Dequeue();
            Destroy(oldBall);
        }
    }

    private IEnumerator GrabObjectAfterSpawn(XRGrabInteractable ball)
    {
        yield return new WaitForEndOfFrame();

        handInteractor.interactionManager.SelectEnter(handInteractor, ball);
    */
}
