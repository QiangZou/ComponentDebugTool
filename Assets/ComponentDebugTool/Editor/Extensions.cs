using System;
using System.Collections;
using System.Collections.Generic;

namespace Zq.Tool
{
    public static class Extensions
    {
        public static object SetCount(this Array self, int newCount)
        {
            if (self == null)
            {
                return null;
            }

            if (self.Length == newCount)
            {
                return self;
            }

            Type t = self.GetType().GetElementType();

            Array newArray = Array.CreateInstance(t, newCount);

            Array.Copy(self, 0, newArray, 0, Math.Min(self.Length, newCount));

            //因为Array.CreateInstance API创建的数组如果元素Type为引用类型则为null 
            if (newCount > self.Length)
            {
                for (int i = self.Length; i < newArray.Length; i++)
                {
                    newArray.SetValue(CreateInstanceTool.Create(t), i);
                }
            }

            return newArray;
        }

        public static object SetCounta<T>(this Array self, int newCount, T filler)
        {
            if (self == null)
            {
                return null;
            }

            if (self.Length == newCount)
            {
                return self;
            }

            T[] newArray = new T[newCount];

            for (int i = 0; i < newCount; i++)
            {
                if (self.Length > i)
                {
                    newArray[i] = (T)self.GetValue(i);
                }
                else
                {
                    newArray[i] = filler;
                }
            }

            return newArray;
        }

        public static bool SetCount<T>(this T[] self, int newCount, T filler)
        {
            if (self == null)
            {
                return false;
            }

            if (self.Length == newCount)
            {
                return true;
            }

            T[] newArray = new T[newCount];

            for (int i = 0; i < newCount; i++)
            {
                if (self.Length > i)
                {
                    newArray[i] = self[i];
                }
                else
                {
                    newArray[i] = filler;
                }
            }

            self = newArray;

            return true;
        }

        public static bool SetCount<T>(this IList self, int newCount, T filler)
        {
            if (self == null)
            {
                return false;
            }

            if (newCount > self.Count)
            {
                for (int i = self.Count; i < newCount; i++)
                {
                    self.Add(filler);
                }
                return true;
            }
            else if (newCount < self.Count)
            {
                for (int i = self.Count - 1; i >= newCount; i--)
                {
                    self.RemoveAt(i);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// 设置新大小
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="newCount"></param>
        /// <param name="filler"></param>
        /// <returns></returns>
        public static bool SetCount<T>(this List<T> self, int newCount, T filler)
        {
            if (newCount > self.Count)
            {
                for (int i = self.Count; i < newCount; i++)
                {
                    self.Add(filler);
                }
                return true;
            }
            else if (newCount < self.Count)
            {
                self.RemoveRange(newCount, self.Count - newCount);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除所有指定值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int RemoveAll<T>(this List<T> self, T value)
        {
            return self.RemoveAll(i => i.Equals(value));
        }
    }
}


