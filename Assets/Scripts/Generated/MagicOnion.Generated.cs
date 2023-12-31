// <auto-generated />
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

// NOTE: Disable warnings for nullable reference types.
// `#nullable disable` causes compile error on old C# compilers (-7.3)
#pragma warning disable 8603 // Possible null reference return.
#pragma warning disable 8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
#pragma warning disable 8625 // Cannot convert null literal to non-nullable reference type.

namespace MagicOnion
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::MagicOnion;
    using global::MagicOnion.Client;

    public static partial class MagicOnionInitializer
    {
        static bool isRegistered = false;

#if UNITY_2019_4_OR_NEWER
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
#elif NET5_0_OR_GREATER
        [System.Runtime.CompilerServices.ModuleInitializer]
#endif
        public static void Register()
        {
            if (isRegistered) return;
            isRegistered = true;

            global::MagicOnion.Client.MagicOnionClientFactoryProvider.Default =
                (global::MagicOnion.Client.MagicOnionClientFactoryProvider.Default is global::MagicOnion.Client.ImmutableMagicOnionClientFactoryProvider immutableMagicOnionClientFactoryProvider)
                    ? immutableMagicOnionClientFactoryProvider.Add(MagicOnionGeneratedClientFactoryProvider.Instance)
                    : new global::MagicOnion.Client.ImmutableMagicOnionClientFactoryProvider(MagicOnionGeneratedClientFactoryProvider.Instance);

            global::MagicOnion.Client.StreamingHubClientFactoryProvider.Default =
                (global::MagicOnion.Client.StreamingHubClientFactoryProvider.Default is global::MagicOnion.Client.ImmutableStreamingHubClientFactoryProvider immutableStreamingHubClientFactoryProvider)
                    ? immutableStreamingHubClientFactoryProvider.Add(MagicOnionGeneratedClientFactoryProvider.Instance)
                    : new global::MagicOnion.Client.ImmutableStreamingHubClientFactoryProvider(MagicOnionGeneratedClientFactoryProvider.Instance);
        }
    }

    public partial class MagicOnionGeneratedClientFactoryProvider : global::MagicOnion.Client.IMagicOnionClientFactoryProvider, global::MagicOnion.Client.IStreamingHubClientFactoryProvider
    {
        public static MagicOnionGeneratedClientFactoryProvider Instance { get; } = new MagicOnionGeneratedClientFactoryProvider();

        MagicOnionGeneratedClientFactoryProvider() {}

        bool global::MagicOnion.Client.IMagicOnionClientFactoryProvider.TryGetFactory<T>(out global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T> factory)
            => (factory = MagicOnionClientFactoryCache<T>.Factory) != null;

        bool global::MagicOnion.Client.IStreamingHubClientFactoryProvider.TryGetFactory<TStreamingHub, TReceiver>(out global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver> factory)
            => (factory = StreamingHubClientFactoryCache<TStreamingHub, TReceiver>.Factory) != null;

        static class MagicOnionClientFactoryCache<T> where T : global::MagicOnion.IService<T>
        {
            public readonly static global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T> Factory;

            static MagicOnionClientFactoryCache()
            {
                object factory = default(global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T>);

                if (typeof(T) == typeof(global::Shared.Interfaces.IMyFirstService))
                {
                    factory = ((global::MagicOnion.Client.MagicOnionClientFactoryDelegate<global::Shared.Interfaces.IMyFirstService>)((x, y) => new Shared.Interfaces.MyFirstServiceClient(x, y)));
                }
                Factory = (global::MagicOnion.Client.MagicOnionClientFactoryDelegate<T>)factory;
            }
        }
        
        static class StreamingHubClientFactoryCache<TStreamingHub, TReceiver> where TStreamingHub : global::MagicOnion.IStreamingHub<TStreamingHub, TReceiver>
        {
            public readonly static global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver> Factory;

            static StreamingHubClientFactoryCache()
            {
                object factory = default(global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver>);

                if (typeof(TStreamingHub) == typeof(global::Shared.Interfaces.IGamingHub) && typeof(TReceiver) == typeof(global::Shared.Interfaces.IGamingHubReceiver))
                {
                    factory = ((global::MagicOnion.Client.StreamingHubClientFactoryDelegate<global::Shared.Interfaces.IGamingHub, global::Shared.Interfaces.IGamingHubReceiver>)((a, _, b, c, d, e) => new Shared.Interfaces.GamingHubClient(a, b, c, d, e)));
                }

                Factory = (global::MagicOnion.Client.StreamingHubClientFactoryDelegate<TStreamingHub, TReceiver>)factory;
            }
        }
    }

}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

// NOTE: Disable warnings for nullable reference types.
// `#nullable disable` causes compile error on old C# compilers (-7.3)
#pragma warning disable 8603 // Possible null reference return.
#pragma warning disable 8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
#pragma warning disable 8625 // Cannot convert null literal to non-nullable reference type.
namespace MagicOnion.Resolvers
{
    using global::System;
    using global::MessagePack;

