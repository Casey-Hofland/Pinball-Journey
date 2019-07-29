using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[RequiresEntityConversion]
public class SpringComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public Vector3 direction;
    public float compressForce;
    public float releaseForce;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spring = new Spring
        {
            direction = (float3)direction.normalized,
            compressForce = compressForce,
            releaseForce = releaseForce
        };

        dstManager.AddComponentData(entity, spring);
    }
}

public struct Spring : IComponentData
{
    public float3 direction;
    public float compressForce;
    public float releaseForce;
}
