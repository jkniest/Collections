namespace Collections
{
    public static class FloatCollectionExtensions
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
        public static float Avg(this Collection<float> collection)
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
        public static float Average(this Collection<float> collection)
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
        public static float Median(this Collection<float> collection)
        {
            return collection.Median(item => item);
        }        

        #endregion
    }
}