Code: 
import System.IO (Handle, IOMode (..), hClose, hGetLine, hIsEOF, openFile)
import Text.Read (readMaybe)
import Data.Time.Clock (getCurrentTime, diffUTCTime)

data Stat = Stat { sum :: Int, min :: Int, max :: Int }

initialStat :: Stat
initialStat = Stat { Main.sum = 0, Main.min = maxBound, Main.max = minBound }

processData :: [Int] -> Stat
processData = foldl updateStat initialStat
  where
    updateStat :: Stat -> Int -> Stat
    updateStat (Stat { Main.sum = s, Main.min = mn, Main.max = mx }) x =
      let s' = s + x
          mn' = Prelude.min mn x
          mx' = Prelude.max mx x
      in Stat { Main.sum = s', Main.min = mn', Main.max = mx' }

parseInput :: Handle -> IO [Int]
parseInput h = do
  eof <- hIsEOF h
  if eof
    then return []
    else do
      line <- hGetLine h
      case readMaybe line of
        Just x -> (x :) <$> parseInput h
        Nothing -> parseInput h

main :: IO ()
main = do
  start <- getCurrentTime
  h <- openFile "statistic.txt" ReadMode
  input <- parseInput h
  let res = processData input
  putStrLn $ "Sum: " ++ show (Main.sum res) ++ ", Min: " ++ show (Main.min res) ++ ", Max: " ++ show (Main.max res)
  hClose h
  end <- getCurrentTime
  let timeDiff = diffUTCTime end start
  putStrLn $ "Execution time: " ++ show timeDiff
