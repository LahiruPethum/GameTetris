using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public static int row = 10;
    public static int col = 20;

    public static Transform[,] grid = new Transform[row, col];

    public static Vector2 Round(Vector2 v)
    {

        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool isinside(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.y >= 0 && (int)pos.x < row);
    }

    public static void deleteRow(int y)
    {
        for (int x = 0; x < row; ++x)
        {
            GameObject.Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void decreasRow(int y)
    {
        for (int x = 0; x < row; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreasAboveRow(int y)
    {
        for (int i = y; i < col; ++i)
        {
            decreasRow(i);
        }
    }

    public static bool isfullRow(int y) {
        for (int x=0;x<row ;++x ) {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    public static void deletewholeRow() {
        for (int y = 0; y < col; ++y) {
            if (isfullRow(y)) {
                deleteRow(y);
                decreasAboveRow(y+1);
                --y;
            }
        }
    }
}






