﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BaseSLAM
{
    /// <summary>
    /// Vector extension functions
    /// </summary>
    public static class VectorEx
    {
        /// <summary>
        /// Size of Vector2 in bytes
        /// </summary>
        public const int Vector2Size = 2 * 4;

        /// <summary>
        /// Size of Vector3 in bytes
        /// </summary>
        public const int Vector3Size = 3 * 4;

        /// <summary>
        /// Calculate point project on line and relative distance on line from line start
        /// Got help from:
        /// http://csharphelper.com/blog/2016/09/find-the-shortest-distance-between-a-point-and-a-line-segment-in-c/
        /// </summary>
        /// <param name="p1">Line start point</param>
        /// <param name="p2">Line end point</param>
        /// <param name="pt">Point</param>
        /// <param name="location">Relative location on line. 0 = start point, 1 = end point.</param>
        /// <param name="distanceSquare">Distance square from line</param>
        public static void FindPositionOnLine(Vector2 p1, Vector2 p2, Vector2 pt, out float location, out float distanceSquare)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            location = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            dx = pt.X - (p1.X + location * dx);
            dy = pt.Y - (p1.Y + location * dy);

            distanceSquare = (dx * dx + dy * dy);
        }

        /// <summary>
        /// Place point somewhere on the line
        /// </summary>
        /// <param name="p1">Line start point</param>
        /// <param name="p2">Line end point</param>
        /// <param name="fraction">Fraction (0 to 1)</param>
        /// <returns>Point on lane</returns>
        public static Vector2 PointToLine(Vector2 p1, Vector2 p2, float fraction)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            return p1 + new Vector2(dx * fraction, dy * fraction);
        }

        /// <summary>
        /// Get bytes of Vector2
        /// </summary>
        /// <param name="vector">Vector2</param>
        /// <returns>Bytes</returns>
        public static byte[] GetBytes(this Vector2 vector)
        {
            byte[] data = new byte[Vector2Size];

            Array.Copy(BitConverter.GetBytes(vector.X), 0, data, 0, 4);
            Array.Copy(BitConverter.GetBytes(vector.Y), 0, data, 4, 4);

            return data;
        }

        /// <summary>
        /// Get Vector2 from bytes
        /// </summary>
        /// <param name="data">Data bytes</param>
        /// <param name="index">Start index</param>
        /// <returns>Vector3</returns>
        public static Vector2 ToVector2(byte[] data, int index)
        {
            return new Vector2(
                BitConverter.ToSingle(data, index),
                BitConverter.ToSingle(data, index + 4));
        }

        /// <summary>
        /// Get bytes of Vector3
        /// </summary>
        /// <param name="vector">Vector3</param>
        /// <returns>Bytes</returns>
        public static byte[] GetBytes(this Vector3 vector)
        {
            byte[] data = new byte[Vector3Size];

            Array.Copy(BitConverter.GetBytes(vector.X), 0, data, 0, 4);
            Array.Copy(BitConverter.GetBytes(vector.Y), 0, data, 4, 4);
            Array.Copy(BitConverter.GetBytes(vector.Z), 0, data, 8, 4);

            return data;
        }

        /// <summary>
        /// Get Vector3 from bytes
        /// </summary>
        /// <param name="data">Data bytes</param>
        /// <param name="index">Start index</param>
        /// <returns>Vector3</returns>
        public static Vector3 ToVector3(byte[] data, int index)
        {
            return new Vector3(
                BitConverter.ToSingle(data, index),
                BitConverter.ToSingle(data, index + 4),
                BitConverter.ToSingle(data, index + 8));
        }
    }
}
