using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class BasketPlateMovement
{
    private BasketHoldedPlate _bhp;
    private BasketHoldedTransfrom _bht;

    public BasketPlateMovement(BasketHoldedPlate bhp , BasketHoldedTransfrom bht)
    {
        _bhp = bhp;
        _bht = bht;
    }
    
     public void MoveOnBasket(List<GameObject> movedList)
    {
        for (int i = 0; i < movedList.Count; i++)
        {
            var a = movedList[i].gameObject;
            a.transform.DOJump(_bht.HoldedTransformList[_bhp.HoldedPlateList.Count].transform.position, 2f, 1, .5f).SetEase(Ease.Linear).SetDelay(0.1f + (i*0.1f));
            a.transform.DORotate(new Vector3(360, 0, 0), .5f , RotateMode.FastBeyond360).SetEase(Ease.Linear).SetDelay(0.1f + (i * 0.1f)).OnComplete(() =>
            {
                a.transform.DOLocalRotate(new Vector3(0, -90, 60), 0.1f, RotateMode.Fast).SetEase(Ease.Linear)
                    .SetDelay(0.1f);

            });

            movedList[i].transform.parent = _bhp.ParentObject;
            _bhp.AddBasketHoldedList(movedList[i]);
        }
    }
}