    partial class PreserveAttribute : global::System.Attribute {}
    public class MagicOnionResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new MagicOnionResolver();
    
        MagicOnionResolver() {}
    
        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
            => FormatterCache<T>.formatter;
    
        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;
    
            static FormatterCache()
            {
                var f = MagicOnionResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }
    internal static class MagicOnionResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;
    
        static MagicOnionResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(4)
            {
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::System.Int32, global::System.Int32>), 0 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>), 1 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>), 2 },
                {typeof(global::Shared.Interfaces.Player[]), 3 },
            };
        }
        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }
        
            switch (key)
            {
                case 0: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::System.Int32, global::System.Int32>(default(global::System.Int32), default(global::System.Int32));
                case 1: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(default(global::System.String), default(global::System.String), default(global::UnityEngine.Vector3), default(global::UnityEngine.Quaternion));
                case 2: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(default(global::UnityEngine.Vector3), default(global::UnityEngine.Quaternion));
                case 3: return new global::MessagePack.Formatters.ArrayFormatter<global::Shared.Interfaces.Player>();
                default: return null;
            }
        }
    }
    /// <summary>Type hints for Ahead-of-Time compilation.</summary>
    [MagicOnion.Resolvers.Preserve]
    internal static class TypeHints
    {
        [MagicOnion.Resolvers.Preserve]
        internal static void Register()
        {
            _ = MagicOnionResolver.Instance.GetFormatter<global::MagicOnion.DynamicArgumentTuple<global::System.Int32, global::System.Int32>>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::MessagePack.Nil>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::Shared.Interfaces.Player>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::Shared.Interfaces.Player[]>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::System.Int32>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::System.String>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::UnityEngine.Quaternion>();
            _ = MagicOnionResolver.Instance.GetFormatter<global::UnityEngine.Vector3>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

// NOTE: Disable warnings for nullable reference types.
// `#nullable disable` causes compile error on old C# compilers (-7.3)
#pragma warning disable 8603 // Possible null reference return.
#pragma warning disable 8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
#pragma warning disable 8625 // Cannot convert null literal to non-nullable reference type.

namespace Shared.Interfaces
{
    using global::System;
    using global::Grpc.Core;
    using global::MagicOnion;
    using global::MagicOnion.Client;
    using global::MessagePack;
    
    [global::MagicOnion.Ignore]
    public class MyFirstServiceClient : global::MagicOnion.Client.MagicOnionClientBase<global::Shared.Interfaces.IMyFirstService>, global::Shared.Interfaces.IMyFirstService
    {
        class ClientCore
        {
            public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MagicOnion.DynamicArgumentTuple<global::System.Int32, global::System.Int32>, global::System.Int32> SumAsync;
            public ClientCore(global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider)
            {
                this.SumAsync = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_ValueType<global::MagicOnion.DynamicArgumentTuple<global::System.Int32, global::System.Int32>, global::System.Int32>(global::Grpc.Core.MethodType.Unary, "IMyFirstService", "SumAsync", serializerProvider);
            }
        }
        
        readonly ClientCore core;
        
        public MyFirstServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider) : base(options)
        {
            this.core = new ClientCore(serializerProvider);
        }
        
        private MyFirstServiceClient(MagicOnionClientOptions options, ClientCore core) : base(options)
        {
            this.core = core;
        }
        
        protected override global::MagicOnion.Client.MagicOnionClientBase<IMyFirstService> Clone(global::MagicOnion.Client.MagicOnionClientOptions options)
            => new MyFirstServiceClient(options, core);
        
        public global::MagicOnion.UnaryResult<global::System.Int32> SumAsync(global::System.Int32 x, global::System.Int32 y)
            => this.core.SumAsync.InvokeUnary(this, "IMyFirstService/SumAsync", new global::MagicOnion.DynamicArgumentTuple<global::System.Int32, global::System.Int32>(x, y));
    }
}


#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

// NOTE: Disable warnings for nullable reference types.
// `#nullable disable` causes compile error on old C# compilers (-7.3)
#pragma warning disable 8603 // Possible null reference return.
#pragma warning disable 8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
#pragma warning disable 8625 // Cannot convert null literal to non-nullable reference type.

namespace Shared.Interfaces
{
    using global::System;
    using global::Grpc.Core;
    using global::MagicOnion;
    using global::MagicOnion.Client;
    using global::MessagePack;
    
    [global::MagicOnion.Ignore]
    public class GamingHubClient : global::MagicOnion.Client.StreamingHubClientBase<global::Shared.Interfaces.IGamingHub, global::Shared.Interfaces.IGamingHubReceiver>, global::Shared.Interfaces.IGamingHub
    {
        protected override global::Grpc.Core.Method<global::System.Byte[], global::System.Byte[]> DuplexStreamingAsyncMethod { get; }
        
        public GamingHubClient(global::Grpc.Core.CallInvoker callInvoker, global::System.String host, global::Grpc.Core.CallOptions options, global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider, global::MagicOnion.Client.IMagicOnionClientLogger logger)
            : base(callInvoker, host, options, serializerProvider, logger)
        {
            var marshaller = global::MagicOnion.MagicOnionMarshallers.ThroughMarshaller;
            DuplexStreamingAsyncMethod = new global::Grpc.Core.Method<global::System.Byte[], global::System.Byte[]>(global::Grpc.Core.MethodType.DuplexStreaming, "IGamingHub", "Connect", marshaller, marshaller);
        }
        
        public global::System.Threading.Tasks.ValueTask<global::Shared.Interfaces.Player[]> JoinAsync(global::System.String roomName, global::System.String userName, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
            => new global::System.Threading.Tasks.ValueTask<global::Shared.Interfaces.Player[]>(base.WriteMessageWithResponseAsync<global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>, global::Shared.Interfaces.Player[]>(-733403293, new global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(roomName, userName, position, rotation)));
        public global::System.Threading.Tasks.ValueTask LeaveAsync()
            => new global::System.Threading.Tasks.ValueTask(base.WriteMessageWithResponseAsync<global::MessagePack.Nil, global::MessagePack.Nil>(1368362116, global::MessagePack.Nil.Default));
        public global::System.Threading.Tasks.ValueTask MoveAsync(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
            => new global::System.Threading.Tasks.ValueTask(base.WriteMessageWithResponseAsync<global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>, global::MessagePack.Nil>(-99261176, new global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(position, rotation)));
        
        public global::Shared.Interfaces.IGamingHub FireAndForget()
            => new FireAndForgetClient(this);
        
        [global::MagicOnion.Ignore]
        class FireAndForgetClient : global::Shared.Interfaces.IGamingHub
        {
            readonly GamingHubClient parent;
        
            public FireAndForgetClient(GamingHubClient parent)
                => this.parent = parent;
        
            public global::Shared.Interfaces.IGamingHub FireAndForget() => this;
            public global::System.Threading.Tasks.Task DisposeAsync() => throw new global::System.NotSupportedException();
            public global::System.Threading.Tasks.Task WaitForDisconnect() => throw new global::System.NotSupportedException();
        
            public global::System.Threading.Tasks.ValueTask<global::Shared.Interfaces.Player[]> JoinAsync(global::System.String roomName, global::System.String userName, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
                => new global::System.Threading.Tasks.ValueTask<global::Shared.Interfaces.Player[]>(parent.WriteMessageFireAndForgetAsync<global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>, global::Shared.Interfaces.Player[]>(-733403293, new global::MagicOnion.DynamicArgumentTuple<global::System.String, global::System.String, global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(roomName, userName, position, rotation)));
            public global::System.Threading.Tasks.ValueTask LeaveAsync()
                => new global::System.Threading.Tasks.ValueTask(parent.WriteMessageFireAndForgetAsync<global::MessagePack.Nil, global::MessagePack.Nil>(1368362116, global::MessagePack.Nil.Default));
            public global::System.Threading.Tasks.ValueTask MoveAsync(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
                => new global::System.Threading.Tasks.ValueTask(parent.WriteMessageFireAndForgetAsync<global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>, global::MessagePack.Nil>(-99261176, new global::MagicOnion.DynamicArgumentTuple<global::UnityEngine.Vector3, global::UnityEngine.Quaternion>(position, rotation)));
            
        }
        
        protected override void OnBroadcastEvent(global::System.Int32 methodId, global::System.ArraySegment<global::System.Byte> data)
        {
            switch (methodId)
            {
                case -1297457280: // Void OnJoin(global::Shared.Interfaces.Player player)
                    {
                        var value = base.Deserialize<global::Shared.Interfaces.Player>(data);
                        receiver.OnJoin(value);
                    }
                    break;
                case 532410095: // Void OnLeave(global::Shared.Interfaces.Player player)
                    {
                        var value = base.Deserialize<global::Shared.Interfaces.Player>(data);
                        receiver.OnLeave(value);
                    }
                    break;
                case 1429874301: // Void OnMove(global::Shared.Interfaces.Player player)
                    {
                        var value = base.Deserialize<global::Shared.Interfaces.Player>(data);
                        receiver.OnMove(value);
                    }
                    break;
            }
        }
        
        protected override void OnResponseEvent(global::System.Int32 methodId, global::System.Object taskCompletionSource, global::System.ArraySegment<global::System.Byte> data)
        {
            switch (methodId)
            {
                case -733403293: // ValueTask<Player[]> JoinAsync(global::System.String roomName, global::System.String userName, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
                    base.SetResultForResponse<global::Shared.Interfaces.Player[]>(taskCompletionSource, data);
                    break;
                case 1368362116: // ValueTask LeaveAsync()
                    base.SetResultForResponse<global::MessagePack.Nil>(taskCompletionSource, data);
                    break;
                case -99261176: // ValueTask MoveAsync(global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation)
                    base.SetResultForResponse<global::MessagePack.Nil>(taskCompletionSource, data);
                    break;
            }
        }
        
    }
}

