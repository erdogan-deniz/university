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

main :: IO ()
main = do
    wordCounts <- countWords "task2_variant1_document.txt"
    mapM_ print (Map.toList wordCounts)
