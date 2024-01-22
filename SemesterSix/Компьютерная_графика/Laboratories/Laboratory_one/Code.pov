#include "colors.inc"    
#include "textures.inc"  
#include "shapes.inc"
#include "glass.inc"
#include "metals.inc"
#include "woods.inc"
#include "glass.inc"       
#include "stones.inc"      
#include "functions.inc"
#include "shapes3.inc"
#include "glass_old.inc"

#macro transparent()
    
    pigment {rgbf <1, 1, 0.5, 0.9>}  // Цвет в RGBA, 4-й компонент - прозрачность
    
    finish
    {
        ambient <.2, 0.2, .2>  // Фоновая составлющ
        diffuse .6 
        phong 0.9 phong_size 10  // Настройки блика            
        reflection{0.1, 0.8 fresnel}  // Min и Max энергии, которое пойдет на отражение в зависимости от угла падения 
        conserve_energy  // Закон сохранен энергии  
    }   
    
    interior
    {
        ior 1.3  // Коэффициент преломления
        caustics 1  // Будет ли фокусировка света              
    }
#end 

#macro hole()

    pigment
    {
        rgbf <1, 1, 0.5, 0.9>  // Цвет в RGBA, 4-й компонент - прозрачность
    }
    
    finish
    {
        ambient <.2,0.2,.2>  // Фоновая составлющая
        diffuse .6
        phong 0.9 phong_size 10  // Настройки блика            
        reflection{ 0.1,  0.8 fresnel}  // Min и Max энергии, которое пойдет на отражение в зависимости от угла падения 
        conserve_energy  // Использовать в паре с прозрачность          
    }
              
    interior
    {
        ior 1.3  // Коэффициент преломления
        caustics 1  // Будет ли фокусировка света    
    }
#end     
              
           
background  // Фон
{
    color Blue
}  

camera  // Камера
{
    angle 80  // Угол обзора
    location <25, 15, -15>  // Наблюдатель
    look_at  <0, 1,  2>  // Куда смотрит
}

light_source  // Свет в лампочке
{
    <15, 15, -14> 
    color White
}          
      
      
// Стол
merge
{    
    object
    { 
        Supertorus( 10.25, 0.25, // Radius_Major, Radius_Minor, 
                    0.1, 0.1, // Major_Control, Minor_Control,
                   0.001, 11.50) // Accuracy, Max_Gradient)
        
      texture {T_Wood34 scale 20 }
        scale <1,0,1> 
        rotate<0,0,0> 
        translate<0,0,0>
     }
        
    prism  // Крышка стола
    {
        -0.5, 0,4
        <10, 10>, <-10, 10>, <-10, -10>, <10, -10>             
        texture {T_Wood34 scale 20 }
    } 

    cylinder  // Ножка стола № 1
    {
        <9.5, 0, 9.5>,     // Центр первой крышки
        <9.5, -5, 9.5>,     // Центр второй крышки
        0.5            // Радиус      
        texture {T_Wood34 scale 20 }
    }           
  
    cylinder  // Ножка стола № 1
    {
        <-9.5, 0, 9.5>,     // Центр первой крышки
        <-9.5, -5, 9.5>,     // Центр второй крышки
        0.5            // Радиус      
        texture {T_Wood34 scale 20 }
    }  

    cylinder  // Ножка стола № 1
    {
        <9.5, 0, -9.5>,     // Центр первой крышки
        <9.5, -5, -9.5>,     // Центр второй крышки
        0.5            // Радиус      
        texture {T_Wood34 scale 20 }
    }

    cylinder  // Ножка стола № 1
    {
        <-9.5, 0, -9.5>,     // Центр первой крышки
        <-9.5, -5, -9.5>,     // Центр второй крышки
        0.5            // Радиус      
        texture {T_Wood34 scale 20 }
    }
}


// Нож   
intersection
{ 
    sphere
    {
        <-0.25, 7.1, -3.5>, 5.5
        texture
        {
            Dark_Wood scale 4
        }
    }         
    
    box {
            <-0.2, 1.6, -3.5>, <-0.25,2.1,-1.3>
            texture 
            {
                Chrome_Metal scale 4
            }
        }               
} 
  
box
{
    <-0.20,1.8,-3.35>,
    <-0.3,2.15,-4.5>
    texture
    {
        Cherry_Wood scale 1
    }
}

