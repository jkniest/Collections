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
            var avg = collection.Reduce((value, item) => value + item, 0L);

            return avg / collection.Count;
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
    }
}