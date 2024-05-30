using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private Transform selectionAreaTransform;
    private Vector3 startingPosition;
    private List<Unit> selectedUnits;

    private void Awake() {
        selectedUnits = new List<Unit>();
        selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            selectionAreaTransform.gameObject.SetActive(true);
            startingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        }

        if(Input.GetMouseButton(0)) {
            Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currMousePos.z = 0f;
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startingPosition.x, currMousePos.x),
                Mathf.Min(startingPosition.y, currMousePos.y)
            );
            Vector3 upperRight = new Vector3(
                Mathf.Max(startingPosition.x, currMousePos.x),
                Mathf.Max(startingPosition.y, currMousePos.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if(Input.GetMouseButtonUp(0)) {
            selectionAreaTransform.gameObject.SetActive(false);

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapAreaAll(startingPosition, mousePosition);
            
            foreach(Unit unit in selectedUnits) {
                unit.SetSelected(false);
            }
            selectedUnits.Clear();

            foreach(Collider2D col in colliders) {
                Unit unit = col.GetComponent<Collider2D>().GetComponent<Unit>();
                if(unit != null) {
                    unit.SetSelected(true);
                    selectedUnits.Add(unit);
                }
            }
        }

        if(Input.GetMouseButtonDown(1)) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            foreach (Unit unit in selectedUnits) {
                unit.MoveTo(mousePosition);
            }
        }
    }
}
