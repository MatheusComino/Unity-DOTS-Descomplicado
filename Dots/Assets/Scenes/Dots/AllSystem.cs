using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using System;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

//public struct SampleComponent : IComponentData { public float Value; }

partial struct AllSystem : ISystem {


    [BurstCompile]
    public void OnCreate(ref SystemState state) {

        var newEntityArchetype = state.EntityManager.CreateArchetype(typeof(LocalTransform));
        var entities = new NativeArray<Entity>(1000000, Allocator.Temp);
        state.EntityManager.CreateEntity(newEntityArchetype, entities);
        entities.Dispose();

    }

    

    [BurstCompile]
    public void OnUpdate(ref SystemState state) {

        new JobsMove { moveY = 5, timeDeltime = Time.deltaTime }.ScheduleParallel();


    }

  
}

[BurstCompile]
public partial struct JobsMove : IJobEntity {

    public float moveY;
    public float timeDeltime;

    [BurstCompile]
    public void Execute(ref LocalTransform transform) {

        transform.Position += math.up() * moveY * timeDeltime;
        //transform.Rotation = math.mul(quaternion.RotateY(math.PI * timeDeltime), transform.Rotation);
        //if (math.distance(transform.Position, new float3(0,0,0)) > 1) ;

        if (transform.Position.y > 5) transform.Position = new float3(transform.Position.x, 0, transform.Position.z);



    }

}




