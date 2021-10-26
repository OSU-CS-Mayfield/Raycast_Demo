using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float fireDelay = 0.5f;
    public float timeToReady = 0.5f;

    private int layerMask;
    private bool readyToFire = true;

    // Use this for initialization
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("MyRaycastLayer");
    }

    void Update()
    {
        // Draw a ray in the scene editor.
        Debug.DrawRay(transform.position,
          transform.forward * 200, Color.green);

        if (!readyToFire)
        {
            timeToReady -= Time.deltaTime;

            if (timeToReady <= 0f)
            {
                readyToFire = true;
                timeToReady = fireDelay;
            }
        }

        if (Input.GetMouseButton(0) && readyToFire)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position,
            transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                hit.collider.SendMessage("Hit", hit,
                        SendMessageOptions.DontRequireReceiver);
                this.GetComponent<AudioSource>().Play();
            }
            readyToFire = false;
        }
    }
}
