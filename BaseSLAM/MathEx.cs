﻿using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace BaseSLAM
{
    /// <summary>
    /// Mathematical extensions
    /// </summary>
    public static class MathEx
    {
        public const float PI = 3.141592f;

        /// <summary>
        /// Limit floating point number with minimum and maximum value
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Limited value</returns>
        public static float Limit(float x, float min, float max)
        {
            return MathF.Max(min, MathF.Min(max, x));
        }

        /// <summary>
        /// Limit integer number with minimum and maximum value
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Limited value</returns>
        public static int Limit(int x, int min, int max)
        {
            return Math.Max(min, Math.Min(max, x));
        }

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="deg">Degrees</param>
        /// <returns>Radians</returns>
        public static float DegToRad(float deg)
        {
            return (deg * PI) / 180.0f;
        }

        /// <summary>
        /// Convert radians to degrees
        /// </summary>
        /// <param name="rad">Radians</param>
        /// <returns>Degrees</returns>
        public static float RadToDeg(float rad)
        {
            return (rad * 180.0f) / PI;
        }

        /// <summary>
        /// Signed difference between two angles in degrees
        /// From comments here:
        /// http://blog.lexique-du-net.com/index.php?post/Calculate-the-real-difference-between-two-angles-keeping-the-sign
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float DegDiff(float a, float b)
        {
            float d = ((a - b) + 180.0f) / 360.0f;
            return ((d - MathF.Floor(d)) * 360.0f) - 180.0f;
        }

        /// <summary>
        /// Signed difference between two angles in degrees
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int DegDiff(int a, int b)
        {
            int d = ((a % 360) - (b % 360)) + 540;
            int r = (d / 360) * 360;
            return (d - r) - 180;
        }

        /// <summary>
        /// Signed difference between two angles in radians
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float RadDiff(float a, float b)
        {
            float d = ((a - b) + MathF.PI) / (2 * MathF.PI);
            return ((d - MathF.Floor(d)) * (2 * MathF.PI)) - MathF.PI;
        }
    }
}
