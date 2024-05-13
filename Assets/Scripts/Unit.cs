using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float health;
    public float speed;
    private SpriteRenderer spriteRenderer;
    // public bool isSelected = false;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSelected(bool selected) {
        spriteRenderer.color = selected ? Color.green : Color.white;
    }
}
