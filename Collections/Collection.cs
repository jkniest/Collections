using System;
using System.Collections.Generic;

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
        /// This callback accepts the collection and needs to return it
        /// </summary>
        /// <param name="collection">A copy of the collection</param>
        public delegate Collection<TList> CollectionCallback(Collection<TList> collection);

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

        /// <summary>
        /// This callback accepts the item and needs to return a boolean.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate bool BoolItemCallback(TList item);

        /// <summary>
        /// This callback accepts the item and does not need to return anything.
        /// </summary>
        /// <param name="item">The current item's value</param>
        public delegate void VoidItemCallback(TList item);

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

            Each(item => { result = callable(result, item); });

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
            Each(item => { items.Add(callable(item)); });

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
            Each(item => { items.Add(callable(item)); });

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
            Each(item => { items.Add(callable(item)); });

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
            Each(item => { items.Add(callable(item)); });

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
            var counts = new Dictionary<TList, int>();

            Each(item =>
            {
                if (counts.ContainsKey(item))
                {
                    counts[item] = counts[item] + 1;
                }
                else
                {
                    counts[item] = 1;
                }
            });

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

        #region DIFF

        /// <summary>
        /// Compare the collection against another list (or array). It will return all values in the
        /// original collection that are not present in the other collection.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#diff
        /// 
        /// </summary>
        /// <param name="other">The other collection</param>
        /// <returns>The diff as a new collection</returns>
        public virtual Collection<TList> Diff(IList<TList> other)
        {
            var diff = new Collection<TList>();

            // Add all items that are in "self" but not in "other"
            Each(item =>
            {
                if (!other.Contains(item))
                {
                    diff.Add(item);
                }
            });

            return diff;
        }

        #endregion

        #region DUMP

        /// <summary>
        /// Dump the whole collection to the console.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#dump
        /// 
        /// </summary>
        /// <returns>Itself</returns>
        public virtual Collection<TList> Dump()
        {
            Console.WriteLine(this);

            return this;
        }

        /// <summary>
        /// Convert the collection to a string.
        /// 
        /// Format: Collection<TYPE> (COUNT) [ItemA, ItemB]
        /// 
        /// </summary>
        /// <returns>The string version of this collection</returns>
        public override string ToString()
        {
            var type = typeof(TList).ToString();

            var items = Reduce((current, item) => current + item + ", ", "");
            items = items.Substring(0, items.Length - 2);

            return string.Format("Collection<{0}> ({1}) [{2}]", type, Count, items);
        }

        #endregion

        #region EACH

        /// <summary>
        /// Iterate through each item call the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#each
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item passes</param>
        /// <returns>Itself</returns>
        public virtual Collection<TList> Each(VoidItemCallback callable)
        {
            foreach (var item in All())
            {
                callable(item);
            }

            return this;
        }

        #endregion

        #region EVERY

        /// <summary>
        /// Test if every item in this collection passes a callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#every
        /// 
        /// </summary>
        /// <param name="callable">The callable that each item must pass</param>
        /// <returns><c>true</c>, if all items passed the callable, otherwise <c>false</c></returns>
        public virtual bool Every(BoolItemCallback callable)
        {
            return Reduce((value, item) => value && callable(item), true);
        }

        #endregion

        #region FILTER

        /// <summary>
        /// Return a new collection with all items that are passing the callable.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#filter
        /// 
        /// </summary>
        /// <param name="callable">The callable which is used as a filter</param>
        /// <returns>A new collection with all passed items</returns>
        public virtual Collection<TList> Filter(BoolItemCallback callable)
        {
            return Reduce((collection, item) =>
            {
                if (callable(item))
                {
                    collection.Add(item);
                }

                return collection;
            }, new Collection<TList>());
        }

        #endregion

        #region WHEN

        /// <summary>
        /// Run the given callable only when the first argument is true. The callable must return an instance
        /// of the collection.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#when 
        /// 
        /// </summary>
        /// <param name="shouldExecute">Should the callable be executed?</param>
        /// <param name="callable">The callable that only runs when the first argument is true</param>
        /// <returns>The collection itself or the return result of the callable</returns>
        public virtual Collection<TList> When(bool shouldExecute, CollectionCallback callable)
        {
            var collection = new Collection<TList>(All());

            if (shouldExecute)
            {
                collection = callable(collection);
            }

            return collection;
        }

        #endregion

        #region FIRST

        /// <summary>
        /// Return the first item of a collection (optional the first item that passes a callable)
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#first 
        /// 
        /// </summary>
        /// <param name="callable">A optional callable to filter the items</param>
        /// <returns>The first item of the (filtered) collection</returns>
        public virtual TList First(BoolItemCallback callable = null)
        {
            return callable != null ? Filter(callable).First() : All()[0];
        }

        #endregion
    }
}
