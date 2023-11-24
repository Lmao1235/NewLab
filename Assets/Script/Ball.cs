using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}


public class Ball : MonoBehaviour
{
    [SerializeField]
    private int point;
    public int Point { get { return point; } }

    [SerializeField]
    private BallColor ballColor;

    [SerializeField]
    private MeshRenderer rd;

    void Awake()
    {
        rd = GetComponent<MeshRenderer>();
    }

    public void SetColorAndPoint(BallColor col)
    {
        switch (col)
        {
            case BallColor.White:
                point = 0;
                rd.material.color = Color.white;
                break;
            case BallColor.Red:
                point = 1;
                rd.material.color = Color.red;
                break;
            case BallColor.Yellow:
                point = 2;
                rd.material.color = Color.yellow;
                break;
            case BallColor.Green:
                point = 3;
                rd.material.color = Color.green;
                break;
            case BallColor.Brown:
                point = 4;
                rd.material.color = new Color32(106, 64, 34, 255);
                break;
            case BallColor.Blue:
                point = 5;
                rd.material.color = Color.blue;
                break;
            case BallColor.Pink:
                point = 6;
                rd.material.color = new Color32(180, 45, 159, 255);
                break;
            case BallColor.Black:
                point = 7;
                rd.material.color = Color.black;
                break;
         
        }
    }
}
