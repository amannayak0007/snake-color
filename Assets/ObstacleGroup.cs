using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroup : MonoBehaviour {

    public bool haveSnakeColor=false;
	void Start () {
        Collider2D[] elements = GetComponentsInChildren<Collider2D>();
        Color snakeColor = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        if(GameObject.FindGameObjectWithTag("Line")!=null)
            snakeColor = GameObject.FindGameObjectWithTag("Line").GetComponent<SpriteRenderer>().color;
        bool check = false;
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].GetComponent<SpriteRenderer>().color = Snake.ColorOfSnake[Random.Range(0, Snake.ColorOfSnake.Length)];
            if (elements[i].GetComponent<SpriteRenderer>().color == snakeColor) check = true;
        }
        if (haveSnakeColor&&!check)
        {
            elements[Random.RandomRange(0,elements.Length)].GetComponent<SpriteRenderer>().color = snakeColor;
        }
	}
}
