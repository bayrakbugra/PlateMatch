using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script.Plate;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public  class PlateEditor
{
    public GameObject PlatePrefab;
    public int PlateCount;
}

[System.Serializable]
public class dnm
{
    public List<GameObject> d;
}

[System.Serializable]
public class LevelEditor : MonoBehaviour
{
    public List<PlateEditor> PlateList;
    public List<Transform> ActiveCellList;
    public GameObject CreatedParent;
    
    public List<GameObject> BasketPrefabList;

    public BasketController BC;
    
    [Button]
    public void CreatePlate()
    {
      
        if(CreatedParent != null) DestroyImmediate(CreatedParent);

        var prnt = new GameObject("All Plate");
        CreatedParent = prnt;
        
        for (int i = 0; i < ActiveCellList.Count; i++)
        {
            ActiveCellList[i].GetComponent<CellParent>().CHoldedList.ClearAllList();
        }
        
        for (int i = 0; i < PlateList.Count; i++)
        {
            var p = new GameObject("PlateParent");
            for (int j = 0; j < PlateList[i].PlateCount; j++)
            {
                var rnd = Random.Range(0, ActiveCellList.Count);
                Debug.Log(rnd);
                var cll = ActiveCellList[rnd];
                cll.GetComponent<CellParent>().BCell.OnDebugRowColumn();
                
                var plt =Instantiate(PlateList[i].PlatePrefab);
                
                plt.transform.localPosition = cll.position + new Vector3(0,(0.1f)+(cll.GetComponent<CellParent>().CHoldedList.PlateList.Count*0.1f),0);
                plt.transform.localPosition += new Vector3(Random.Range(-0.095f, 0.095f), 0, 0);
                
                //p.transform.position = cll.transform.position;
                
                cll.GetComponent<CellParent>().CHoldedList.AddList(plt);
                
               plt.transform.SetParent(p.transform);
            }
            
            p.transform.SetParent(prnt.transform);
        }
    }

    [Button]
    public void ShufflePlate()
    {
        for (int i = 0; i < ActiveCellList.Count; i++)
        {

            ActiveCellList[i].GetComponent<CellParent>().CHoldedList.ShuffleList();
        }
    }

    [Button]
    public void CreateBasket()
    {
        TypeOfBasket t = (TypeOfBasket)PlateList[0].PlatePrefab.GetComponent<PlateParent>().PTHolder.PlateType;
        BC.AllBasketList.Clear();
        var parent = new GameObject("BasketParent");
        parent.transform.position = Vector3.zero;
        
        for (int i = 0; i < PlateList.Count; i++)
        {
            var count = PlateList[i].PlateCount / 12;
          
            for (int j = 0; j < count; j++)
            {
                GameObject go = Instantiate(BasketPrefabList[i]);
                go.transform.parent = parent.transform;
                BC.AllBasketList.Add(go);
            }
        }

    }

 
    
}
