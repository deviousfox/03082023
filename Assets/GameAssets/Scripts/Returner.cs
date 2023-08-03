using System.Collections;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class Returner : MonoBehaviour
    {
        [SerializeField] private PhysicsModel model;
        [SerializeField] private float waitTime;
        [SerializeField] private float deDollThreshold;
        [SerializeField] private Rigidbody rootBody;

        private Coroutine _returnRoutine;

        public void StartTimer()
        {
            if (_returnRoutine == null)
                _returnRoutine = StartCoroutine(Return());
        }

        private IEnumerator Return()
        {
            yield return new WaitForSeconds(waitTime);
            while (true)
            {
                if (rootBody.velocity.magnitude < deDollThreshold)
                {
                    model.SetDollState(false);
                    _returnRoutine = null;
                    yield break;
                }

                yield return null;
            }
        }
    }
}