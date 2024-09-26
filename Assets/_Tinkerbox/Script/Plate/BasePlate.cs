using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Script.Plate
{
    [System.Serializable]
    public class BasePlate
    {
        public List<GameObject> GrimeList;

        public void DisableAllGrime()
        {
            for (int i = 0; i < GrimeList.Count; i++)
            {
              
                    GrimeList[i].SetActive(false);
            }
        }
        public void EnableRandomGrime()
        {
            var rnd = Random.Range(0, GrimeList.Count);

            for (int i = 0; i < GrimeList.Count; i++)
            {
                if (i == rnd)
                {
                    GrimeList[i].SetActive(true);
                    SetRandomRotation(GrimeList[i]);
                }
                else
                    GrimeList[i].SetActive(false);
            }
        }

        private void SetRandomRotation(GameObject go)
        {
            go.transform.DOLocalRotateQuaternion(Quaternion.Euler(-90,Random.Range(-90,90),0), 0f);
        }
    
    
    }
}
