using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetrixobj : MonoBehaviour
{
    private float lastfall;
    public float falltime = 0.8f;
    public Vector3 rotationPoint;
    // Start is called before the first frame update
    float derection;
    Rigidbody2D rb;


    
    


    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 

        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
            
                transform.position += new Vector3(-1, 0, 0);

                if (isValidGridPosition())
                {
                    updateGrid();
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (isValidGridPosition())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }






        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {


            transform.Rotate(new Vector3(0, 0, -90));

            if (isValidGridPosition())
            {
                updateGrid();


            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 90));
            }






        } 


        else if ((Time.time - lastfall > (Input.GetKey(KeyCode.DownArrow) ? falltime / 10 : falltime)) || Time.time - lastfall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidGridPosition())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Grid.deletewholeRow();
                FindObjectOfType<Controler>().randamSelect();
                enabled = false;
            }
            lastfall = Time.time;
        }
    }


    


    bool isValidGridPosition() {
        foreach (Transform child in transform) {
            Vector2 v = Grid.Round(child.position);

            if (!Grid.isinside(v))
                return false;

            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;

        }
        return true;

    }
    void updateGrid() {
            for (int y = 0; y < Grid.col; ++y) {
                for (int x=0;x<Grid.row; ++x) {
                    if (Grid.grid[x, y] != null) {
                        if (Grid.grid[x, y].parent == transform) {
                            Grid.grid[x, y] = null;
                        }
                    }
                }
            }

            foreach (Transform child in transform) {
                Vector2 v = Grid.Round(child.position);
                Grid.grid[(int)v.x, (int)v.y] = child;
            }
    }
   


}
