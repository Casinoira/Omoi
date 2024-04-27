using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    public static gridManager Instance;

    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _camera;
    // [SerializeField] private Transform _pinball;

    private Dictionary<Vector2, Tile> _tiles;
    
    void Awake() {
        Instance = this;
    }

    // void Start() {
    //     GenerateGrid();
    // }

    public void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _height; y++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 !=0) || (x % 2 != 0 && y % 2 ==0);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x,y)] = spawnedTile;
            }
        }

        _camera.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f, -10);
        // _pinball.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f, 0);

        GameManager.Instance.UpdateGameState(GameState.GameStart);
    }

    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) {
            return tile;
        }
        
        return null;
    }
}
