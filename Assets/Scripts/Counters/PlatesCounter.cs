using UnityEngine;
using System;
using Unity.Netcode;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlatesSpawned;
    public event EventHandler OnPlateRemoved;
    
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;

    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;
    
    private void Update()
    {
        if (!IsServer)
            return;
        spawnPlateTimer += Time.deltaTime;

        if (spawnPlateTimer >= spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if (KitchenGameManager.Instance.IsGamePlaying() && platesSpawnedAmount < platesSpawnedAmountMax)
            {
                SpawnPlateServerRpc();
            }
        }
    }

    [Rpc(SendTo.Server)]
    private void SpawnPlateServerRpc()
    {
        SpawnPlateClientRpc();
    }

    [Rpc(SendTo.Everyone)]
    private void SpawnPlateClientRpc()
    {
        platesSpawnedAmount++;
        OnPlatesSpawned?.Invoke(this, EventArgs.Empty);
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Player is empty handed
            if (platesSpawnedAmount > 0)
            {
                // Theres at least one plate
                
                
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                
                InteractLogicServerRpc();
            }
        }
    }
    
    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [Rpc(SendTo.Everyone)]
    private void InteractLogicClientRpc()
    {
        platesSpawnedAmount--;
        
        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }

}
