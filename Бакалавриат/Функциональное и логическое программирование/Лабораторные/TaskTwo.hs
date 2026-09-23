main = do
   src <- readFile "f1.txt"
   writeFile "f2.txt" (operate src)
   putStrLn "Результат записан в файл f2.txt"

operate :: String -> String
operate input = show $ length $ filter (not . null) $ lines input