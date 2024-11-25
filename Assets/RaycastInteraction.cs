using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInteraction : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLenght;
    public LayerMask layer;
    public GameObject uiGO;
    public Text hintText;
    public float hintTime;
    public string defaultHint;
    public bool isopening = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        InteractableObject interactable = null;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLenght, layer))
        {            
            interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable && !interactable.activated)
            {
                hintText.text = "Press E to open!";
            }
            if (interactable && interactable.activated && isopening == false) 
            {
                hintText.text = "Already opened!";

            }
        }
        uiGO.SetActive(interactable);
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            if (!interactable.activated)
            {
                interactable.PlayObjectAnimation();
            }
            
            StopAllCoroutines();
            StartCoroutine(ShowHintDuringTime());
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLenght);
    }

    IEnumerator ShowHintDuringTime()
    {
        float time = 0;
        while (time < hintTime)
        {
            isopening = true;
            hintText.text = "Opening...";

            time += Time.deltaTime;
            uiGO.SetActive(true);
            yield return null;
        }
        isopening = false;
        uiGO.SetActive(false);
    }

}
