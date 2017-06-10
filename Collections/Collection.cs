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
        
    }
}