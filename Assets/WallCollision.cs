using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallCollision : MonoBehaviour
{
    public UnityEvent wallSuccessfulCollisionEvent;

    public float pushBackForce = 2;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<MeshRenderer>() == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("CubeUntouched"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("CubeTouched") && collision.gameObject.GetComponent<MeshRenderer>().material.name == gameObject.GetComponent<MeshRenderer>().material.name)
        {
            wallSuccessfulCollisionEvent.Invoke();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("CubeTouched") && collision.gameObject.GetComponent<MeshRenderer>().material.name != gameObject.GetComponent<MeshRenderer>().material.name)
        {
            collision.gameObject.tag = "CubeUntouched";

            if (PointerPickup.instance.GetComponent<PointerPickup>().pickupGO == null)
            {
                return;
            }


            if (collision.transform != PointerPickup.instance.GetComponent<PointerPickup>().pickupGO.transform.parent)
            {
                return;
            }

            PointerPickup.instance.GetComponent<PointerPickup>().pickupGO.transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3((collision.transform.position.x - transform.position.x) * pushBackForce, 0,0));

            Destroy(PointerPickup.instance.GetComponent<PointerPickup>().pickupGO);
        }
    }
}
