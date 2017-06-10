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
            var avg = collection.Reduce((value, item) => value + item, 0f);

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
        public static float Average(this Collection<float> collection)
        {
            return collection.Avg();
        }
        
        #endregion
    }
}