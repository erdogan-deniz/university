#include "colors.inc"  // Подключение библиотеки цветов
#include "functions.inc"  // Подключение библиотеки стандартных функций
#include "stones.inc"  // Подключение библиотеки текстур камня

//__________________________________________________________________________________________________Основной код___________________________________________________________________________________________________________//

// Составляющие для функции - игольчатая планета (рисуется секунд примерно 15 секунд)
#declare Fr = function
{
    0.2 + 0.4 * cos(13 * u) + 0.4 * sin(10 * v)
};
#declare Fx = function
{
    Fr(u, v, 0) * cos(u) * sin(v)
};
#declare Fy = function
{
    Fr(u, v, 0) * cos(v)
};
#declare Fz = function
{
    Fr(u, v, 0) * sin(u) * sin(v)
};

#declare maxG = 4;
#declare startU = 0;
#declare startV = 0;
#declare endU = 2 * pi;
#declare endV = pi;

#declare  Heart = function  // Определение функции - сердца
{
    (-(pow((2 * pow(z, 2) + pow(x, 2) + pow(y, 2) - 1), 3) - (0.1 * pow(z, 2) + pow(x, 2)) * pow(y, 3)) )
}

#declare  Flower = function  // Определение функции - цветок
{
   (( pow(pow(z, 2) + pow(x, 2) + pow(y, 2) - 10, 3) - (2 * pow(z * x,2)) * pow(y, 5)))
}

#declare  Sphere = function  // Определение функции - сфера  
{
   (x * x + y * y + z * z - 10)
}

#declare Wawe = function  // Определение функции - волна
{
    -z + 5+ 50 * sin(sqrt(pow(x+2, 2) + pow(y, 2)))
}

#declare  S = function  // Определение функции - сфера маленькая 
{
   (x * x + y * y + z * z - 1)
}

#declare fn_A = function  // Составляющие части № 2
{
    sqrt(y * y + z * z) - 0.8
}
#declare fn_B = function
{
    abs(x) + abs(y) - 1
}
#declare Blob_threshold = 0.125;

#declare IsoFinish = finish 
{
    ambient     0
    diffuse     1
    specular    1
    roughness 0.02
    brilliance 2
}

#declare Bend = 0.5;

#declare Sharpness = 1.0;

background  // Фон
{
    color Mica // Цвет фона
}

camera  // Настройка камеры
{
    location  <25, 10, 0>  // Расположение камеры
    look_at <0, -5, 0>  // Точка, в которую направлена камера
}

light_source  // Настройка источника цвета № 1
{
    <-100, 100, 0>  // Расположение цвета
    colour Red  // Цвет света
}

light_source  // Настройка источника цвета № 2
{
    <0, 100, 100>  // Расположение цвета
    colour Blue  // Цвет света
}

light_source  // Настройка источника цвета № 3
{
    <100, 100, -100>  // Расположение цвета
    colour Green  // Цвет света
}


isosurface
{
    function
    {
        sqrt(x*x + y*y + z*z) - 0.9 + sin(12*atan2(x, z))*sin(8*atan2(y, sqrt(x*x + z*z)))*0.1
    }
    
    threshold 0
    max_gradient 8.5
    
    contained_by
    {
        sphere
        {
            < 0, 0, 0>, 1
        }
    }

    texture
    {
    
        T_Stone31
        
        finish
        {
            IsoFinish
        }
    }
    
    scale 1 / vlength(1)
    rotate <-36, 24, 0>
    translate <12,-2, 0>
}

isosurface
{
  function
  {
      (1 + Blob_threshold)
      -pow(Blob_threshold, fn_A(x, y, z))
      -pow(Blob_threshold, fn_B(x, y, z))
  }
  
  max_gradient 4
  
  contained_by
  {
    box
    {
        <-4, -2, -3>, 
        <4, 2, 3>
    }
  }

  texture
  {
    pigment
    {
        color rgb <1,0 .3, 0.4>
    }
    
    finish
    {
        phong 1
    }
   }
  
  scale 0.5
  rotate<0, 20, 0>
  rotate<-45, 0, 0>
  translate <4, 7, 0.2>
}



