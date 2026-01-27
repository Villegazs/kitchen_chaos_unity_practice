using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private bool testing;
    
    private KitchenObject kitchenObject;
    
    public void Interact(Player player)
    {
        //Debug.Log("Interact!");
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        
            //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            //Debug.Log(kitchenObject.SetClearCounter(this));
        }
    }
    
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
