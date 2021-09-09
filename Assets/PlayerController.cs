using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

//    private void OnMouseDown()
//    {
//        transform.parent = transform.parent.parent;
//    }

    public void OnTransformParentChanged()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(UpdateBoard(transform.parent.parent.GetComponent<BoardController>()));
    }

    public IEnumerator UpdateBoard(BoardController gameBoard)
    {
        yield return new WaitForSeconds((float) 0.2);
        gameBoard.PlayerMove();
    }

    private void OnMouseUp()
    {
        var parent = transform.parent.parent.GetComponent<BoardController>().hovered;
        transform.parent = parent;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
