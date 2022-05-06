using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public float speed;
    Vector2 nextPos; 
    public float acceptableDistanceFromWp = 1f;
    Vector2 movement;
    float xBound = 512, yBound = 288;
    
    void Start() {
        nextPos.x = Random.Range(-xBound, xBound);    
        nextPos.y = Random.Range(-yBound, yBound);    
    }
    
    void FixedUpdate() { 
        float moveSpeed = speed;
        if (Vector2.Distance(transform.position, nextPos) < acceptableDistanceFromWp) {
            nextPos.x = Random.Range(-xBound, xBound);    
            nextPos.y = Random.Range(-yBound, yBound);
        }
        movement = nextPos;
        movement -= (Vector2)transform.position;
        movement.Normalize();
        transform.position = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
    }
}
