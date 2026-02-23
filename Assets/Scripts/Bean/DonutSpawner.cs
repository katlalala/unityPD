using System.Collections;
using UnityEngine;

public class DonutSpawner : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float bakeInterval = 1.0f;
    public float spawnWidth = 0.7f;
    public Transform donutBin;

    private Coroutine _spawnRoutine;

    public void ToggleBaking(bool start)
    {
        if (_spawnRoutine != null) StopCoroutine(_spawnRoutine);
        if (start) _spawnRoutine = StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float xPos = Random.Range(transform.position.x - spawnWidth, transform.position.x + spawnWidth);
            Vector2 spawnPos = new Vector2(xPos, transform.position.y);
            int index = Random.Range(0, donutPrefabs.Length);
            
            Instantiate(donutPrefabs[index], spawnPos, Quaternion.identity, donutBin);
            yield return new WaitForSeconds(bakeInterval);
        }
    }
}