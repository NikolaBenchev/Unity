using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public float health;
    public float speed;
    private SpriteRenderer spriteRenderer;
    private MovePositionDirect movePosition;
    // private IMoveVelocity moveVelocity;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movePosition = GetComponent<MovePositionDirect>();
        // moveVelocity = GetComponent<IMoveVelocity>();
    }

    public void SetSelected(bool selected) {
        spriteRenderer.color = selected ? Color.green : Color.white;
    }

    public void MoveTo(Vector3 targetPosition) {
        movePosition.SetMovePosition(targetPosition);
    }
}
