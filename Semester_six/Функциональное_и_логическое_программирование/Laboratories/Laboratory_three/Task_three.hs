tribonacci :: Int -> Integer
tribonacci = (map count [0..] !!)
  where count 0 = 0
        count 1 = 0
        count 2 = 1
        count n = memoizedTribonacci (n-1) + memoizedTribonacci (n-2) + memoizedTribonacci (n-3)
        memoizedTribonacci = (map count [0..] !!)
main = do
  print $ tribonacci 29
  print $ tribonacci 25