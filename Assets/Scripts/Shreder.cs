using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponentInParent<Pin>())
        {
            Destroy(thingLeft.transform.parent.gameObject);
        }
    }
}
