using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject HeadSnake,Line;
    public List<GameObject> ListObstacleGroup;
    int count = 0;
	// Update is called once per frame
	void Update () {
        if (MainGameManager.gameStatus == GameStatus.PLAYING)
        {
            if (transform.childCount < 4)
            {
                count++;
                Instantiate(ListObstacleGroup[Random.Range(0, ListObstacleGroup.Count)], new Vector3(0, count * 6), Quaternion.identity, transform);
                if (count % 3 == 1)
                {
                    GameObject obj=Instantiate(Line, new Vector3(0, count * 6+3), Quaternion.identity, transform);
                    do
                    {
                        obj.GetComponent<SpriteRenderer>().color = Snake.ColorOfSnake[Random.Range(0, Snake.ColorOfSnake.Length)];
                    } while (obj.GetComponent<SpriteRenderer>().color == HeadSnake.GetComponent<SpriteRenderer>().color);
                }
            }
            Debug.Log(Camera.main.transform.position.y - Camera.main.orthographicSize - 6);
            if (transform.GetChild(0).position.y < (Camera.main.transform.position.y - Camera.main.orthographicSize - 6)) Destroy(transform.GetChild(0).gameObject);
        }
	}
}
