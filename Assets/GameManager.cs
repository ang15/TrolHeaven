using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    public Block[,] blocks;
    [SerializeField]
    private Material material;

    public float width;
    public float height;
    public bool click;
    public bool left;
    public bool Right;
    public bool Up;
    public bool Down;
    public int indexX;
    public int indexY;


    void Start()
    {
        blocks = new Block[4, 4];
        int i = 0;
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                blocks[x, y] = cubes[i].GetComponent<Block>();
                blocks[x, y].material = material;
                i++;
            }
        }
        indexX = RandomBlocks();
        indexY = 0;
        blocks[indexX, 0].index = 1;

    }

    void Update()
    {
        if (click == true)
        {
            if (left == true)
            {

                Debug.Log("left");
            }
            else if (Right == true) {
                Debug.Log("Right");
            }
            else if (Up == true)
            {
                Debug.Log("Up");
            }
            else if (Down == true)
            {
                Debug.Log("Down");
            }
            click = false;
        }
    }
    private int RandomBlocks()
    {
        return Random.Range(0, 4);

    }
    //public void Left()
    //{
    //    for(int i = indexX; i <)
    //    {

    //        blocks[indexX, indexY]=

    //    }


    //}

    //public void RandomPole()
    //{
    //    List<Block> empty = new List<Block>();
    //    for (int y = 0; y < 4; y++)
    //    {
    //        for (int x = 0; x < 4; x++)
    //        {
    //            if (blocks[x, y].index == 0)
    //            {
    //                empty.Add(blocks[x, y]);
    //            }
    //        }
    //    }
    //    if (empty.Count != 0)
    //    {
    //        int value = Random.Range(0, 10) == 0 ? 2 : 1;
    //        var
    //    }
    //}

}
