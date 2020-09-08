using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tatrix;
    

    void Start()
    {
        randamSelect();
    }

    public void randamSelect() {
        int index = Random.Range(0, tatrix.Length);
        transform.position = new Vector3(5, 18, -10);
        Instantiate(tatrix[index], transform.position, Quaternion.identity);
    }
}
