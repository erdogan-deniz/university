-- Использовать: рекурсии, процедуры высшего порядка, списки;
-- Не использовать: присваивание, циклы, обращение по индексу;
-- Избегайте: возврата логических значений из условных конструкций;
-- Предемонстрировать работу на примерах;
-- settings: :set prompt "Welcome hero->".

-- № 1: сколько раз в списке xs встречается элемент s (count x [xs]):

count :: Eq x => x -> [x] -> Int
count a = length . filter (a==)

-- № 2: заменяет все элементы удовлетворяющие предикату на результат применения к каждому из элементов 
-- процедуры одного аргумента proc (replace pred? proc xs):

_replace :: (x -> Bool) -> (x -> x) -> [x] -> [x]
_replace pred proc xs = map (\x -> if pred x then proc x else x) xs

-- № 3: возвращаем список, из n x элеметов (replicate x n):

_replicate :: [x] -> Int -> [[x]]
_replicate x n = concat (replicate n [x])

-- № 4: возвращаем список, полученный конкатенаций (cycle xs n):

_cycle :: [a] -> Int -> [a]
_cycle xs n = concat (replicate n xs)

-- main - Запуск программы
main :: IO()
main = print $