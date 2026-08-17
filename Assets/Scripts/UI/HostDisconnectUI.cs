using System.Net.Sockets;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityEngine.UI;
public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;
        Hide();
    }
    
    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected");
        if (clientId == NetworkManager.ServerClientId && !NetworkManager.Singleton.IsServer)
        {
            // Server is shutting down
            Show();
        }
        
        
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

