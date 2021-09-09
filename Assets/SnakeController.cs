using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public int x;
    public int y;
    private int z;
    private int w;

    public void SetPoints(int x, int y, int z, int w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;

        Vector3 dest = new Vector3(x, y);
        Vector3 orig = new Vector3(z, w);
        Vector3 diag = dest - orig;
        
        transform.localPosition = new Vector3(diag.x/2,diag.y/2, 0);
        transform.localScale = new Vector3((float) 0.5, (float) (0.5*diag.magnitude), 0);
        double angle = - Math.Atan2(diag.x, diag.y) * 180 / Math.PI;
        transform.Rotate(0, 0, (float) angle);
        BoardController board = transform.parent.parent.GetComponent<BoardController>();
        if (board.GetPosition(z, w) < board.GetPosition(x, y))
        {
            transform.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    public void CheckForPlayer()
    {
        int count = transform.parent.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform child = transform.parent.GetChild(i);
            if (child.GetComponent<PlayerController>() != null)
            {
                child.parent = transform.parent.parent.Find(x + ", " + y);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
