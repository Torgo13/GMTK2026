using UnityEngine;
#if USING_ADDRESSABLES
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#endif // USING_ADDRESSABLES

namespace TCGE
{
    internal sealed class LoadSceneByAddress : MonoBehaviour
    {
        public string key = string.Empty; // address string
        
        [SerializeField] UnityEngine.UI.Slider slider;
        
#if USING_ADDRESSABLES
        private AsyncOperationHandle<SceneInstance> loadHandle;

        void Start()
        {
            loadHandle = Addressables.LoadSceneAsync(key, priority: 1);
        }

        void Update()
        {
            slider.value = loadHandle.PercentComplete;
        }
#endif // USING_ADDRESSABLES
    }
}
