using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _camera;


    void Start() {
        GeneratorGrid();
    }
    void GeneratorGrid() {
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _height; y++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                // spawnedTile.transform.localPosition = new Vector3(x + x * _gap, y + y * _gap, 0f);
			
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 !=0) || (x % 2 != 0 && y % 2 ==0);
            }
        }

        _camera.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f, -10);
    }
}