// Cыр  
intersection
{ 
    sphere {<0,9.5,0>, 10 texture {Yellow_Pine scale 40 }}       
  
  
    difference {
    cylinder {<0, -1, 0>, <0, 2.2, 0>, 2.6 transparent()}
    union {   
        sphere {<-1.12,1.92,1.48> ,0.29 hole()}
        sphere {<0.67,1.97,1.24> ,0.17 hole()}
        sphere {<-1.88,1.9,-1.61> ,0.27 hole()}
        sphere {<-0.34,2.08,0.87> ,0.22 hole()}
        sphere {<0.07,2.02,0.51> ,0.21 hole()}
        sphere {<0.27,1.93,-0.06> ,0.25 hole()}
        sphere {<0.0,1.98,1.12> ,0.22 hole()}
        sphere {<-1.75,2.09,-0.14> ,0.18 hole()}
        sphere {<1.88,1.94,1.01> ,0.2 hole()}
        sphere {<-0.79,2.05,-2.24> ,0.18 hole()}
        sphere {<-1.68,2.06,1.08> ,0.26 hole()}
        sphere {<-0.05,1.94,0.48> ,0.2 hole()}
        sphere {<2.39,2.01,2.05> ,0.17 hole()}
        sphere {<-1.51,2.07,0.58> ,0.2 hole()}
        sphere {<2.36,2.08,-0.47> ,0.24 hole()}
        sphere {<-1.77,1.97,1.9> ,0.3 hole()}
        sphere {<0.0,1.91,-0.28> ,0.28 hole()}
        sphere {<-1.73,2.05,-1.38> ,0.17 hole()}
        sphere {<-1.13,2.08,2.58> ,0.22 hole()}
        sphere {<-1.59,1.96,0.33> ,0.28 hole()}
        sphere {<-2.48,1.93,-0.46> ,0.22 hole()}
        sphere {<-1.59,1.91,-1.0> ,0.18 hole()}
        sphere {<1.05,2.02,2.51> ,0.25 hole()}
        sphere {<1.46,2.07,-2.2> ,0.23 hole()}
        sphere {<-0.23,2.08,0.39> ,0.26 hole()}
        sphere {<1.54,2.08,1.78> ,0.19 hole()}
        sphere {<1.02,2.04,-2.54> ,0.23 hole()}
        sphere {<-1.96,2.04,1.64> ,0.24 hole()}
        sphere {<1.06,1.99,0.04> ,0.17 hole()}
        sphere {<0.88,2.06,-1.7> ,0.22 hole()}
        sphere {<1.54,2.07,-0.61> ,0.18 hole()}
        sphere {<1.92,1.98,-1.61> ,0.23 hole()}
        sphere {<1.04,1.94,0.18> ,0.19 hole()}
            sphere {<1.07,2.0,2.22> ,0.17 hole()}
            sphere {<-2.24,1.97,-2.15> ,0.17 hole()}
            sphere {<1.53,2.06,0.07> ,0.21 hole()}
            sphere {<-2.58,1.92,2.29> ,0.26 hole()}
            sphere {<1.68,1.91,-1.25> ,0.18 hole()}
            sphere {<2.18,1.95,-1.5> ,0.3 hole()}
            sphere {<1.41,2.01,2.39> ,0.17 hole()}
            sphere {<-0.45,1.95,-0.84> ,0.28 hole()}
            sphere {<-0.11,2.03,-1.77> ,0.28 hole()}
            sphere {<0.06,1.96,-1.32> ,0.18 hole()}
            sphere {<2.47,1.91,-0.72> ,0.15 hole()}
            sphere {<0.86,2.08,2.01> ,0.22 hole()}
            sphere {<0.45,2.04,1.42> ,0.27 hole()}
            sphere {<-2.26,1.9,2.19> ,0.22 hole()}
            sphere {<1.25,1.94,-1.98> ,0.27 hole()}
            sphere {<-0.38,1.92,-0.53> ,0.25 hole()}
            sphere {<1.8,2.01,-2.53> ,0.15 hole()}
            sphere {<-0.07,1.94,1.73> ,0.29 hole()}
            sphere {<-2.12,2.06,1.57> ,0.26 hole()}
            sphere {<1.11,2.06,1.4> ,0.16 hole()}
            sphere {<1.29,1.93,-0.38> ,0.17 hole()}
            sphere {<-2.48,1.92,-2.45> ,0.3 hole()}
            sphere {<0.64,2.06,-0.64> ,0.18 hole()}
            sphere {<-0.83,2.01,-1.54> ,0.15 hole()}
            sphere {<-1.04,1.91,2.15> ,0.18 hole()}
            sphere {<1.88,1.92,1.96> ,0.27 hole()}
            sphere {<2.52,2.08,0.73> ,0.29 hole()}
            sphere {<2.57,1.96,-1.58> ,0.27 hole()}
            sphere {<2.51,2.1,0.45> ,0.27 hole()}
            sphere {<0.3,1.95,1.42> ,0.23 hole()}
            sphere {<-1.57,1.95,2.45> ,0.2 hole()}
            sphere {<1.6,2.01,1.64> ,0.21 hole()}
            sphere {<-2.28,2.0,-0.86> ,0.26 hole()}
            sphere {<-1.87,1.96,0.39> ,0.27 hole()}
            sphere {<-1.48,2.02,-0.07> ,0.24 hole()}
            sphere {<1.06,2.03,0.58> ,0.28 hole()}
            sphere {<2.38,2.06,1.36> ,0.26 hole()}
            sphere {<0.08,1.91,-2.26> ,0.21 hole()}
            sphere {<2.05,2.06,-0.77> ,0.29 hole()}
            sphere {<-2.58,1.97,-2.16> ,0.26 hole()}
            sphere {<0.73,2.1,2.37> ,0.22 hole()}
            sphere {<-0.89,2.0,-0.6> ,0.19 hole()}
            sphere {<-0.45,2.0,-1.88> ,0.18 hole()}
            sphere {<-0.51,2.05,1.69> ,0.29 hole()}
            sphere {<-0.7,2.07,-0.57> ,0.15 hole()}
            sphere {<-2.44,2.08,-2.05> ,0.28 hole()}
            sphere {<0.05,1.91,1.57> ,0.22 hole()}
            box {<0,-1,0>, <6,6,-6> hole()}
            sphere {<0,-0.42,-0.2> ,0.19 hole()}
            sphere {<0,0.06,-2.23> ,0.25 hole()}
            sphere {<0,1.02,-1.09> ,0.2 hole()}
            sphere {<0,1.06,-2.54> ,0.29 hole()}
            sphere {<0,-0.54,-2.49> ,0.2 hole()}
            sphere {<0,1.79,-2.11> ,0.19 hole()}
            sphere {<0,1.27,-2.3> ,0.25 hole()}
            sphere {<0,-0.37,-1.75> ,0.25 hole()}
            sphere {<0,-0.1,-0.99> ,0.16 hole()}
            sphere {<0,1.57,-0.03> ,0.27 hole()}
            sphere {<0,-0.05,-1.5> ,0.16 hole()}
            sphere {<0,0.26,-0.15> ,0.19 hole()}
            sphere {<0,0.83,-2.35> ,0.25 hole()}
            sphere {<0,1.99,-0.81> ,0.28 hole()}
            sphere {<0,1.48,-1.17> ,0.17 hole()}
            sphere {<0.54,0.1,0> ,0.19 hole()}
            sphere {<0.14,1.97,0> ,0.16 hole()}
            sphere {<1.8,0.58,0> ,0.19 hole()}
            sphere {<2.02,-0.96,0> ,0.29 hole()}
            sphere {<1.56,0.87,0> ,0.22 hole()}
            sphere {<1.89,0.79,0> ,0.25 hole()}
            sphere {<0.28,-0.72,0> ,0.26 hole()}
            sphere {<1.73,0.28,0> ,0.23 hole()}
            sphere {<0.14,-0.05,0> ,0.27 hole()}
            sphere {<0.3,1.39,0> ,0.23 hole()}
            sphere {<1.56,2.18,0> ,0.16 hole()}
            sphere {<0.37,-0.74,0> ,0.17 hole()}
            sphere {<1.05,-0.34,0> ,0.18 hole()}
            sphere {<2.31,2.06,0> ,0.28 hole()}
            sphere {<0.89,1.58,0> ,0.27 hole()}
            sphere {<0.59,1.7,0> ,0.17 hole()}                                  
            sphere {<-0.07,1.06,2.6> ,0.25 hole()}
            sphere {<-2.1,0.22,1.54> ,0.2 hole()}
            sphere {<1.73,-0.74,-1.94> ,0.27 hole()}
            sphere {<2.04,2.08,1.61> ,0.18 hole()}
            sphere {<2.58,-0.94,-0.35> ,0.16 hole()}
            sphere {<-1.43,1.35,2.17> ,0.29 hole()}
            sphere {<0.27,2.16,2.59> ,0.17 hole()}
            sphere {<-2.34,-0.09,-1.13> ,0.21 hole()}
            sphere {<-2.07,1.28,1.57> ,0.23 hole()}
            sphere {<-1.06,-0.33,-2.37> ,0.3 hole()}
            sphere {<1.46,0.13,2.15> ,0.17 hole()}
            sphere {<2.52,-0.7,-0.66> ,0.24 hole()}
            sphere {<1.86,1.38,-1.81> ,0.29 hole()}
            sphere {<-2.31,0.33,1.2> ,0.28 hole()}
            sphere {<0.67,1.35,-2.51> ,0.17 hole()}
            sphere {<2.17,1.45,1.44> ,0.16 hole()}
            sphere {<-0.89,1.91,-2.44> ,0.2 hole()}
            sphere {<1.19,0.18,2.31> ,0.27 hole()}
            sphere {<1.65,1.68,-2.01> ,0.29 hole()}
            sphere {<-1.89,-0.78,1.78> ,0.23 hole()}
            sphere {<2.29,0.8,-1.22> ,0.28 hole()}
            sphere {<-2.35,0.8,1.12> ,0.21 hole()}
            sphere {<-2.37,0.83,-1.07> ,0.21 hole()}
            sphere {<2.6,-0.27,0.07> ,0.29 hole()}
            sphere {<-2.54,0.0,0.56> ,0.29 hole()}
            sphere {<1.2,0.66,-2.31> ,0.21 hole()}
            sphere {<-2.51,1.21,0.69> ,0.22 hole()}
            sphere {<-2.0,0.09,1.66> ,0.23 hole()}
            sphere {<-0.27,1.24,-2.59> ,0.24 hole()}
            sphere {<-2.59,-0.8,0.26> ,0.16 hole()}
            sphere {<2.41,1.87,-0.98> ,0.29 hole()}
            sphere {<1.98,-0.63,1.69> ,0.16 hole()}
            sphere {<-2.54,1.65,0.55> ,0.18 hole()}
            sphere {<2.35,1.04,-1.11> ,0.15 hole()}
            sphere {<2.31,-0.02,1.2> ,0.21 hole()}
            sphere {<2.39,-0.19,1.02> ,0.2 hole()}
            sphere {<-1.14,0.81,-2.33> ,0.25 hole()}
            sphere {<0.51,-0.96,-2.55> ,0.24 hole()}
            sphere {<0.23,0.6,2.59> ,0.28 hole()}
            sphere {<2.18,-0.51,1.41> ,0.18 hole()}                                   
            sphere {<-1.82,1.4,1.86> ,0.23 hole()}
            sphere {<-2.4,0.65,1.01> ,0.29 hole()}
            sphere {<-0.98,-0.76,2.41> ,0.28 hole()}
            sphere {<0.93,1.31,-2.43> ,0.23 hole()}
            sphere {<0.14,1.33,-2.6> ,0.19 hole()}
            sphere {<-2.58,-0.42,-0.33> ,0.27 hole()}
            sphere {<-1.07,0.38,-2.37> ,0.24 hole()}
            sphere {<2.5,1.47,0.73> ,0.27 hole()}
            sphere {<-1.66,-0.99,-2.0> ,0.23 hole()}
            sphere {<0.27,-0.07,-2.59> ,0.21 hole()}
            sphere {<0.54,0.5,-2.54> ,0.22 hole()}
            sphere {<0.29,1.46,-2.58> ,0.17 hole()}
            sphere {<2.46,0.16,-0.83> ,0.2 hole()}
            sphere {<-2.58,1.04,-0.31> ,0.24 hole()}
            sphere {<0.83,0.23,2.46> ,0.18 hole()}
            sphere {<-1.68,1.17,1.98> ,0.19 hole()}
            sphere {<-2.09,1.32,1.54> ,0.23 hole()}
            sphere {<-0.11,1.07,2.6> ,0.28 hole()}
            sphere {<0.08,1.75,2.6> ,0.18 hole()}
            sphere {<0.8,-0.49,2.47> ,0.19 hole()}
            sphere {<1.13,0.16,2.34> ,0.27 hole()}
            sphere {<0.64,-0.37,-2.52> ,0.24 hole()}
            sphere {<-1.95,-0.13,-1.72> ,0.25 hole()}
            sphere {<-2.46,0.07,-0.84> ,0.23 hole()}
            sphere {<-1.83,-0.94,-1.85> ,0.26 hole()}
            sphere {<-2.53,-0.5,0.62> ,0.16 hole()}
            sphere {<2.44,1.36,-0.9> ,0.23 hole()}
            sphere {<-2.55,-0.34,-0.53> ,0.18 hole()}
            sphere {<0.6,1.59,2.53> ,0.21 hole()}
            sphere {<1.61,-0.47,2.04> ,0.29 hole()}
            sphere {<2.19,0.9,1.4> ,0.21 hole()}
            sphere {<1.6,1.97,2.05> ,0.26 hole()}
            sphere {<-1.33,-0.87,-2.24> ,0.27 hole()}
            sphere {<-1.66,-0.16,-2.0> ,0.18 hole()}
            sphere {<0.16,0.07,2.59> ,0.17 hole()}
            sphere {<-0.92,1.9,-2.43> ,0.23 hole()}
            sphere {<2.51,0.24,0.7> ,0.18 hole()}
            sphere {<-0.32,1.52,-2.58> ,0.22 hole()}
            sphere {<-1.04,1.65,2.38> ,0.22 hole()}
            sphere {<-0.93,0.62,-2.43> ,0.18 hole()}
        }         
    }
}

