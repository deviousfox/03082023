using System;
using System.Collections;
using GameAssets.Scripts;
using UnityEngine;

public class PhysicsModel : MonoBehaviour
{
    [SerializeField] private float convertTime;
    [SerializeField] private Bone rootBone;
    [SerializeField] private Returner returner;
    [SerializeField] private Bone[] bones;

    private Rigidbody[] _physicsRb;
    private bool _isDoll;

    private void Start()
    {
        _physicsRb = GetComponentsInChildren<Rigidbody>();
        SetDollState(false);
    }

    public void SetDollState(bool enableDoll)
    {
        StopAllCoroutines();
        if (enableDoll)
        {
            foreach (var rb in _physicsRb)
            {
                rb.isKinematic = false;
            }

            returner.StartTimer();
            _isDoll = true;
        }
        else
        {
            
            foreach (var rb in _physicsRb)
            {
                rb.isKinematic = true;
            }
            StartCoroutine(ConvertToAnim());
        }
    }

    private IEnumerator ConvertToAnim()
    {
        float t = 0;
        Vector3 pos = Vector3.zero;
        Debug.DrawRay(rootBone.PhysicsBone.position, Vector3.down * 100, Color.red, 10f);
        if (Physics.Raycast(rootBone.PhysicsBone.position, Vector3.down, out RaycastHit hit))
        {
            pos = hit.point;
            pos.y += 0.3f;
        }

        while (t < convertTime)
        {
            
            t += Time.deltaTime;
            float evaluate = t / convertTime;
            rootBone.LerpZero(evaluate, pos);
            if (bones.Length > 0 && bones != null)
                foreach (var bone in bones)
                {
                    bone.Lerp(evaluate);
                }

            yield return null;
        }
        
        _isDoll = false;
        yield break;
    }

    private void Update()
    {
        if (!_isDoll)
            if (bones.Length > 0 && bones != null)
                foreach (var bone in bones)
                {
                    bone.Lerp(1);
                }
    }
}

[System.Serializable]
public struct Bone
{
    [field: SerializeField] public Transform PhysicsBone { get; private set; }
    [field: SerializeField] public Transform AnimatedBone { get; private set; }


    public void Lerp(float t)
    {
        if (!PhysicsBone || !AnimatedBone)
            return;
        t = Mathf.Clamp01(t);
        PhysicsBone.localPosition = Vector3.Lerp(PhysicsBone.localPosition, AnimatedBone.localPosition, t);
        PhysicsBone.localRotation = Quaternion.Slerp(PhysicsBone.localRotation, AnimatedBone.localRotation, t);
    }

    public void LerpZero(float t, Vector3 pos)
    {
        t = Mathf.Clamp01(t);
        PhysicsBone.localRotation = Quaternion.Slerp(PhysicsBone.localRotation,
            Quaternion.Euler(0, PhysicsBone.localRotation.eulerAngles.y, 0), t);
        PhysicsBone.position = Vector3.Lerp(PhysicsBone.position, pos, t);
    }
}