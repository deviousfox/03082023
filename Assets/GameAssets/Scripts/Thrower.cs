using System;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class Thrower: MonoBehaviour
    {
        [SerializeField] private float force= 50;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100))
                {
                    var model = hit.collider.GetComponentInParent<PhysicsModel>();
                    if (model)
                    {
                        model.SetDollState(true);
                        hit.collider.GetComponent<Rigidbody>().AddForce(ray.direction.normalized*force,ForceMode.Impulse);
                    }
                }
            }
        }
    }
}