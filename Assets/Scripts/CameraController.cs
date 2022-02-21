using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private Animator _cameraAnimator;
        private static bool _cutsceneTriggered;

        private const int CutsceneCd = 5;
        public const int CutsceneDuration = 2;
        private bool _isCutsceneOnCooldown;

        public static bool CutsceneTriggered => _cutsceneTriggered;

        private void OnEnable() 
        {
            LeverController.OnLeverLowered += PlayElevationCutscene;
        }

        private void OnDisable()
        {
            LeverController.OnLeverLowered -= PlayElevationCutscene;
        }
        
        void Awake()
        {
            _cutsceneTriggered = false;
            _cameraAnimator = GetComponent<Animator>();
        }

        private void PlayElevationCutscene()
        {
            if (!_isCutsceneOnCooldown)
            {
                _cutsceneTriggered = true;
                _cameraAnimator.SetBool("elevationCutscene", true);
                StartCoroutine(Cutscene(CutsceneDuration, "elevationCutscene"));
                _isCutsceneOnCooldown = true;
            }
            else
            {
                StartCoroutine(CutsceneCooldown(CutsceneCd));
            }
        }

        private IEnumerator Cutscene(int seconds, string cutsceneProperty)
        {
            yield return new WaitForSeconds(seconds);
            _cameraAnimator.SetBool(cutsceneProperty, false);
            _cutsceneTriggered = false;
        }

        private IEnumerator CutsceneCooldown(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            _isCutsceneOnCooldown = false;
        }
    }
}