// Кухня
union
{
    // Пол кухни
    plane
    { 
        <0, 1, 0>, -400
        pigment{checker Black White scale 125}
    }

    // Потолок кухни
    plane
    { 
        <0, 1, 0>, 100
        pigment{White}
    }

    // Стена № 1 кухни
    plane
    { 
        <1, 0, 0>, -1250
        texture {T_Stone41 scale 80}  
    }

    // Стена № 2 кухни
    plane
    { 
        <0, 0, 1>, 1250
        texture {T_Stone41 scale 25}  
    }
    
    // Лампа
    cone
    {
        <-20,-16,10>, 10  // Центр одно поверхности
        <-20,-16,22>, 2  // Центр другой поверхности
        open  // Убираем крышку
        texture {T_Brass_2D}
        rotate <-90, 0, 0>
    }
    
    // Лампочка
    sphere
    {
        <-16.5, 11, 13.5>, 4 //координаты центра и радиус
        color 
       texture {T_Glass2}
    }
}


// Яйцо № 1
object
{ 
    Egg 
    texture{ pigment{ color rgb<1,1,1>}
                 normal { bumps 0.5 scale 0.0125}
                 finish { phong 1 reflection{ 0.15 } }
               }
         
        scale <1,1,1>*0.9 
        rotate <30,0,0>
        translate< 5, 0, 2>
}

