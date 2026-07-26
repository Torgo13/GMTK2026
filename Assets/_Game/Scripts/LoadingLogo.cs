using UnityEngine;
using UnityEngine.UI;

namespace TCGE
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RawImage))]
    public class LoadingLogo : MonoBehaviour
    {
        [SerializeField] RawImage image;
        
        void Start()
        {
            image = GetComponent<RawImage>();
        }

        void Update()
        {
            float a = Mathf.Sin(2 * Time.time) * 0.5f + 0.5f;
            image.color = new Color(a, a, a, 1);
        }

        void OnDestroy()
        {
            image.color = Color.white;
        }
    }
}
