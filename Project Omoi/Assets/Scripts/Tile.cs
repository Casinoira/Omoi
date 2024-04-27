using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
        // print("Mouse in");
    }

    void OnMouseExit() {
        _highlight.SetActive(false);
        // print("Mouse out");
    }

    void OnMouseDown() {
        // if(GameManager.Instance.GameState != GameState.GameStart) return;

        // if (OccupiedUnit != null) {

        // }
    }
}
