using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Material material;
    public int index;
    void Start()
    {
        index = 0;
    }
       

    void Update()
    {
         gameObject.GetComponent<Image>().sprite =material.material[index];
    
    }
}
