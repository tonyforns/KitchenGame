using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] List<KitchenObjectSO> validKitchenObjectSO;
    private List<KitchenObjectSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        Debug.Log(kitchenObjectSO);
        Debug.Log(validKitchenObjectSO.Contains(kitchenObjectSO));
        if (!kitchenObjectsSOList.Contains(kitchenObjectSO) && validKitchenObjectSO.Contains(kitchenObjectSO))
        {
            kitchenObjectsSOList.Add(kitchenObjectSO);
            return true;
        }
        return false;
    }
}
