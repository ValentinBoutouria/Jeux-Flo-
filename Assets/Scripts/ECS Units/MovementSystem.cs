using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using Unity.VisualScripting.FullSerializer;
using UnityEngine.Rendering.VirtualTexturing;
using Random = Unity.Mathematics.Random;
using Unity.Assertions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

[UpdateBefore(typeof(SpawnSystem))]
public partial struct MovementSystem : ISystem
{
    Random rand;
    public void OnCreate(ref SystemState state)
    {
        //state.RequireForUpdate<Unit>();
        rand = new Random(1);
    }

    public void OnUpdate(ref SystemState state)
    {
        rand = new Random(rand.NextUInt());

        var UnitsMovementQuery = SystemAPI.QueryBuilder().WithAll<Unit, LocalTransform>().Build();

        var job = new MovementJob
        {
            TransformTypeHandle = SystemAPI.GetComponentTypeHandle<LocalTransform>(),
            unitHandle = SystemAPI.GetComponentTypeHandle<Unit>(false),
            DeltaTime = SystemAPI.Time.DeltaTime,
            rand = rand
        };

        state.Dependency = job.Schedule(UnitsMovementQuery, state.Dependency);

        state.Dependency.Complete();
    }

    //[BurstCompile]
    struct MovementJob : IJobChunk
    {
        public ComponentTypeHandle<LocalTransform> TransformTypeHandle;
        public ComponentTypeHandle<Unit> unitHandle;
        public float DeltaTime;
        public Random rand;

        public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask,
            in v128 chunkEnabledMask)
        {
            // The useEnableMask parameter is true when one or more entities in
            // the chunk have components of the query that are disabled.
            // If none of the query component types implement IEnableableComponent,
            // we can assume that useEnabledMask will always be false.
            // However, it's good practice to add this guard check just in case
            // someone later changes the query or component types.
            Assert.IsFalse(useEnabledMask);

            var transforms = chunk.GetNativeArray(ref TransformTypeHandle);
            var units = chunk.GetNativeArray(ref unitHandle);
            for (int i = 0, chunkEntityCount = chunk.Count; i < chunkEntityCount; i++)
            {
                if (math.distance(transforms[i].Position, units[i].TargetPosition) > 0.5f)
                {
                    var direction = math.normalize(units[i].TargetPosition - transforms[i].Position);
                    transforms[i] = transforms[i].Translate(direction * units[i].Speed * DeltaTime);

                }
                else
                {
                    var unit = units[i]; // Copier l'élément du tableau dans une variable locale
                    unit.TargetPosition.x += rand.NextFloat(-5, 5); // Modifier la variable locale
                    unit.TargetPosition.z += rand.NextFloat(-5, 5); // Modifier la variable locale
                    units[i] = unit; // Réaffecter la variable locale à l'élément du tableau

                }
            }
        }
    }
}

