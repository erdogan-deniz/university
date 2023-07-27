delay :: a -> () -> a
delay x _ = x

force :: (() -> a) -> a
force f = f ()

myIf :: Bool -> a -> a -> a
myIf cond thenExpr elseExpr =
  if cond
  then force (delay thenExpr)
  else force (delay elseExpr)

main :: IO ()
main = do
  putStrLn $ show $ myIf True 1 (2 :: Int)
  putStrLn $ show $ myIf False (1 `div` 0) (1 :: Int)

Code:
import qualified Data.Text.IO as TIO
import qualified Data.Text as T
import Data.Char (isSpace, toLower)
import qualified Data.Map.Strict as Map

countWords :: FilePath -> IO (Map.Map T.Text Int)
countWords file = do
    text <- TIO.readFile file
    let wordsList = T.words (T.toLower text)
    let wordCounts = foldr countWord Map.empty wordsList
    return wordCounts

countWord :: T.Text -> Map.Map T.Text Int -> Map.Map T.Text Int
countWord word wordCounts =
    Map.insertWith (+) word 1 wordCounts