using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSo;
    }
}
