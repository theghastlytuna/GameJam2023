using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 relativePos;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetLookAtAngle()));

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Throw");
        }
    }

    private float GetLookAtAngle()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        relativePos = mousePos - transform.position;

        angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;

        return angle;
    }

}
