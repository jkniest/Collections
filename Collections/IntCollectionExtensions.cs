namespace Collections
{
    public static class IntCollectionExtensions
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
        public static int Avg(this Collection<int> collection)
        {
            var avg = collection.Reduce((value, item) => value + item, 0);

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
        public static int Avgerage(this Collection<int> collection)
        {
            return collection.Avg();
        }
        
        #endregion
    }
}