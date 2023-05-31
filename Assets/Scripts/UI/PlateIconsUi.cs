using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUi : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private GameObject iconTemplate;
    [SerializeField] private List<PlateIconSingleUI> plateIconSingleUIList;

    private void Awake()
    {
        iconTemplate.SetActive(false);
        plateIconSingleUIList = new List<PlateIconSingleUI>();
    }
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArg e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < plateKitchenObject.GetKitchenObjectSOList().Count; i++)
        {
            KitchenObjectSO kitchenObjectSOToBeSet = plateKitchenObject.GetKitchenObjectSOList()[i];
            if (plateIconSingleUIList.Count > i)
            {
                plateIconSingleUIList[i].SetKitchenObjectSO(kitchenObjectSOToBeSet);
            }
            else
            {
                GameObject iconGameObject = Instantiate(iconTemplate, transform);
                PlateIconSingleUI plateIconSingleUI = iconGameObject.GetComponent<PlateIconSingleUI>();
                plateIconSingleUI.SetKitchenObjectSO(kitchenObjectSOToBeSet);
                plateIconSingleUIList.Add(plateIconSingleUI);
                iconGameObject.SetActive(true);
            }
        }
       
    }
}