// Яйцо № 2
object
{ 
    Egg 
    texture{ pigment{ color rgb<1,1,1>}
                 normal { bumps 0.5 scale 0.0125}
                 finish { phong 1 reflection{ 0.15 } }
               }
         
        scale <1,1,1>*0.9 
        rotate <24, -15,2>
        translate< 4.5, 0, 4>
}

// Тарелка
object
{ 
    Half_Hollowed_Rounded_Cylinder1( //  
                                3.2,//  Len_total, // total_Lenght from end to end
                                0.9,// outer radius 
                                0.2,// border radius
                                1, //  border scale y ( >0 ), 0 = no rounded borders!
                                1  //  Merge_On , // 0 = union, 1 = merge !  
                              ) //--------------------------------------------
         texture{ pigment{ color rgb< 1,1,1> }  
                  finish { phong 0.6 reflection{ 0.25 } }
                }
         scale<3, 0.5, 3>  
         translate<0,1.0,0> 
         rotate<0,0,0>
}
      
// Баранки
merge
{   // Баранка № 1
    torus
    {
        0.8, 0.2
        translate <8, 0.3, -5>
        pigment { Copper }
    }
    
    // Баранка № 2
    torus
    {
        0.8, 0.2
        translate <8, 0.3, -3>
        pigment { Copper }
    }
    
    // Баранка № 3
    torus
    {
        0.8, 0.2
        translate <8, 0.7, -4.1>
        pigment { Copper }
    }
    
    // Баранка № 4
    torus
    {
        0.8, 0.2
        translate <8.25, -0.5, -3.71>
        rotate <25, 0, -1>
        pigment { Copper }
    }
}

