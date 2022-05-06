using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class World : MonoBehaviour {
    public float numberOfPeople;
    public GameObject peoplePrefab;
    public GameObject alienPrefab;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI roundTime;
    public GameObject startGUI;
    public GameObject roundGUI;
    
    float totalTime = 0;
    float bestTime = 10000;
    float xBound = 550, yBound = 320;
    bool isGameRunning = false;
    List<GameObject> people;

    float xLeftBound = -660, xRightBound = 660, yUpperBound = 400, yBottomBound = -320;
    
    void Start() {
        GeneratePeople();
    }

    void GeneratePeople() {
        people = new List<GameObject>();
        for (int i = 0; i < numberOfPeople; i++) {
            Vector3 pos = new Vector3(Random.Range(xLeftBound, xRightBound), Random.Range(yBottomBound, yUpperBound), 0);
            people.Add(Instantiate(peoplePrefab, pos, Quaternion.identity));
            people[i].SetActive(false);
        }
    }

    void Update() {
        if (!isGameRunning && Input.GetKeyDown("space")) StartGame();
        if (isGameRunning) CountTime();
        if (GameObject.FindWithTag("Person") == null && isGameRunning) GameOver(true);
    }

    void CountTime() {
        totalTime += Time.deltaTime;
        roundTime.text = totalTime.ToString("0.00s", System.Globalization.CultureInfo.InvariantCulture);
    }

    void StartGame() {
        isGameRunning = true;
        GenerateAlien();
        ActivatePeople();
        roundGUI.SetActive(true);
        startGUI.SetActive(false);
    }

    public void GameOver(bool won = false) {
        isGameRunning = false;
        RemoveEntities();

        if (won == true && totalTime < bestTime) {
            bestTime = totalTime;
            highScore.text = bestTime.ToString("0.00s", System.Globalization.CultureInfo.InvariantCulture);
        }
        
        totalTime = 0;
        roundGUI.SetActive(false);
        startGUI.SetActive(true);
    }

    void RemoveEntities() {
        DisableAll("Person");
        Destroy(GameObject.FindWithTag("Alien"));
    }

     void DisableAll(string tag) {
         GameObject[] toDelete = GameObject.FindGameObjectsWithTag(tag);
         for (int i = 0; i< toDelete.Length; i++) {
            toDelete[i].SetActive(false);
         }
     }

    void GenerateAlien() {        
        Vector3 alienPos = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound,yBound), 0);
        GameObject alien = Instantiate(alienPrefab, alienPos, Quaternion.identity);
    }

    void ActivatePeople() {
        for (int i = 0; i < numberOfPeople; i++) {
            people[i].SetActive(true);
        }   
    }
}
