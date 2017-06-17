﻿using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// This is a better collection for C#. It contains a bunch of useful methods to deal with
    /// the items inside this collection. Please read the offical documentation for more examples:
    /// 
    /// https://github.com/jkniest/Collections/wiki
    /// 
    /// It is highly inspired by Illuminates collection class for PHP and Laravel.
    /// 
    /// https://laravel.com/docs/5.4/collections
    /// https://laravel.com/api/5.4/Illuminate/Database/Eloquent/Collection.html
    /// 
    /// </summary>
    /// <typeparam name="TList"></typeparam>
    public class Collection<TList> : List<TList>
    {
        #region PUBLIC_VARS

        /// <summary>
        /// This callback is used for the reduce method.
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="item">The current item's value</param>
        /// <typeparam name="TReturn">The return type of this callable</typeparam>
        public delegate TReturn ReduceCallback<TReturn>(TReturn current, TList item);

        /// <summary>
        /// This callback accepts the item and needs to return an integer.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate int IntItemCallback(TList item);
        
        /// <summary>
        /// This callback accepts the item and needs to return a float.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate float FloatItemCallback(TList item);
        
        /// <summary>
        /// This callback accepts the item and needs to return a double.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate double DoubleItemCallback(TList item);
        
        /// <summary>
        /// This callback accepts the item and needs to return a long.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate long LongItemCallback(TList item);
        
        #endregion

        #region CONSTRUCTOR
        
        /// <summary>
        /// It's an empty constructor.
        /// </summary>
        public Collection()
        {
            // Empty constructor..
        }

        /// <summary>
        /// It can take any enumerable type (lists, arrays, collections, etc..) and put it right
        /// into this collection.
        /// </summary>
        /// <param name="items">The source</param>
        public Collection(IEnumerable<TList> items)
        {
            AddRange(items);
        }
        
        /// <summary>
        /// It can take multiple parameters of the list type and put it right into this
        /// collection.
        /// </summary>
        /// <param name="items">The source</param>
        public Collection(params TList[] items)
        {
            AddRange(items);
        }

        #endregion
        
        #region REDUCE

        /// <summary>
        /// The reduce method converts a collection into some other type. 
        /// For example it could be used to sum the items (converting the collection to a single integer)
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#reduce
        /// 
        /// </summary>
        /// <param name="callable">The callback that passes each item in this collection</param>
        /// <param name="initial">The initial value</param>
        /// <typeparam name="T">What type should be returned?</typeparam>
        /// <returns>The converted collection</returns>
        public virtual T Reduce<T>(ReduceCallback<T> callable, T initial)
        {
            var result = initial;

            ForEach(item =>
            {
                result = callable(result, item);
            });

            return result;
        }
        
        #endregion
        
        #region ALL

        /// <summary>
        /// Return all items as an array. It is in fact an alias for the 'ToArray' method.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#all
        /// </summary>
        /// <returns></returns>
        public TList[] All()
        {
            return ToArray();
        }
        
        #endregion
        
        #region AVG

        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual int Avg(IntItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0);

            return avg / Count;
        }

        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// Alias for 'Avg'
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public int Average(IntItemCallback callable)
        {
            return Avg(callable);
        }
        
        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual float Avg(FloatItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0f);

            return avg / Count;
        }

        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// Alias for 'Avg'
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public float Average(FloatItemCallback callable)
        {
            return Avg(callable);
        }
        
        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual double Avg(DoubleItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0d);

            return avg / Count;
        }

        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// Alias for 'Avg'
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public double Average(DoubleItemCallback callable)
        {
            return Avg(callable);
        }
        
        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual long Avg(LongItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0L);

            return avg / Count;
        }

        /// <summary>
        /// Return the average value based on the return value of the callable.
        /// Alias for 'Avg'
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public long Average(LongItemCallback callable)
        {
            return Avg(callable);
        }
        
        #endregion
        
        #region MEDIAN
        
        /// <summary>
        /// Return the median value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The median value</returns>
        public virtual int Median(IntItemCallback callable)
        {
            var items = new List<int>();
            foreach (var item in All())
            {
                items.Add(callable(item));
            }
            
            if (Count % 2 == 0)
            {
                return (items[Count / 2 - 1] + items[Count / 2]) / 2;
            }
            
            return items[Count / 2];
        }

        /// <summary>
        /// Return the median value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual float Median(FloatItemCallback callable)
        {
            var items = new List<float>();
            foreach (var item in All())
            {
                items.Add(callable(item));
            }
            
            if (Count % 2 == 0)
            {
                return (items[Count / 2 - 1] + items[Count / 2]) / 2f;
            }
            
            return items[Count / 2];
        }
        
        /// <summary>
        /// Return the median value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual double Median(DoubleItemCallback callable)
        {
            var items = new List<double>();
            foreach (var item in All())
            {
                items.Add(callable(item));
            }
            
            if (Count % 2 == 0)
            {
                return (items[Count / 2 - 1] + items[Count / 2]) / 2d;
            }
            
            return items[Count / 2];
        }
        
        /// <summary>
        /// Return the median value based on the return value of the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>The average value</returns>
        public virtual long Median(LongItemCallback callable)
        {
            var items = new List<long>();
            foreach (var item in All())
            {
                items.Add(callable(item));
            }
            
            if (Count % 2 == 0)
            {
                return (items[Count / 2 - 1] + items[Count / 2]) / 2L;
            }
            
            return items[Count / 2];
        }
        
        #endregion
        
        #region MODE

        /// <summary>
        /// Return the mode value of the collection. If there are multiple mode values then all of them
        /// will be returned within a list.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#mode 
        /// 
        /// </summary>
        /// <returns>A new collection with the mode value(s)</returns>
        public virtual Collection<TList> Mode()
        {
            var items = All();
            var counts = new Dictionary<TList, int>();
            
            foreach( var item in items )
            {
                if (counts.ContainsKey(item))
                {
                    counts[item] = counts[item] + 1;
                }
                else
                {
                    counts[item] = 1;
                }
            }

            var result = new Collection<TList>();
            
            var max = int.MinValue;
            
            foreach (var key in counts.Keys) 
            {
                if (counts[key] < max)
                {
                    continue;
                }
   
                if (counts[key] == max)
                {
                    result.Add(key);
                    continue;
                }

                max = counts[key];
                result.Add(key);
            }
            
            return new Collection<TList>(result);
        }
        
        #endregion
    }
}