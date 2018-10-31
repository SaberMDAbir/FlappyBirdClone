using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int ColumnPoolSize = 5;
    public GameObject ColumnPreFab;
    public float SpawnedRate = 4f;
    public float ColumnMin = -1f;
    public float ColumnMax = 3.5f; 

    private GameObject[] Columns;
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);
    private float TimeSinceLastSpawned;
    private float SpawnXPosition = 1f;
    private int CurrentColumn = 0;

	// Use this for initialization
	void Start () {
        Columns = new GameObject[ColumnPoolSize];
        for (int i = 0; i < ColumnPoolSize; i++) {
            Columns[i] = (GameObject)Instantiate(ColumnPreFab, ObjectPoolPosition, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // counting up
        TimeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.GameOver == false && TimeSinceLastSpawned > SpawnedRate) {
            TimeSinceLastSpawned = 0;
            float SpawnYPosition = Random.Range(ColumnMin, ColumnMax);
            Columns[CurrentColumn].transform.position = new Vector2(SpawnXPosition, SpawnYPosition);
            CurrentColumn++;
            if(CurrentColumn >= ColumnPoolSize) {
                CurrentColumn = 0;
            }
        }
	}
}
