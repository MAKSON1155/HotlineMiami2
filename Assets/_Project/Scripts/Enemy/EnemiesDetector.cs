using System;
using UnityEngine;

public class EnemiesDetector : MonoBehaviour
{
    public event Action<Vector2> HasDetected;
}
