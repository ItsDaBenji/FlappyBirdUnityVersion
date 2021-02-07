using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    [SerializeField] int columnPoolSize = 5;
    [SerializeField] GameObject columnPrefab;
    [SerializeField] float columnMin = -1f;
    [SerializeField] float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

    private float timeSinceLastSpawn;
    public float spawnRate = 4;
    [SerializeField] float spawnXPosition = 10f;
    private int currentColumn = 0;

    private void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameManager.instance.gameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
