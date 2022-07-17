using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    Vector3 _meteorScale;
    public float _spawnAngle = 30;
    public GameObject _meteorPrefab;

    public void GenerateMeteor()
    {
        // Instantiates a meteor.

        Instantiate(ScaleMeteor(), SpawnPosition(),_meteorPrefab.transform.rotation);
    }

    public GameObject ScaleMeteor()
    {
        // Scales the newly created meteor.

        _meteorPrefab.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        _meteorScale = _meteorPrefab.transform.localScale;
        _meteorScale *= Random.Range(1.0f, 5.0f);
        _meteorPrefab.transform.localScale = _meteorScale;

        return _meteorPrefab;
    }

    public Vector3 SpawnPosition()
    {
        // Generates a random position within ranges.

        float spawnPositionX = Random.Range(-_spawnAngle, _spawnAngle);
        float spawnPositionY = Random.Range(-_spawnAngle, _spawnAngle);
        float spawnPositionZ = Random.Range(-_spawnAngle, _spawnAngle);

        Vector3 generatedPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
        return generatedPosition;
    }
}
