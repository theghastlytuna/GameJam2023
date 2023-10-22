using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleMultiPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    
    Vector3 newPos;
    Vector3 endPos;
    float lerpTime = 0f;
    public bool isLerping = false;
    Vector2 startPos;
    [SerializeField] float lerpDuration = 2.5f;

    [SerializeField] float waitTime = 3.0f;
    float _timer = 0.0f;
    bool timerActive = true;
    int pointIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (timerActive == true)
            {
                
                _timer += Time.deltaTime;

                if (_timer > waitTime)
                {
                    startPos = transform.position;
                    if (pointIndex == points.Length)
                    {
                    pointIndex = 0;
                    }
                    else
                    {
                        pointIndex++;
                    }
                    endPos = points[pointIndex].transform.position;
                    _timer = _timer - waitTime;
                    isLerping = true;
                    timerActive = false;
                }

            }

        if (isLerping == true)
        {
            Move(startPos, endPos);
        }

    }

    public void Move(Vector2 startPos, Vector2 endPos)
    {
        //lerp to dish
        lerpTime += Time.deltaTime;
        newPos = Vector2.Lerp(startPos, endPos, lerpTime / lerpDuration);
        transform.position = newPos;//(you can skip assigning newPos and just set transform.position to the lerp result if you want)


        if (lerpTime / lerpDuration > 1f)
        {
            isLerping = false;
            timerActive = true;
            lerpTime = 0f;
        }

    }
}

