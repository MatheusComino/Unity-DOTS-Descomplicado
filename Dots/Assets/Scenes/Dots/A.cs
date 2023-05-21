using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class A : MonoBehaviour
{
}

public class SimpleBaker : Baker<A> {
    public override void Bake(A authoring) {

        var entity = GetEntity(TransformUsageFlags.Dynamic);
        //AddComponent(entity, new LocalTransform { Position = 123, Rotation = Quaternion.identity, Scale = 1});
    }
}


