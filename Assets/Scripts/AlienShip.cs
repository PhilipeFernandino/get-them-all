using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour {
    public GameObject abdutor;
    public float moveSpeed = 20f;
    Vector2 movement;

    void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        abdutor.SetActive(Input.GetMouseButton(0));
    }

    void FixedUpdate() {
        transform.position = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
    }
}
