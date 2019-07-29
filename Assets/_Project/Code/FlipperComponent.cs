using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequiresEntityConversion]
public class FlipperComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public int id;
    public float strength;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var flipper = new Flipper(id, strength);

        dstManager.AddComponentData(entity, flipper);
    }
}

public struct Flipper : IComponentData
{
    public int id;
    public float3 impulse;

    public Flipper(int id, float strength)
    {
        this.id = id;
        this.impulse = new float3(0, 7.6f / 90, 82.4f / 90) * strength;
    }
}