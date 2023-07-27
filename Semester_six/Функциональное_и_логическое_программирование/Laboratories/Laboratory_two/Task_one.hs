import Control.Exception (assert)
divide :: Double -> Double -> Double
divide x y = assert (y /= 0) (x / y)
main = do
  let x = 666
  let y = 0
  let result = divide x y
  print result