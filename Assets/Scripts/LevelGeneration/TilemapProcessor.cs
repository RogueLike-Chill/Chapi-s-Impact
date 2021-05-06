using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapProcessor : MonoBehaviour
{
    Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        TileBase[] tiles = map.GetTilesBlock(map.cellBounds);
        BoundsInt bounds = map.cellBounds;
        List<TileBase> tilesReal = new List<TileBase>();
        for (int i = 0; i < bounds.size.x; i++)
        {
            for (int j = 0; j < bounds.size.y; j++)
            {
                TileBase tile = tiles[i + j * bounds.size.x];
                if (tile)
                {
                    tilesReal.Add(tile);
                }
            }
        }

        print(tilesReal.Count);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
