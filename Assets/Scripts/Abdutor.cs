using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abdutor : MonoBehaviour {
    public World worldManager;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Person") {
            collision.gameObject.GetComponent<Person>().Disable();
        }
        if (collision.gameObject.tag == "Alien") {
            worldManager.GameOver();
        }
    }
}
