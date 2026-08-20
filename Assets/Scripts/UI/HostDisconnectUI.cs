using System.Net.Sockets;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityEngine.UI;
public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button backToMenuButton;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
            Hide();
        });
        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;
        Hide();
    }
    
    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected");
        Debug.Log($"Client is {NetworkManager.Singleton.LocalClientId}");
        if (clientId == NetworkManager.Singleton.LocalClientId && !NetworkManager.Singleton.IsServer)
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

    private void OnDestroy()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback -= NetworkManager_OnClientDisconnectCallback;
    }
}

