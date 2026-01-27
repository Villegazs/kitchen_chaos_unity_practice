using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    
    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSo;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        
        this.kitchenObjectParent = kitchenObjectParent;
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("ClearCounter already has a KitchenObject!");
        }
        kitchenObjectParent.SetKitchenObject(this);
        
        
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
