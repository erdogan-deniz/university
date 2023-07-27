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