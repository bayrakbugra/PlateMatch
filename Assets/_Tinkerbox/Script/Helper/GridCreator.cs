using System.Collections;
using System.Collections.Generic;
using Script.Cell;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class GridCreator : MonoBehaviour
{

    public GameObject GridPrefab;
    public List<GameObject> GridList;
    public float XOffset;
    public float ZOffset;

    public int Row;
    public int Column;

    public string GridLayerName;
    
    private GameObject _parent;
    
    [Button]
    public void CreateGrid()
    {
        ClearLast();
        GridList.Clear();
        
        _parent = new GameObject("Grid_Parent");
        _parent.transform.position = Vector3.zero;
        
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                GameObject go = Instantiate(GridPrefab);
                go.transform.position = new Vector3(j + (j* XOffset), 0, i+ (i* ZOffset));
                go.GetComponent<CellParent>().BCell.Column = j;
                go.GetComponent<CellParent>().BCell.Row = i;
                
                GridList.Add(go);
                go.transform.SetParent(_parent.transform);

                go.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer(GridLayerName);
            }
        }
    }

    private void ClearLast()
    {
      
        if(_parent != null) DestroyImmediate(_parent);
    }

   
}
