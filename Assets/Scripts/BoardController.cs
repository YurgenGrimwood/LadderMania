using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardController : MonoBehaviour
{
    private int _boardWith = 10;
    private int _boardHeight = 10;

    private List<SnakeController> _snakes = new List<SnakeController>();

    public GameObject gameTile;
    public GameObject snake;
    public GameObject player;

    public Transform hovered;

    void AddLadderSnake(int x, int y, int movement)
    {

        int[] newCoords = GetCoords(GetPosition(x, y) + movement);
        GameObject newSnake = Instantiate(snake, new Vector3(0, 0, 0), Quaternion.identity);
        newSnake.transform.parent = transform.Find(x + ", " + y);
        newSnake.transform.localPosition = new Vector3(0, 0, 0);
        newSnake.GetComponent<SnakeController>().SetPoints(newCoords[0], newCoords[1], x, y);
        _snakes.Add(newSnake.GetComponent<SnakeController>());
    }

    public void PlayerMove()
    {
        _snakes.ForEach(x => x.CheckForPlayer());
    }

    public void Roll()
    {
        var parent = player.transform.parent;
        string[] coords = parent.name.Replace(" ", "").Split(',');
        int position = GetPosition(int.Parse(coords[0]), int.Parse(coords[1]));
        int steps = (int) Math.Round(Random.value * 5, 0)+1;
        int[] newCoords = GetCoords(position + steps);
        player.transform.parent = transform.Find(newCoords[0] + ", " + newCoords[1]);
    }

    public int[] GetCoords(int position)
    {
        int remaining = position;
        int[] coords = {0, 0};
        while (remaining > 9)
        {
            coords[1] += 1;
            remaining -= 10;
        }

        coords[0] = remaining;
        Debug.Log(coords[0] +", "+coords[1]);
        if (coords[1] > _boardHeight-1)
        {
            coords[1] = _boardHeight-1;
            coords[0] = _boardWith-1;
        }
        return coords;
    }

    public int GetPosition(int x, int y)
    {
        return y * _boardWith + x;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < _boardWith; i++)
        {
            for (int k = 0; k < _boardHeight; k++)
            {
                GameObject newObj = Instantiate(gameTile, new Vector3(i, k, 0), Quaternion.identity);
                newObj.name = i + ", " + k;
                newObj.transform.parent = transform;
            }
            
        }

        hovered = transform.Find(0 + ", " + 0);
        transform.SetPositionAndRotation(new Vector3((float) (0.5-_boardHeight/2), (float) (0.5-_boardWith/2), 0), Quaternion.identity);
        AddLadderSnake(5, 5, -10);
        AddLadderSnake(3, 4, -12);
        AddLadderSnake(5, 7, 12);
        AddLadderSnake(4, 6, 12);
        gameTile.SetActive(false);


        player.transform.parent = transform.Find(0 + ", " + 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
