using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [Space]
    [SerializeField] private float _distanceToTriggerSpawn;
    [SerializeField] private List<TerrainElement> _terrainElementPrefabList;
    [SerializeField] private List<TerrainElement> _terrainElementPrePlace;
    [SerializeField] private List<TerrainSlice> _currentTerrainSlice;
    private bool _canSpawnElement = false;

    void Start()
    {
        foreach (var item in _terrainElementPrePlace)
            foreach (var slice in item.Slice)
                _currentTerrainSlice.Add(slice);
    }


    //TODO Spawn les slice une par une plutot que tout l'element 


    private void SpawnTerrainElement(out int lastSliceCount)
    {
        Vector3 spawnPos = new Vector3(_currentTerrainSlice.Count, 0, 0);
        TerrainElement newTerrainElement = Instantiate(_terrainElementPrefabList[Random.Range(0, _terrainElementPrefabList.Count)]
                                                    , spawnPos, Quaternion.identity);

        // newTerrainElement.transform.parent = transform;
        foreach (var item in newTerrainElement.Slice)
        {
            _currentTerrainSlice.Add(item);
        }

        lastSliceCount = newTerrainElement.Slice.Count;
    }

    private void Update()
    {
        // print(_playerTransform.position.x % _distanceToTriggerSpawn);
        float mod = _playerTransform.position.x % _distanceToTriggerSpawn + 0.5f;

        if (mod > _distanceToTriggerSpawn * 0.5f && mod < _distanceToTriggerSpawn * 0.8f)
            _canSpawnElement = true;

        if (mod > _distanceToTriggerSpawn && _canSpawnElement)
        {
            _canSpawnElement = false;
            SpawnTerrainElement(out int sliceCount);
            _distanceToTriggerSpawn = sliceCount;
        }
    }
}
