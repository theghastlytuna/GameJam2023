using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Penguin : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    private GameObject _Dish;
    private GameObject[] _penguins;
    Vector3 _DishPos;
    float _deltaT = Time.deltaTime;

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
        if (Input.GetKeyUp(KeyCode.Space))
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
        Debug.Log(_penguins);
        int i = 0;
        foreach (var p in _penguins)
        {
            Vector2 _currentPos = _penguins[i].transform.position;
            _penguins[i].SetPosition(Vector2.Lerp(_currentPos, _DishPos, _deltaT));
            i++;
        }
       
    }

    public void SetPosition(Vector2 pos)
    {
        _position = pos;
    }
}
