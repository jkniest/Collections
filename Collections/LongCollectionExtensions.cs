namespace Collections
{
    public static class LongCollectionExtensions
    {
        #region AVG

        /// <summary>
        /// Return the average value 
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Numeric-methods#avg
        /// 
        /// </summary>
        /// <param name="collection">The numeric collection</param>
        /// <returns>The average value</returns>
        public static long Avg(this Collection<long> collection)
        {
            return collection.Avg(item => item);
        }
        
        /// <summary>
        /// Return the average value.
        /// Alias for 'Avg'
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Numeric-methods#avg
        /// 
        /// </summary>
        /// <param name="collection">The numeric collection</param>
        /// <returns>The average value</returns>
        public static long Average(this Collection<long> collection)
        {
            return collection.Avg();
        }
        
        #endregion

        #region MEDIAN

        /// <summary>
        /// Return the median value 
        /// 
        /// Documentation: https://github.com/jkniest/Collections/wiki/Numeric-methods#median
        /// 
        /// </summary>
        /// <param name="collection">The numeric collection</param>
        /// <returns>The average value</returns>
        public static long Median(this Collection<long> collection)
        {
            return collection.Median(item => item);
        }

        #endregion
    }
}