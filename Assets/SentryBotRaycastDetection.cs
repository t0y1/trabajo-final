using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBotRaycastDetection : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLenght;
    public LayerMask layerMask;
    public SentryBotBehavior sbb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayLenght, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                sbb.Fplayer = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLenght);
    }
}
