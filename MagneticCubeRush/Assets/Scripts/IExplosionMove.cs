using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosionMove
{
    void AddObjectForce(float force, Vector3 position, float explosionRadius);
}
