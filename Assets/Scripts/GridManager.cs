using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float x_Start, z_Start;

    public int columLength, rowLength;
    public float x_Space, z_Space;
    public GameObject gridUnit;
    public GameObject figure;
    public GameObject figure2;

    public float figuresSpawnHight;

    public List<GameObject> gridList = new List<GameObject>();
    public List<Vector3> tilesTransformList = new List<Vector3>();
    public List<GameObject> spawnedFiguresList = new List<GameObject>();

    public Material tileMaterialOdd, tileMaterialEven;


    void Awake()
    {
        SpawnGrid();
    }
    
    public void SpawnGrid()
    {
        if(gridList.Count > 0)
        ClearGrid();

        for(int i = 0; i < columLength * rowLength; i++)
        {
            GameObject _tile = Instantiate(
                gridUnit, 
                new Vector3(x_Start +(x_Space * (i % columLength)), 0 ,z_Start + (-z_Space * (i / columLength))), 
                Quaternion.identity, 
                this.transform);
            
            Renderer renderer = _tile.GetComponent<Renderer>();
            renderer.material = i % 2 == 0 ? tileMaterialEven : tileMaterialOdd;

            Vector3 _tileTransform = new Vector3(_tile.transform.position.x, figuresSpawnHight, _tile.transform.position.z);

            tilesTransformList.Add(_tileTransform);
            gridList.Add(_tile);
        }

        SpawnObjectsOnGrid(30, figure);
        SpawnObjectsOnGrid(30, figure2);
    }

    public void ClearGrid()
    {
        for(int i = 0; i < gridList.Count; i++)
        {
            DestroyImmediate(gridList[i]);
        }

        for(int i = 0; i < spawnedFiguresList.Count; i++)
        {
            DestroyImmediate(spawnedFiguresList[i]);
        }

        gridList = new List<GameObject>();
        tilesTransformList = new List<Vector3>();
        spawnedFiguresList = new List<GameObject>();
    }

    public void SpawnObjectsOnGrid(int _amount, GameObject _object)
    {
        int _randomIndex;
        GameObject _spawnedObject;
        Vector3 _selectedLocation;

         for(int i = 0; i < _amount; i++)
        {
            _randomIndex = Random.Range(0, tilesTransformList.Count);
            _selectedLocation = tilesTransformList[_randomIndex];
            tilesTransformList.RemoveAt(_randomIndex);

            _spawnedObject = Instantiate(
                _object, 
                _selectedLocation, 
                Quaternion.identity, 
                this.transform);

            spawnedFiguresList.Add(_spawnedObject);
        }
    }
}
