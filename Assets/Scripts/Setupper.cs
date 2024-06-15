using MessagePack;
using MessagePack.Resolvers;
using UnityEngine;

namespace Orca
{
    public class Setupper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void SetupMessagePackResolver()
        {
            StaticCompositeResolver.Instance.Register(new[]{
            MasterMemoryResolver.Instance, // set MasterMemory generated resolver
            GeneratedResolver.Instance,    // set MessagePack generated resolver
            StandardResolver.Instance      // set default MessagePack resolver
        });

            var options = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
            MessagePackSerializer.DefaultOptions = options;
        }

#if UNITY_EDITOR


        [UnityEditor.InitializeOnLoadMethod]
        static void EditorSetup()
        {
            SetupMessagePackResolver();
        }

#endif
    }
}