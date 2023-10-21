using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Penguin : MonoBehaviour
{
    private GameObject _Dish;
    private GameObject[] _penguins;
    Vector3 newPos;
    public Vector3 endPos;
    float lerpTime = 0f;
    public bool isLerping = false;
    Vector2 startPos;
    float lerpDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _penguins = GameObject.FindGameObjectsWithTag("Penguin");
        _Dish = GameObject.Find("Dish");
        endPos = _Dish.transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerping == true)
        {
            PenguinMove();
        }

        float _deltaT = Time.deltaTime;
    }


    public void PenguinMove()
    {
        //lerp to dish

        lerpTime += Time.deltaTime;
        Debug.Log(lerpTime);
        newPos = Vector2.Lerp(startPos, endPos, lerpTime / lerpDuration);
        transform.position = newPos;//(you can skip assigning newPos and just set transform.position to the lerp result if you want)


        if (newPos == endPos)
        {
            isLerping = false;
        }
        else
        {
            Debug.Log("Penguins Arrived");
        }

    }
}
