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

        async void Awake()
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
        }

        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            var button = root.Q<Button>("Connect"); // ButtonNameはUXMLで指定した名前
            button.clicked += async () =>
            {
                Debug.Log("room Button clicked!");
                // ここにボタンクリック時の処理を追加
                _hubClient = new GamingHubClient(playerObject);
                var _ = await _hubClient.ConnectAsync(_channel, roomField.value, nameField.value);
            };

            var button2 = root.Q<Button>("Disconnect"); // ButtonNameはUXMLで指定した名前
            button2.clicked += async () =>
            {
                Debug.Log("name Button clicked!");
                // ここにボタンクリック時の処理を追加
                await _hubClient.LeaveAsync();
                await _hubClient.DisposeAsync();
            };

            nameField = root.Q<TextField>("name"); // UXMLで設定した名前
            playerObject.name = nameField.value;
            nameField.RegisterValueChangedCallback(evt =>
            {
                Debug.Log("Entered Name: " + evt.newValue);
                // ここで入力されたテキストを使用
                playerObject.name = evt.newValue;
            });

            roomField = root.Q<TextField>("room"); // UXMLで設定した名前
            roomField.RegisterValueChangedCallback(evt =>
            {
                Debug.Log("Entered Name: " + evt.newValue);
                // ここで入力されたテキストを使用
                //roomField.value = evt.newValue;
            });
        }
        
        private async void Update()
        {
            if (_hubClient == null) return;
            var position = playerObject.transform.position;
            var rotation = playerObject.transform.rotation;
            await _hubClient.MoveAsync(position,rotation);
        }

        private async void OnDestroy()
        {
            if (_hubClient == null) return;
            await _hubClient.LeaveAsync();
            await _hubClient.DisposeAsync();
        }
    }
}