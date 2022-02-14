using UnityEngine;

namespace Assets
{
    public class FootSteps : MonoBehaviour
    {
        private AudioSource _audioSource;

        [SerializeField] private AudioClip[] _clips;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }


        private void Step()
        {
            AudioClip clip = GetRandomClip();
            _audioSource.PlayOneShot(clip);
        }

        private AudioClip GetRandomClip()
        {
            return _clips[Random.Range(0, _clips.Length)];
        }
    }
}

