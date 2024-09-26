using UnityEngine;

namespace Script.Cell
{
    [System.Serializable]
    public class BaseCell
    {
        public int Column; //Sutun x degeri
        public int Row; // Satır z degeri

        public void OnDebugRowColumn() => Debug.Log($"Satir :{Row} , Sutun: {Column}");
    }
}
