using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Penguin : MonoBehaviour
{
    //I feel like if each penguin had a box colider for themselves it wouldn't be unreasonable
    //just need to make layer for penguins and then disable collision matrix for penguins/penguins
    [SerializeField] private Collider2D _collider;

    private GameObject _Dish;
    private GameObject[] _penguins;
    Vector3 _DishPos;
    //can't get delta time in the constructor since there is no time since last frame.
    //float _deltaT = Time.deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        _penguins = GameObject.FindGameObjectsWithTag("Penguin");
        _Dish = GameObject.Find("Dish");
        _DishPos = _Dish.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PenguinMove();
        }
    }

    public void PenguinBreak()
    {
        _collider.enabled = false;
    }

    public void PenguinMove()
    {
        //lerp to dish

        //Debug.Log(_penguins);
        //int i = 0;

        //these 2 are nitpicks
        //rename p to penguin
        //using explicit typing on penguin makes the code a bit more readable
        foreach (GameObject penguin in _penguins)
        {   
            //since you have a foreach loop you can do penguin as opposed to indexing _penguins
            //Vector2 _currentPos = _penguins[i].transform.position;

            //_penguins[i] is a gameobject not a Penguin object, it can't make use of Penguin.SetPosition().
            //_penguins[i].SetPosition(Vector2.Lerp(_currentPos, _DishPos, _deltaT));

            //this is only run when PenguinMove() is called which is only when you release space bar (GetKeyUp() in Update() function)
            //I switched GetKeyUp() to GetKey() so that you can hold space and see the example on line 69
            //lerping using an objects current position will cause some wonky movement on the penguin.
            //half of the distance between (0, 0) and (10, 0) is 5, your next lerp is between (5, 0) and (10, 0) which will give you somewhere around 2.5 units of movement
            //(not exactly 2.5 since you'd be increasing your lerp val but you get the idea.

            //_penguins[i].SetPosition(Vector2.Lerp(_currentPos, _DishPos, _deltaT));
            //(yes that line is the same as 57 but it made sense in my head to split the 2 ideas)

            //you can see the lerp issues with this line here
            //  penguin.transform.position = Vector2.Lerp(_currentPos, _DishPos, Time.deltaTime);
            //they start out fast and then move slow towards the end and never actually reach the end point.

            //with foreach loop you probably don't need an iterator
            //i++;

            //I think the system is a little flawed. The core idea is there and makes sense but it needs a little bit of reworking.
            //general lerp format is this
            
            //outside of loop:
            //startPos = ObjectStartingPosition
            //endPos = ObjectEndPosition
            //lerpDuration = TimeItTakesForObjectToReachDestination
            //lerpTime = 0f;
            //isLerping = false;

            //in loop/update:
            //lerpTime += Time.deltaTime;

            //newPos = Vector2.Lerp(startPos, endPos, lerpTime / lerpDuration);
            //transform.position = newPos; (you can skip assigning newPos and just set transform.position to the lerp result if you want)

            //this makes sense since you are saying "I want my lerp to last 2 seconds regardless of framerate.
            //it also maintains a consistent start and end position so that a consistent increase to the 3rd value in the lerp function (the alpha) is consistent movement.
            //the math behind lerpTime / lerpDuration is since the alpha of a lerp is between 0 and 1, you want the alpha to be 1 when your time is up
            //which is when lerpTime is equal to 2 (2/2 = 1) in this case. When lerpTime is equal to 0 (0/2 = 0) it is at the start of the movement.
            //lerpTime gets increased by the time between frames (Time.deltaTime) in seconds meaning if you have 1fps, it would take 2 seconds (and 2 frames)
            //the same as if you have 60fps, it would take 2 seconds (or 120 frames). This also works for if you have lag spikes or other issues in framerate
        }
       
    }

    public void SetPosition(Vector2 pos)
    {
        //this is a good system for accessing private members of a class (get and set functions)
        //but for someting like a GameObject's position that is already a public member from the transform component so it isn't needed.
        //also _position is also not defined earlier

        //_position = pos;
    }
}
