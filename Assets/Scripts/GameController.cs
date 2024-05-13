using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Vector3 startingPosition;
    private List<Unit> selectedUnits;

    private void Awake() {
        selectedUnits = new List<Unit>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            startingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        }

        if(Input.GetMouseButtonUp(0)) {
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
            Debug.Log(selectedUnits.Count);
        }
    }
}
