using System;
using UnityEngine;

namespace Assets.Scripts.Movement.Data
{
    [Serializable]
    public class JumperData
    {
        [field: SerializeField] public LayerMask GroundLayer { get; set; }
    }
}
