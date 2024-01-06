using System;
using Cysharp.Net.Http;
using Shared.Interfaces;
using Grpc.Net.Client;
using MagicOnion.Client;
using UnityEngine;
using UnityEngine.UIElements;

namespace SampleClient
{
    public class SampleUIClient : MonoBehaviour
    {
        [SerializeField] GameObject playerObject;
        private GamingHubClient _hubClient;
        private GrpcChannel _channel;

        private TextField nameField;
        private TextField roomField;
        private bool _isConnected = false;
        
        async void Start()
        {
            var handler = new YetAnotherHttpHandler()
            {
                Http2Only = true,
            };

            var options = new GrpcChannelOptions
            {
                HttpHandler = handler,
            };

            _channel = GrpcChannel.ForAddress("http://127.0.0.1:5000/", options);

            var serviceClient = MagicOnionClient.Create<IMyFirstService>(_channel);
            var result = await serviceClient.SumAsync(100, 200);
            Debug.Log(result);
            
            // UIボタンと機能の連携
            var root = GetComponent<UIDocument>().rootVisualElement;
            var button = root.Q<Button>("Connect");
            button.clicked += async () =>
            {
                Debug.Log("room Button clicked!");
                if (_isConnected) return;
                _hubClient = new GamingHubClient(playerObject);
                _ = await _hubClient.ConnectAsync(_channel, roomField.value, nameField.value);
                _isConnected = true;
                nameField.isReadOnly = true;
                nameField.isReadOnly = true;
            };

            var button2 = root.Q<Button>("Disconnect");
            button2.clicked += async () =>
            {
                Debug.Log("name Button clicked!");
                _isConnected = false;
                nameField.isReadOnly = false;
                nameField.isReadOnly = false;
                await _hubClient.LeaveAsync(playerObject.name);
                await _hubClient.DisposeAsync();
            };

            nameField = root.Q<TextField>("name");
            playerObject.name = nameField.value;
            nameField.RegisterValueChangedCallback(evt =>
            {
                Debug.Log("Entered Name: " + evt.newValue);
                if(!_isConnected) playerObject.name = evt.newValue;
            });

            roomField = root.Q<TextField>("room");
            roomField.RegisterValueChangedCallback(evt =>
            {
                Debug.Log("Entered Name: " + evt.newValue);
                if(_isConnected) roomField.isReadOnly = true;
            });
        }
        
        private async void Update()
        {
            if (_hubClient == null) return;
            if (_isConnected)
            {
                var position = playerObject.transform.position;
                var rotation = playerObject.transform.rotation;
                await _hubClient.MoveAsync(position,rotation);
            }
        }
        
        private async void OnApplicationQuit()
        {
            if (_hubClient == null) return;
            await _hubClient.LeaveAsync(playerObject.name);
            await _hubClient.DisposeAsync();
        }
    }
}