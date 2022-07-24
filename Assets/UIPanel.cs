using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameManager game;
    public Vector3 pozitionBegin;
    public Vector3 pozitionEnd;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pozitionBegin = eventData.position;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        game.left = false;
        game.Right = false;
        game.Up = false;
        game.Down = false;

       pozitionEnd = eventData.position;
        if (pozitionBegin.x > pozitionEnd.x)
        {
            game.height = pozitionBegin.x - pozitionEnd.x;
        }
        else
        {
            game.height = pozitionEnd.x - pozitionBegin.y;
        }

        if (pozitionBegin.y > pozitionEnd.y)
        {
            game.width = pozitionBegin.y - pozitionEnd.y;
        }
        else
        {
            game.width = pozitionEnd.y - pozitionEnd.y;
        }
        if (game.height < 0)
        {
            game.height *= -1;
        }
        if (game.width < 0)
        {
            game.width *= -1;
        }

        if (game.height > game.width)
        {
            if (pozitionBegin.x > pozitionEnd.x)
            {
                game.left = true;
            }
            else
            {
                game.Right = true;
            }
        }
        else
        {
            if (pozitionBegin.y > pozitionEnd.y)
            {
                game.Up = true;
            }
            else
            {
                game.Down = true;
            }
        }
        game.click = true;
    }
}
