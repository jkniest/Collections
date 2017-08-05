using System;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// A better collection for C#. The default collections of C# are kinda lame. They don't
    /// provide a bunch of useful methods. This library fixes that.
    /// 
    /// It contains a bunch of useful methods related to the items inside the collection.
    /// 
    /// You can find the offical documentation on github:
    /// https://github.com/jkniest/Collections/wiki
    /// 
    /// It is highly inspired by Illuminates / Laravel collections. (For PHP)
    /// 
    /// https://laravel.com/docs/5.4/collections
    /// https://laravel.com/api/5.4/Illuminate/Database/Eloquent/Collection.html
    /// 
    /// </summary>
    /// <typeparam name="TList">The type of the list</typeparam>
    public class Collection<TList> : List<TList>
    {
        #region PUBLIC_VARS

        /// <summary>
        /// Callable that is used for the 'Reduce' method.
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="item">The current item</param>
        /// <typeparam name="TReturn">The return type of this callable</typeparam>
        public delegate TReturn ReduceCallback<TReturn>(TReturn current, TList item);

        /// <summary>
        /// This callable accepts the current collection.
        /// Also a new collection or a modified version of the original must be returned.
        /// </summary>
        /// <param name="collection">A copy of the current collection</param>
        public delegate Collection<TList> CollectionCallback(Collection<TList> collection);

        /// <summary>
        /// A callable that accepts the current item and needs to return an integer.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate int IntItemCallback(TList item);

        /// <summary>
        /// A callable that accepts the current item and needs to return a float.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate float FloatItemCallback(TList item);

        /// <summary>
        /// A callable that accepts the current item and needs to return a double.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate double DoubleItemCallback(TList item);

        /// <summary>
        /// A callable that accepts the current item and needs to return a long.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate long LongItemCallback(TList item);

        /// <summary>
        /// A callable that accepts the current item and needs to return a boolean.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate bool BoolItemCallback(TList item);

        /// <summary>
        /// A callable that accepts the current item and does not need to return anything.
        /// </summary>
        /// <param name="item">The current item</param>
        public delegate void VoidItemCallback(TList item);

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Empty constructor - Create a collection without initial data
        /// </summary>
        public Collection()
        {
            // Empty constructor..
        }

        /// <summary>
        /// This constructor can take any enumerable type (list, array, ..) to fill the collection with
        /// initial data.
        /// </summary>
        /// <param name="items">The initial items</param>
        public Collection(IEnumerable<TList> items)
        {
            AddRange(items);
        }

        /// <summary>
        /// This constructor can take multiple parameters and move them as initial items into the
        /// collection.
        /// </summary>
        /// <param name="items">The initial items</param>
        public Collection(params TList[] items)
        {
            AddRange(items);
        }

        #endregion

        #region REDUCE

        /// <summary> 
        /// Converts a collection into some other type. 
        /// For example it could be used to sum the items (converting the collection to a single integer)
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#reduce
        /// 
        /// </summary>
        /// <param name="callable">The callback that is used for every single item</param>
        /// <param name="initial">The initial value</param>
        /// <typeparam name="T">Into which type should the collection be converted?</typeparam>
        /// <returns>The converted collection</returns>
        public virtual T Reduce<T>(ReduceCallback<T> callable, T initial)
        {
            var result = initial;

            foreach (var item in All())
            {
                result = callable.Invoke(result, item);
            }

            return result;
        }

        #endregion

        #region ALL

        /// <summary>
        /// Return all items in this collection as a new array. 
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#all
        /// </summary>
        /// <returns>All items as an array</returns>
        public TList[] All()
        {
            return ToArray();
        }

        #endregion

        #region AVG

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public virtual int Avg(IntItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0);

            return avg / Count;
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public int Average(IntItemCallback callable)
        {
            return Avg(callable);
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public virtual float Avg(FloatItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0f);

            return avg / Count;
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public float Average(FloatItemCallback callable)
        {
            return Avg(callable);
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public virtual double Avg(DoubleItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0d);

            return avg / Count;
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public double Average(DoubleItemCallback callable)
        {
            return Avg(callable);
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public virtual long Avg(LongItemCallback callable)
        {
            var avg = Reduce((value, item) => value + callable(item), 0L);

            return avg / Count;
        }

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the average value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#avg
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The average value</returns>
        public long Average(LongItemCallback callable)
        {
            return Avg(callable);
        }

        #endregion

        #region MEDIAN

        /// <summary>
        /// Convert each item into a numeric value (via a callable).
        /// Then return the median value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
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
        /// Convert each item into a numeric value (via a callable).
        /// Then return the median value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The median value</returns>
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
        /// Convert each item into a numeric value (via a callable).
        /// Then return the median value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The median value</returns>
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
        /// Convert each item into a numeric value (via a callable).
        /// Then return the median value of all returned numeric values.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#median
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns>The median value</returns>
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
        /// will be returned within a collection.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#mode 
        /// 
        /// </summary>
        /// <returns>A new collection with the mode value(s)</returns>
        public virtual Collection<TList> Mode()
        {
            var counts = new Dictionary<TList, int>();

            foreach (var item in All())
            {
                counts[item] = counts.ContainsKey(item) ? counts[item] + 1 : 1;
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

        #region DIFF

        /// <summary>
        /// Compare the collection against another enumerable (list, array, collection, ..). It will return 
        /// all values in the original collection that are not present in the other collection.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#diff
        /// 
        /// </summary>
        /// <param name="other">The other collection</param>
        /// <returns>The diff as a new collection</returns>
        public virtual Collection<TList> Diff(IList<TList> other)
        {
            var diff = new Collection<TList>();

            foreach (var item in All())
            {
                if (!other.Contains(item))
                {
                    diff.Add(item);
                }                
            }

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
        /// Format: Collection TYPE (COUNT) [ItemA, ItemB]
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
        /// Run the callable for each item in the collection. It's like a fluent version of "foreach".
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#each
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
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
        /// Run the callable for each item in the collection and check if all items are returning
        /// true. If one does not, the test will fail.
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#every
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
        /// <returns><c>true</c>, if all items passed the callable, otherwise <c>false</c></returns>
        public virtual bool Every(BoolItemCallback callable)
        {
            return Reduce((value, item) => value && callable(item), true);
        }

        #endregion

        #region FILTER

        /// <summary>
        /// Run the callable for each item in this collection. Based on the return values
        /// a new collection will be built (with all items that have returned true)
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#filter
        /// 
        /// </summary>
        /// <param name="callable">The callable that is called for each item</param>
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
        /// <param name="callable">An optional callable to filter the items</param>
        /// <returns>The first item of the (filtered) collection</returns>
        public virtual TList First(BoolItemCallback callable = null)
        {
            return callable != null ? Filter(callable).First() : All()[0];
        }

        #endregion

        #region IMPLODE

        /// <summary>
        /// Glue all items together as a big string (with a specified glue string)
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Methods#implode
        /// 
        /// </summary>
        /// <param name="glue">The glue charcter (default ", ")</param>
        /// <returns>The imploded string</returns>
        public virtual string Implode(string glue = ", ")
        {
            if (Count == 0)
            {
                return "";
            }

            var result = Reduce((current, item) => current + item.ToString() + glue, "");

            return result.Substring(0, result.Length - glue.Length);
        }

        #endregion
    }
}
