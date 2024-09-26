using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class BasketParticleHolder 
{
    public List<ParticleSystem> WashParticleList;
    public List<ParticleSystem> AfterWashParticleList;
    public BasketController BC { get; set; }
    
    public void PlayWashParticle()
    {
        float t = 0;
        ParticleState(WashParticleList,true);

      
        
        DOTween.To(x => t = x, 0, 1, .3f).OnComplete(() =>
        {
            ParticleState(WashParticleList, false);
            
            for (int i = 0; i < BC.CurrentBasketMono.BHPlate.HoldedPlateList.Count; i++)
            {
                BC.CurrentBasketMono.BHPlate.HoldedPlateList[i].transform
                    .DOShakePosition(.2f, .05f, 1, 1f, false, false,ShakeRandomnessMode.Harmonic).SetEase(Ease.Linear)
                    .SetLoops(2, LoopType.Yoyo);
                //BC.CurrentBasketMono.BHPlate.HoldedPlateList[i].transform.DOLocalMoveY(.2f, .2f).SetEase(Ease.Linear).SetLoops(2,LoopType.Yoyo);
            }
            
            PlayAfterWashParticle();
        });
    }

    public void PlayAfterWashParticle()
    {
        ParticleState(AfterWashParticleList,true);

        for (int i = 0; i < BC.CurrentBasketMono.BHPlate.HoldedPlateList.Count; i++)
        {
            BC.CurrentBasketMono.BHPlate.HoldedPlateList[i].GetComponent<PlateParent>().BPlate.DisableAllGrime();
        }
        
        float t = 0;
        
        
        DOTween.To(x => t = x, 0, 1, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            BC.MoveToNextBasket();
            
        });
    }

    private void ParticleState(List<ParticleSystem> particleList,bool isPlay)
    {
        for (int i = 0; i < particleList.Count; i++)
        {
            if(isPlay)particleList[i].Play();
            if(!isPlay) particleList[i].Stop();
        }
    }
}
