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
    public bool right;
    public bool up;
    public bool down;
    public int indexX;
    public int indexY;
    private bool move;
    private int points;
    public Text pointsText;


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
        RandomBlocks();
    }

    void Update()
    {
        pointsText.text = "" + points;
            if (click == true)
        {
            click = false; 
            //Down();
            if (left == true)
            {
                Left();
                left = false;
                Debug.Log("left");
            }
            else if (right == true)
            {
                right =false;
                Right();
                Debug.Log("Right");
            }
            else if (down == true)
            {
                Down();
            }
            if (move == true)
            {
                move = false;
                RandomBlocks();

            }
        }
    }
    private int RandomBlock()
    {
        return Random.Range(0, 4);

    }


    private void RandomBlocks()
    {
        indexX = RandomBlock();
        if (indexX == 0 || indexX == 3)
        {

            indexY = RandomBlock();
        }
        else
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                indexY = 0;
            }
            else
            {
                indexY = 3;
            }

        }

        if (blocks[indexX, indexY].index != 0)
        {
            RandomBlocks();
        }
        else
        {
            int rnd = Random.Range(1, 3);
            blocks[indexX, indexY].index = rnd;
        }
    }

    //private void SimilarRight()
    //{
    //    for (int y = 0; y < 4; y++)
    //    {
    //        for (int x = 2; x >= 0; x--)
    //        {
    //            if (blocks[x, y].index ==blocks[x-1, y].index)
    //                {
    //                    move = true;
    //                    blocks[x, y].index++;
    //                    blocks[x - 1, y].index = 0;
    //                }
    //                else
    //                {
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //}

    public void Right()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 2; x >= 0; x--)
            {

                if (blocks[x, y].index != 0)
                {
                    for (int z = x + 1; z < 4; z++)
                    {
                        if (blocks[z, y].index == 0)
                        {
                            move = true;
                            blocks[z, y].index = blocks[z - 1, y].index;
                            blocks[z - 1, y].index = 0;

                        }
                        else
                        {
                            if (blocks[z, y].index == blocks[z - 1, y].index)
                            {
                                move = true;
                                blocks[z, y].index++;
                                blocks[z - 1, y].index = 0;

                                points += blocks[z, y].index / 2;
                            }
                        break;
                        }
                    }
                }
            }
        }
    }




    public void Left()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 1; x < 4; x++)
            {
                if (blocks[x, y].index != 0)
                {

                    for (int z = x - 1; z >= 0; z--)
                    {
                        if (blocks[z, y].index == 0)
                        {
                            move = true;
                            blocks[z, y].index = blocks[z + 1, y].index;
                            blocks[z + 1, y].index = 0;
                        }
                        else
                        {
                            if (blocks[z, y].index == blocks[z + 1, y].index)
                            {
                                move = true;
                                blocks[z, y].index++;
                                blocks[z + 1, y].index = 0;

                                points += blocks[z, y].index / 2;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }


    public void Down()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 2; y >= 0; y--)
            {
                if (blocks[x, y].index != 0)
                {
                    for (int z = y + 1; z < 4; z++)
                    {
                        if (blocks[x, z].index == 0)
                        {
                            move = true;
                            blocks[x, z].index = blocks[x, z - 1].index;
                            blocks[x, z - 1].index = 0;

                        }
                        else
                        {
                            if (blocks[x, z].index == blocks[x, z-1].index)
                            {
                                move = true;
                                blocks[x, z].index++;
                                blocks[x,z - 1].index = 0;
                                points += blocks[x, z].index / 2;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }



    public void RandomPole()
    {
        int amount = 0;
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (blocks[x, y].index == 0)
                {
                    amount++;
                }
            }
        }
        if (amount == 0)
        {
            Debug.Log("END");
        }
    }
}


