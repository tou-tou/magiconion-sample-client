using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion.Client;
using Shared.Interfaces;
using UnityEngine;

namespace SampleClient
{
    public class GamingHubClient : IGamingHubReceiver
    {
        Dictionary<string, GameObject> _players = new Dictionary<string, GameObject>();

        IGamingHub _client;
        
        private readonly GameObject _ownPlayer;
        
        public GamingHubClient(GameObject player)
        {
            _ownPlayer = player;
        }

        public async ValueTask<GameObject> ConnectAsync(ChannelBase grpcChannel, string roomName, string playerName)
        {
            this._client = await StreamingHubClient.ConnectAsync<IGamingHub, IGamingHubReceiver>(grpcChannel, this);

            var roomPlayers = await _client.JoinAsync(roomName, playerName, Vector3.zero, Quaternion.identity);
            foreach (var player in roomPlayers)
            {
                (this as IGamingHubReceiver).OnJoin(player);
            }

            return _players[playerName];
        }

        // methods send to server.

        public ValueTask LeaveAsync()
        {
            return _client.LeaveAsync();
        }

        public ValueTask MoveAsync(Vector3 position, Quaternion rotation)
        {
            // たまにnullになることがあるので、nullチェックを入れる
            if (_client == null) return new ValueTask();
            return _client.MoveAsync(position, rotation);
        }

        // dispose client-connection before channel.ShutDownAsync is important!
        public Task DisposeAsync()
        {
            return _client.DisposeAsync();
        }

        // You can watch connection state, use this for retry etc.
        public Task WaitForDisconnect()
        {
            return _client.WaitForDisconnect();
        }

        // Receivers of message from server.

        void IGamingHubReceiver.OnJoin(Player player)
        {
            Debug.Log("Join Player:" + player.Name);

            // 自分の場合は自分のオブジェクトを生成しない
            if (_ownPlayer.name == player.Name)
            {
                _players[player.Name] = _ownPlayer;
            }
            else
            {
                var playerObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                playerObject.name = player.Name;
                playerObject.transform.SetPositionAndRotation(player.Position,player.Rotation);
                _players[player.Name] = playerObject;
            }
        }

        void IGamingHubReceiver.OnLeave(Player player)
        {
            Debug.Log("Leave Player:" + player.Name);

            if (_players.TryGetValue(player.Name, out var cube))
            {
                GameObject.Destroy(cube);
            }
        }

        void IGamingHubReceiver.OnMove(Player player)
        {
            Debug.Log("Move Player:" + player.Name);

            if (_players.TryGetValue(player.Name, out var cube))
            {
                if (player.Name == _ownPlayer.name) return;
                cube.transform.SetPositionAndRotation(player.Position, player.Rotation);
            }
        }
    }
}