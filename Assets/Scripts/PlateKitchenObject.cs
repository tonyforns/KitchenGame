using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArg> OnIngredientAdded;
    public class OnIngredientAddedEventArg : EventArgs { public KitchenObjectSO kitchenObjectSO; }

    [SerializeField] List<KitchenObjectSO> validKitchenObjectSO;
    private List<KitchenObjectSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!kitchenObjectsSOList.Contains(kitchenObjectSO) && validKitchenObjectSO.Contains(kitchenObjectSO))
        {
            kitchenObjectsSOList.Add(kitchenObjectSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArg { kitchenObjectSO = kitchenObjectSO });
            return true;
        }
        return false;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectsSOList;
    }
}
