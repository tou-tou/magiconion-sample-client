using Cysharp.Net.Http;
using Shared.Interfaces;
using Grpc.Net.Client;
using MagicOnion.Client;
using UnityEngine;

namespace SampleClient
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] GameObject actor;
        private GamingHubClient _hubClient;
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
            
            var channel = GrpcChannel.ForAddress("http://127.0.0.1:5000/", options);
            
            var serviceClient = MagicOnionClient.Create<IMyFirstService>(channel);
            _hubClient = new GamingHubClient(actor);
            var _ = await _hubClient.ConnectAsync(channel,"room1" ,this.name);
            var result = await serviceClient.SumAsync(100, 200);
            Debug.Log(result);
        }
        
        private async void Update()
        {
            var position = actor.transform.position;
            var rotation = actor.transform.rotation;
            await _hubClient.MoveAsync(position,rotation);
        }

        private async void OnDestroy()
        {
            await _hubClient.LeaveAsync();
            await _hubClient.DisposeAsync();
        }
    }
}