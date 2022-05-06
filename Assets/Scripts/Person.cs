using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {
    public float walkingSpeed, runningSpeed;
    public float acceptableDistanceFromWp = 0.01f;
    public SpriteRenderer bodySr;
    public SpriteRenderer headSr;
    public List<Color> bodyColorList;
    public List<Color> headColorList;

    Vector2 nextPos; 
    Vector2 movement;
    float xLeftBound = -660, xRightBound = 660, yUpperBound = 400, yBottomBound = -320;
    
    void Start() {
        nextPos.x = Random.Range(xLeftBound, xRightBound);    
        nextPos.y = Random.Range(yBottomBound, yUpperBound);   
        bodySr.color = bodyColorList[Random.Range(0, bodyColorList.Count - 1)];
        headSr.color = headColorList[Random.Range(0, headColorList.Count - 1)];
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
    
    void FixedUpdate() { 
        float moveSpeed = runningSpeed;
        if (Vector2.Distance(transform.position, nextPos) < acceptableDistanceFromWp) {
            nextPos.x = Random.Range(xLeftBound, xRightBound);    
            nextPos.y = Random.Range(yBottomBound, yUpperBound);
        }
        movement = nextPos;
        movement -= (Vector2)transform.position;
        movement.Normalize();
        transform.position = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
    }
}