isosurface
{
    function
    { 
        f_torus(y - pow(abs(x), Sharpness) * Bend, z, x, 0.8, 0.1)
    }
    
    max_gradient 1.5
    pigment
    {
        Pink
    }
    
    finish
    {
        phong 1.5 
        phong_size 50
    }
           
    rotate <50, 75, 0>           
    translate <6,5, -4>
}

isosurface
{
    function
    {
        f_sphere(y - pow(abs(x), Sharpness) * Bend, z * 2, x, 0.6)
    }
    
    max_gradient 2.0
    pigment
    {
        rgb x
    }
    
    finish
    {
        phong 1.5 
        phong_size 50
    }
       
    rotate <0, 75, 0>
    translate <6,5, -4>
} 

isosurface  // Планета № 1 (изповерхность простая сфера)
{
    function  // Вызов функции для построение изоповерхности
    {
        Sphere(x / 0.85, y/0.85, z /0.85)  // Использование заданной функции сферы
    }   
    
    threshold   0.0  // Объёмность
    accuracy    0.001  // Детализация сферы
    
    contained_by  // Ограничительная область
    {
        box  // Квадрат ограничительной области
        {
            -5, 5  // Размеры квадарата
        }
    }
    
    open  // Отключение прорисовки границы   
    max_gradient    20  // Корректность изображения

    texture  // Текстура
    { 
        T_Stone6  // Текстура дерева из библиотеки
        scale 10  // Масштабирование текстуры
    }
}

torus  // Кольцо планеты № 1
{
    5, 0.5  // Радиусы кольца

    pigment  // Текстурирование и раскраска кольца
    {
        rgbf <0.5, 0.5, 0.2, 0.94>  // Прозрачность кольца и цвет
    }
    
    rotate <-15, -10, 0>  // Наклон кольца 
}
 
isosurface  // Планета № 2 с отломленными частями (простая сферическая изоповерхность с операций сложения)
{
    function  // Функция сложения двух фигур
    {
        Sphere(x, y, z) + f_noise3d(x, y, z) * 17
    }
     
    max_gradient 7  // Корректность изображения
    
    contained_by  // Ограничительная область
    {
        sphere  // Форма ограничительной области (сфера)
        {
            0, 1  // Радиусы сферы
        }
    }
    
    finish  // Визуальные свойства объекта
    {
        reflection  // Отражение
        {
            metallic 0  // Настолько отражение имеет цвет объекта
        }

        phong 0.7  // Степень блика
        phong_size 4  // Размер блика
    }
    
    texture  // Текстура
    { 
        T_Stone18  // Текстура дерева из библиотеки
        scale 6  // Масштабирование текстуры
    }
    
    translate<8, -2, 7>  // Перемещение объекта
}

isosurface  // Планета № 3 шершавая (простая сферическая изоповерхность с операций сложения)
{
    function  // Функция сложения двух фигур
    {
        S(x, y, z) + f_noise3d(x * 10, y * 10, z * 10) * 0.3  // Шершавость
    }
    
    max_gradient 7  // Корректность изображения
    
    contained_by  // Ограничительная область
    {
        sphere  // Форма ограничительной области (сфера)
        {
            0, 1.1  // Радиусы сферы
        }
    }
    
    texture  // Текстура
    { 
        T_Stone27  // Текстура дерева из библиотеки
        scale 5  // Масштабирование текстуры
    }
    
    translate <8, 1, -7>  // Перемещение объекта
}

isosurface  // Слившаеся астероиды 
{
    function
    {
        min(S(x, y + 0.4, z + 0.25), S(x,y - 0.4, z - 0.25))
    }
    
    max_gradient 2
    contained_by
    {
        sphere
        {
            0, 1
        }
    }
    
    texture  // Текстура
    { 
        T_Stone21  // Текстура камня из библиотеки
        scale 5  // Масштабирование текстуры
    }
    
    translate <8, 7, -7>
}

