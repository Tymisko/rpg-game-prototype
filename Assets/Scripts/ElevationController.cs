using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ElevationController : MonoBehaviour
    {
        private static readonly Vector3 StartPos = new Vector3(-15.5f, 2f, -13f);

        private static readonly Vector3 EjectedPos = new Vector3(-14.5f, StartPos.y, StartPos.z);

        private void OnEnable()
        {
            LeverController.OnLeverLowered += SlideOutElevation;
        }

        private void OnDisable() 
        {
            LeverController.OnLeverLowered -= SlideOutElevation;    
        }

        private void SlideOutElevation()
        {
            StartCoroutine(LerpPosition(StartPos, EjectedPos, CameraController.CutsceneDuration));
        }

        private IEnumerator LerpPosition(Vector3 startPos, Vector3 targetPos, float duration)
        {
            float time = 0;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
        }
    }
}