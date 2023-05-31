using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObjct
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    [SerializeField] PlateKitchenObject plateKitchenObject;
    [SerializeField] List<KitchenObjectSO_GameObjct> kitchenObjectSOGameObjctsList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (KitchenObjectSO_GameObjct kitchenObjectSO_GameObjct in kitchenObjectSOGameObjctsList)
        {
                kitchenObjectSO_GameObjct.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArg e)
    {
        foreach (KitchenObjectSO_GameObjct kitchenObjectSO_GameObjct in kitchenObjectSOGameObjctsList)
        {
            if(kitchenObjectSO_GameObjct.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectSO_GameObjct.gameObject.SetActive(true);
            }
        }
    }
}
