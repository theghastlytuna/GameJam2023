using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private GameObject pointOne;
    [SerializeField] private GameObject pointTwo;

    Vector3 newPos;
    Vector3 endPos;
    float lerpTime = 0f;
    public bool isLerping = false;
    Vector2 startPos;
    [SerializeField] float lerpDuration = 2.5f;
    bool hasMoved;

    [SerializeField] float waitTime = 3.0f;
    float _timer = 0.0f;
    bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = pointOne.transform.position;
        endPos = pointTwo.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            _timer += Time.deltaTime;

            if (_timer > waitTime)
            {
                _timer = _timer - waitTime;
                isLerping = true;
                timerActive = false;
            }

        }
        if (isLerping == true)
        {
            Move();

        }

    }

    public void Move()
    {
        //lerp to dish
        if (hasMoved == false)
        {
            lerpTime += Time.deltaTime;
            newPos = Vector2.Lerp(startPos, endPos, lerpTime / lerpDuration);
            transform.position = newPos;//(you can skip assigning newPos and just set transform.position to the lerp result if you want)
        }

        if (hasMoved == true)
        {
            lerpTime += Time.deltaTime;
            newPos = Vector2.Lerp(endPos, startPos, lerpTime / lerpDuration);
            transform.position = newPos;//(you can skip assigning newPos and just set transform.position to the lerp result if you want)
        }


        if (lerpTime / lerpDuration > 1f)
        {
            hasMoved = !hasMoved;
            isLerping = false;
            timerActive = true;
            lerpTime = 0f;
        }

    }
}
