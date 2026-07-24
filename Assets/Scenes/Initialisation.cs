using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace TCGE
{
    public sealed class Initialisation : MonoBehaviour
    {
        public string key;
    
        void Start()
        {
            _ = Addressables.LoadSceneAsync(key, priority: 1);
        }
    }
}
