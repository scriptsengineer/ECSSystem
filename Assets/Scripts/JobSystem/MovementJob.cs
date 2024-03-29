using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
using Unity.Entities;

namespace JobSystem
{
    public struct MovementJob : IJobParallelForTransform
    {

        public float moveSpeed;
        public float topBound;
        public float bottomBound;
        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            Vector3 pos = transform.position;
            pos += moveSpeed * deltaTime * (transform.rotation * new Vector3(0f, 0f, 1f));

            if (pos.z < bottomBound)
            {
                pos.z = topBound;
            }

            transform.position = pos;
        }
    }
}
