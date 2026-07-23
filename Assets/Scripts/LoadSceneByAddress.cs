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
#if USING_ADDRESSABLES
        public string key = string.Empty; // address string
        private AsyncOperationHandle<SceneInstance> loadHandle;
        
        [SerializeField] UnityEngine.UI.Slider slider;

        void Start()
        {
            loadHandle = Addressables.LoadSceneAsync(key, priority: 0);
        }

        void OnGUI()
        {
            slider.value = loadHandle.PercentComplete;
        }
#endif // USING_ADDRESSABLES
    }
}
