using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public TypeOfBasket BType;
    public BasketMono CurrentBasketMono;
    public List<GameObject> AllBasketList;
    public ReserveParent RParent;
    private bool _control;
    private int _currentBasketIndex = 0;
    private void Start()
    {
        CurrentBasketMono = AllBasketList[0].GetComponent<BasketMono>();
        SetBasketControllerBasketType();
    }

    public void MoveToNextBasket()
    {
        AllBasketList[_currentBasketIndex].transform.DOMoveX(10, 0.25f).SetEase(Ease.Linear);
        _currentBasketIndex++;
        AllBasketList[_currentBasketIndex].transform.DOMoveX(1.8f, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
        {
            CurrentBasketMono = AllBasketList[_currentBasketIndex].GetComponent<BasketMono>();
            RParent.CheckAllReserve(CurrentBasketMono.BTHolder.BasketType,CurrentBasketMono.BHPlate.GetNeededPlateCount());
        });

    }

    private void Update()
    {
      /*  if (CurrentBasketMono != null && _control)
        {
            _control = false;
            RParent.CheckAllReserve(CurrentBasketMono.BTHolder.BasketType,CurrentBasketMono.BHPlate.GetNeededPlateCount());
        }

        if (CurrentBasketMono == null) _control = true;*/
    }

    #region Basket Type Setter
    public void SetBasketControllerBasketType() => BType = CurrentBasketMono.BTHolder.BasketType;

    #endregion

    #region Editor

    [Button]
    public void RePositionBasket()
    {
        ListShuffler shfl = new ListShuffler();
        AllBasketList = shfl.ShuffleList(AllBasketList);

        for (int i = 0; i < AllBasketList.Count; i++)
        {
            AllBasketList[i].transform.position = new Vector3(1.8f - (i * 5.4f), .1f, -2.5f);
        }
    }

    #endregion
    
    public class ListShuffler
    {
        
        public List<T> ShuffleList<T>(List<T> list)
        {
            System.Random random = new System.Random();
            int n = list.Count;
        
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
            
                
                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }
    }
}
