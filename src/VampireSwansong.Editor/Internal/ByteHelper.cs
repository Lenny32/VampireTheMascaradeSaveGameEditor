﻿using System;
using System.Collections.Generic;

namespace VampireSwansong.Editor.Internal;

static class ByteArrayRocks
{
    static readonly int[] _empty = Array.Empty<int>();

    public static int Find(this byte[] self, byte[] candidate)
    {
        if (IsEmptyLocate(self, candidate))
            return -1;

        for (int i = 0; i < self.Length; i++)
        {
            if (!IsMatch(self, i, candidate))
                continue;

            return i;
        }
        return -1;
    }
    public static int[] Locate(this byte[] self, byte[] candidate)
    {
        if (IsEmptyLocate(self, candidate))
            return _empty;

        var list = new List<int>();

        for (int i = 0; i < self.Length; i++)
        {
            if (!IsMatch(self, i, candidate))
                continue;

            list.Add(i);
        }

        return list.Count == 0 ? _empty : list.ToArray();
    }

    static bool IsMatch(byte[] array, int position, byte[] candidate)
    {
        if (candidate.Length > (array.Length - position))
            return false;

        for (int i = 0; i < candidate.Length; i++)
            if (array[position + i] != candidate[i])
                return false;

        return true;
    }

    static bool IsEmptyLocate(byte[] array, byte[] candidate)
    {
        return array == null
            || candidate == null
            || array.Length == 0
            || candidate.Length == 0
            || candidate.Length > array.Length;
    }
}