using UnityEngine;

namespace GameAssets.Scripts
{
    public class PhysicsModelTester : MonoBehaviour
    {
        [SerializeField] private PhysicsModel physicsModel;

        [ContextMenu("MakeDoll")]
        public void MakeDoll()
        {
            physicsModel.SetDollState(true);
        }

        [ContextMenu("MakeAnim")]
        public void MakeAnim()
        {
            physicsModel.SetDollState(false);
        }
    }
}