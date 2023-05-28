using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
       if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        } else
        {
            if(!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);

            } else
            {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                {
                    if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        player.GetKitchenObject().DestroySelf();
                    } 
                } 
            }
        }
    }

    
}
