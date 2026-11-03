using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] birdPrefabs;
    [SerializeField] float timeBetween = 0.5f;
    [SerializeField] float randomYMax = 3;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(SpawnBirdCoroutine());
    }

    IEnumerator SpawnBirdCoroutine()
    {
        while (true)
        {
            float rt = timeBetween + Random.Range(0f, 0.2f);
            yield return new WaitForSeconds(rt);
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        int r = Random.Range(0, birdPrefabs.Length);
        GameObject clone = Instantiate(birdPrefabs[r]);
        float ry = Random.Range(0f, randomYMax);
        clone.transform.position = transform.position + new Vector3(0, ry, 0);
        clone.transform.rotation = transform.rotation;
    }

    
}
