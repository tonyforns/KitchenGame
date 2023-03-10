using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabOject;

    [SerializeField] protected KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabOject?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