// Чайник
mesh
{
  #include "..\scenes\advanced\teapot\teapot_tri.inc"
  rotate<-90, 45, 0>
  scale 0.8
  texture{ pigment{ color rgb< 1, 1, 1> } 
           finish { phong 1 }
         }
  translate <-7, 0, -8>
}

// Кувшин
sor
{
  6,
  <0.0,  -0.5>,
  <1.0,   0.0>,
  <2.0,   2.0>,
  <0.8,   3.0>,
  <1.0,   4.0>,
  <1.0,   4.5>
  open
  texture { T_Gold_1B }
  scale <0.5, 1, 0.5>
  translate <-7, 0, 8>
}

#declare Ampulheta = merge{
 cone { 
  <0, 0, 0>, 1.2
  <0, 1.8, 0>, 0
  open
 }
 cone { 
  <0, 3, 0>, 1.2
  <0, 1.2, 0>, 0
  open
 }
}

// Часы
#declare Estrutura = merge
{
 box {
  <-1.3, 3, -1.3> <1.3, 3.2, 1.3> 
 }
 cylinder { 
   <-1, 0, -1> <-1, 3, -1>, 0.12 
 }
 cylinder { 
   <1, 0, -1> <1, 3, -1>, 0.12 
 }
 cylinder { 
   <-1, 0, 1> <-1, 3, 1>, 0.12 
 }
 cylinder { 
   <1, 0, 1> <1, 3, 1>, 0.12 
 }
 box {
  <-1.3, 0, -1.3> <1.3, 0.2, 1.3> 
 }
}  
  
