using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerPickup : MonoBehaviour
{

    public GameObject pointer;

    public GameObject pickupGO;

    public float pullForce;

    public static PointerPickup instance;


    void Start()
    {
        instance = this;
    }

     // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("CubeUntouched") || hit.transform.gameObject.CompareTag("CubeTouched"))
                {
                    pickupGO = Instantiate(pointer, hit.point, Quaternion.identity);
                    pickupGO.transform.SetParent(hit.transform);
                    if (hit.transform.gameObject.CompareTag("CubeUntouched"))
                    {
                        hit.transform.gameObject.tag = "CubeTouched";
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(pickupGO);
        }


        if (pickupGO != null)
        {
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 11));

            pickupGO.transform.parent.GetComponent<Rigidbody>().AddForceAtPosition((mouseWorldPoint - pickupGO.transform.position) * pullForce, pickupGO.transform.position);
        }
    }
}
