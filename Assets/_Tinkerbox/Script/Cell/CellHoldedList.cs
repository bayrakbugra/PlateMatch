using System.Collections.Generic;
using DG.Tweening;
using Script.Plate;
using UnityEngine;

namespace Script.Cell
{
    [System.Serializable]
    public class CellHoldedList
    {
        public List<GameObject> PlateList;
        public CellManager _cManager { get; set; }
        public BaseCell _bCell { get; set; }
        public bool _isActive { get; set; }
        /*public CellHoldedList(BaseCell bc,CellManager cm ,bool isActive)
        {
            if(bc == null) Debug.Log("BC NULL");
            if(cm == null) Debug.Log("CM NULL");
            
            _cManager = cm;
            _bCell = bc;
            _isActive = isActive;
        }*/
        public void AddList(GameObject go) => PlateList.Add(go);

        public void RemoveGameObject(GameObject go)
        {
            if(IsPlateListZero()) return;
            
                PlateList.Remove(go);
                if (IsPlateListZero())
                {
                    float f = 0;

                    DOTween.To(x => f = x, 0, 1, 0.4f).SetEase(Ease.Linear)
                        .OnComplete(() =>
                        {
                            Debug.LogError("CLEAR!");
                            List<Vector2> pos = new List<Vector2>();
                            Vector2 v = new Vector2(_bCell.Column, _bCell.Row);
                            pos.Add(v);
                            Vector2 l = new Vector2(_bCell.Column - 1, _bCell.Row);
                            Vector2 r = new Vector2(_bCell.Column + 1, _bCell.Row);
                            Vector2 u = new Vector2(_bCell.Column, _bCell.Row + 1);
                            Vector2 d = new Vector2(_bCell.Column, _bCell.Row - 1);
                            _cManager.OnSetCellStatus(l, r, u, d);
                        });

                }
               
            
          
        }
        

        public GameObject GetLastObject() => PlateList[^1];

        public void RemoveListByForLoop(List<GameObject> willRemove)
        {
            for (int i = 0; i < willRemove.Count; i++)
            {
                RemoveGameObject(willRemove[i]);
            }
        }

        public void ClearAllList() => PlateList.Clear();
        
        public void ShuffleList()
        {
            List<GameObject> l1 = new List<GameObject>();
            List<GameObject> l2 = new List<GameObject>();
            List<GameObject> l3 = new List<GameObject>();
            List<GameObject> l4 = new List<GameObject>();
            List<List<GameObject>> totalList = new List<List<GameObject>>();

            for (int i = 0; i < PlateList.Count; i++)
            {
                if (PlateList[i].GetComponent<PlateParent>().PTHolder.PlateType == TypeOfPlate.Type1)
                {
                    l1.Add(PlateList[i]);
                }
                else if (PlateList[i].GetComponent<PlateParent>().PTHolder.PlateType == TypeOfPlate.Type2)
                {
                    l2.Add(PlateList[i]);

                }
                else if (PlateList[i].GetComponent<PlateParent>().PTHolder.PlateType == TypeOfPlate.Type3)
                {
                    l3.Add(PlateList[i]);

                }
                else
                {
                    l4.Add(PlateList[i]);

                }
            }

            if (l1.Count > 0)
            {
                
                    totalList.Add(l1);
              
            }
            if (l2.Count > 0)
            {
            
                    totalList.Add(l2);
                
            }
            if (l3.Count > 0)
            {
              
                    totalList.Add(l3);
                
            }
            if (l4.Count > 0)
            {
               
                    totalList.Add(l4);
                
            }

            totalList = ShuffleList2(totalList);
            PlateList.Clear();

            for (int i = 0; i < totalList.Count; i++)
            {
                for (int j = 0; j < totalList[i].Count; j++)
                {
                    totalList[i][j].transform.position = new Vector3(totalList[i][j].transform.position.x,
                        0.1f + (PlateList.Count * 0.1f), totalList[i][j].transform.position.z);
                    PlateList.Add(totalList[i][j]);
                }
            }
            
            
        }
        
        public List < List<GameObject>> ShuffleList2(List <List<GameObject>> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
            return list;
        }

        public void SetTableRotation(bool canClick,float jumpPower,float jumpDuration)
        {
           //if(IsPlateListZero()) return;
            if(PlateList.Count == 0) return;
            
            for (int i = 0; i < PlateList.Count; i++)
            {
                if (canClick)
                {
                    PlateList[i].transform.DORotate(Vector3.zero, .1f,RotateMode.Fast).SetEase(Ease.Linear).SetDelay(0.025f + (0.01f * i));
                    
                    //PlateList[i].transform.DOLocalRotate(new Vector3(0,0,180), .1f).SetEase(Ease.Linear).SetDelay(0.025f + (0.01f * i));
                }
                else
                {
                    PlateList[i].transform.DORotate(new Vector3(0,0,180), .1f).SetEase(Ease.Linear).SetDelay(0.025f + (0.01f * i));
                }
                PlateList[i].transform.DOLocalJump(new Vector3(PlateList[i].transform.position.x,PlateList[i].transform.position.y,PlateList[i].transform.position.z)
                    , jumpPower, 1, jumpDuration).SetEase(Ease.Linear).SetDelay(0.025f + (0.025f * i));
            }
            
        }

        public int GetHoldedPlateListCount() => PlateList.Count;

        public bool IsPlateListZero()
        {
            if (GetHoldedPlateListCount() == 0) return true;

            return false;
        }

        public void SetPlatePosition(bool canClick,GameObject target)
        {
            //if(IsPlateListZero()) return;
            if(PlateList.Count == 0) return;

            float f = 0f;
            
            DOTween.To(x => f = x, 0, 1, .3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                for (int i = 0; i < PlateList.Count; i++)
                {
                    var tPosX = (target.transform.position.x);
                    if (canClick)
                    {
                        PlateList[i].transform.DOMoveX(tPosX, .1f).SetEase(Ease.Linear);
                    }
                    else
                    {
                        tPosX += Random.Range(-0.095f, 0.095f);
                        PlateList[i].transform.DOMoveX(tPosX, .1f).SetEase(Ease.Linear);
                    }
                }
            });
            
          
        }
    }
}