object {
 Ampulheta
 pigment {BrightGold filter 0.7}
    translate <-15, 0, 15>
      rotate<0, 45, 0>
      texture {F_Glass1}
}                               

object {
 Estrutura
 pigment {BrightGold}
   translate <-15, 0, 15>
     rotate<0, 45, 0>
       texture { T_Wood14 }
}

// Стул № 1
union{

 cylinder { 
   <0, 0, 0> <0, 2.5, 0>, 0.5 
 }

 box {
  <-1.5, 0, -0.25> <1.5, 0.5, 0.25>
 }

 box {
  <-0.25, 0, -1.5> <0.25, 0.5, 1.5> 
 }
 cylinder { 
   <0, 2, 0> <0, 2.5, 0>, 3 
 }
 texture { P_WoodGrain1A }
 rotate <0, 30, 0>
 translate <-15, -7, -8>
 scale <2, 2, 2>
}

// Стул № 2
union{

 cylinder { 
   <0, 0, 0> <0, 2.5, 0>, 0.5 
 }

 box {
  <-1.5, 0, -0.25> <1.5, 0.5, 0.25>
 }
 box {
  <-0.25, 0, -1.5> <0.25, 0.5, 1.5> 
 }
 cylinder { 
   <0, 2, 0> <0, 2.5, 0>, 3 
 }
 texture { P_WoodGrain1A }
 rotate <0, 30, 0>
 translate <-18, -7, 12>
 scale <2, 2, 2>
} 

// Масло
superellipsoid
{ <0.25,0.25> 

     texture
     {
        pigment{ color rgb<1,0.75,0.1> }
        finish { phong 1 }
     }
     
     scale <1,0.2, 0.5> 
     rotate<0,45,0> 
     translate<3.5, 1.2, -7.5>
}

// Тарелка для масла
object
{ Half_Hollowed_Rounded_Cylinder1( 
    3.2,
    0.9,
    0.2,
    1, 
    1    
    ) 
    
    texture
    {
        pigment{ color rgb< 1,1,1> }  
        finish { phong 0.6 reflection{ 0.25 } }
    }
         
    scale<2, 0.5 2>  
    translate<6, 1.1, -3> 
    rotate<0, 45, 0>
}
