using System;
using UnityEngine;

namespace Arys.WeaponSkinSystem.Editor
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class MongoIdAttribute : PropertyAttribute
    {
        public const string ERROR_PLACEHOLDER = "Must be a 24-digit hexadecimal string";

        public MongoIdAttribute()
        {
        }
    }
}
