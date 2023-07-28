#include "Render.h"

#include <sstream>
#include <iostream>
#include <list>

#include <windows.h>
#include <GL\GL.h>
#include <GL\GLU.h>

#include "MyOGL.h"

#include "Camera.h"
#include "Light.h"
#include "Primitives.h"

#include "GUItextRectangle.h"
using namespace std;


#define HEIGHT 4
#define pairDD pair<double, double>



void figure();
void roundOut(double step, double pointA[], double pointB[], double pointC[]);
void roundIn(double step, double pointA[], double pointB[], double pointC[], double pointA1[], double E[], double H[]);
void lineFromPoints(pairDD P, pairDD Q, double& a, double& b, double& c);
void perpendicularBisectorFromLine(pairDD P, pairDD Q, double& a, double& b, double& c);
pairDD lineLineIntersection(double a1, double b1, double c1, double a2, double b2, double c2);
pairDD findCircumCenter(pairDD P, pairDD Q, pairDD R);

list<double> vectProz(double A[], double B[], double C[], int k);

bool textureMode = true;
bool lightMode = true;

//класс для настройки камеры
class CustomCamera : public Camera
{
public:
	//дистанция камеры
	double camDist;
	//углы поворота камеры
	double fi1, fi2;


	//значния масеры по умолчанию
	CustomCamera()
	{
		camDist = 15;
		fi1 = 1;
		fi2 = 1;
	}


	//считает позицию камеры, исходя из углов поворота, вызывается движком
	void SetUpCamera()
	{
		//отвечает за поворот камеры мышкой
		lookPoint.setCoords(0, 0, 0);

		pos.setCoords(camDist * cos(fi2) * cos(fi1),
			camDist * cos(fi2) * sin(fi1),
			camDist * sin(fi2));

		if (cos(fi2) <= 0)
			normal.setCoords(0, 0, -1);
		else
			normal.setCoords(0, 0, 1);

		LookAt();
	}

	void CustomCamera::LookAt()
	{
		//функция настройки камеры
		gluLookAt(pos.X(), pos.Y(), pos.Z(), lookPoint.X(), lookPoint.Y(), lookPoint.Z(), normal.X(), normal.Y(), normal.Z());
	}



}  camera;   //создаем объект камеры


//Класс для настройки света
class CustomLight : public Light
{
public:
	CustomLight()
	{
		//начальная позиция света
		pos = Vector3(1, 1, 3);
	}


	//рисует сферу и линии под источником света, вызывается движком
	void  DrawLightGhismo()
	{
		glDisable(GL_LIGHTING);


		glColor3d(0.9, 0.8, 0);
		Sphere s;
		s.pos = pos;
		s.scale = s.scale * 0.08;
		s.Show();

		if (OpenGL::isKeyPressed('G'))
		{
			glColor3d(0, 0, 0);
			//линия от источника света до окружности
			glBegin(GL_LINES);
			glVertex3d(pos.X(), pos.Y(), pos.Z());
			glVertex3d(pos.X(), pos.Y(), 0);
			glEnd();

			//рисуем окруность
			Circle c;
			c.pos.setCoords(pos.X(), pos.Y(), 0);
			c.scale = c.scale * 1.5;
			c.Show();
		}

	}

	void SetUpLight()
	{
		GLfloat amb[] = { 0.2, 0.2, 0.2, 0 };
		GLfloat dif[] = { 1.0, 1.0, 1.0, 0 };
		GLfloat spec[] = { .7, .7, .7, 0 };
		GLfloat position[] = { pos.X(), pos.Y(), pos.Z(), 1. };

		// параметры источника света
		glLightfv(GL_LIGHT0, GL_POSITION, position);
		// характеристики излучаемого света
		// фоновое освещение (рассеянный свет)
		glLightfv(GL_LIGHT0, GL_AMBIENT, amb);
		// диффузная составляющая света
		glLightfv(GL_LIGHT0, GL_DIFFUSE, dif);
		// зеркально отражаемая составляющая света
		glLightfv(GL_LIGHT0, GL_SPECULAR, spec);

		glEnable(GL_LIGHT0);
	}


} light;  //создаем источник света




//старые координаты мыши
int mouseX = 0, mouseY = 0;

void mouseEvent(OpenGL* ogl, int mX, int mY)
{
	int dx = mouseX - mX;
	int dy = mouseY - mY;
	mouseX = mX;
	mouseY = mY;

	//меняем углы камеры при нажатой левой кнопке мыши
	if (OpenGL::isKeyPressed(VK_RBUTTON))
	{
		camera.fi1 += 0.01 * dx;
		camera.fi2 += -0.01 * dy;
	}


	//двигаем свет по плоскости, в точку где мышь
	if (OpenGL::isKeyPressed('G') && !OpenGL::isKeyPressed(VK_LBUTTON))
	{
		LPPOINT POINT = new tagPOINT();
		GetCursorPos(POINT);
		ScreenToClient(ogl->getHwnd(), POINT);
		POINT->y = ogl->getHeight() - POINT->y;

		Ray r = camera.getLookRay(POINT->x, POINT->y);

		double z = light.pos.Z();

		double k = 0, x = 0, y = 0;
		if (r.direction.Z() == 0)
			k = 0;
		else
			k = (z - r.origin.Z()) / r.direction.Z();

		x = k * r.direction.X() + r.origin.X();
		y = k * r.direction.Y() + r.origin.Y();

		light.pos = Vector3(x, y, z);
	}

	if (OpenGL::isKeyPressed('G') && OpenGL::isKeyPressed(VK_LBUTTON))
	{
		light.pos = light.pos + Vector3(0, 0, 0.02 * dy);
	}


}

void mouseWheelEvent(OpenGL* ogl, int delta)
{

	if (delta < 0 && camera.camDist <= 1)
		return;
	if (delta > 0 && camera.camDist >= 100)
		return;

	camera.camDist += 0.01 * delta;

}

void keyDownEvent(OpenGL* ogl, int key)
{
	if (key == 'L')
	{
		lightMode = !lightMode;
	}

	if (key == 'T')
	{
		textureMode = !textureMode;
	}

	if (key == 'R')
	{
		camera.fi1 = 1;
		camera.fi2 = 1;
		camera.camDist = 15;

		light.pos = Vector3(1, 1, 3);
	}

	if (key == 'F')
	{
		light.pos = camera.pos;
	}
}

void keyUpEvent(OpenGL* ogl, int key)
{

}



GLuint texId;

//выполняется перед первым рендером
void initRender(OpenGL* ogl)
{
	//настройка текстур

	//4 байта на хранение пикселя
	glPixelStorei(GL_UNPACK_ALIGNMENT, 4);

	//настройка режима наложения текстур
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);

	//включаем текстуры
	glEnable(GL_TEXTURE_2D);


	//массив трехбайтных элементов  (R G B)
	RGBTRIPLE* texarray;

	//массив символов, (высота*ширина*4      4, потомучто   выше, мы указали использовать по 4 байта на пиксель текстуры - R G B A)
	char* texCharArray;
	int texW, texH;
	OpenGL::LoadBMP("texture.bmp", &texW, &texH, &texarray);
	OpenGL::RGBtoChar(texarray, texW, texH, &texCharArray);



	//генерируем ИД для текстуры
	glGenTextures(1, &texId);
	//биндим айдишник, все что будет происходить с текстурой, будте происходить по этому ИД
	glBindTexture(GL_TEXTURE_2D, texId);

	//загружаем текстуру в видеопямять, в оперативке нам больше  она не нужна
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, texW, texH, 0, GL_RGBA, GL_UNSIGNED_BYTE, texCharArray);

	//отчистка памяти
	free(texCharArray);
	free(texarray);

	//наводим шмон
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);


	//камеру и свет привязываем к "движку"
	ogl->mainCamera = &camera;
	ogl->mainLight = &light;

	// нормализация нормалей : их длины будет равна 1
	glEnable(GL_NORMALIZE);

	// устранение ступенчатости для линий
	glEnable(GL_LINE_SMOOTH);


	//   задать параметры освещения
	//  параметр GL_LIGHT_MODEL_TWO_SIDE - 
	//                0 -  лицевые и изнаночные рисуются одинаково(по умолчанию), 
	//                1 - лицевые и изнаночные обрабатываются разными режимами       
	//                соответственно лицевым и изнаночным свойствам материалов.    
	//  параметр GL_LIGHT_MODEL_AMBIENT - задать фоновое освещение, 
	//                не зависящее от сточников
	// по умолчанию (0.2, 0.2, 0.2, 1.0)

	glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, 0);

	camera.fi1 = -1.3;
	camera.fi2 = 0.8;
}





void Render(OpenGL* ogl)
{



	glDisable(GL_TEXTURE_2D);
	glDisable(GL_LIGHTING);

	glEnable(GL_DEPTH_TEST);
	if (textureMode)
		glEnable(GL_TEXTURE_2D);

	if (lightMode)
		glEnable(GL_LIGHTING);


	//альфаналожение
	//glEnable(GL_BLEND);
	//glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);


	//настройка материала
	GLfloat amb[] = { 0.2, 0.2, 0.1, 1. };
	GLfloat dif[] = { 0.4, 0.65, 0.5, 1. };
	GLfloat spec[] = { 0.9, 0.8, 0.3, 1. };
	GLfloat sh = 0.1f * 256;


	//фоновая
	glMaterialfv(GL_FRONT, GL_AMBIENT, amb);
	//дифузная
	glMaterialfv(GL_FRONT, GL_DIFFUSE, dif);
	//зеркальная
	glMaterialfv(GL_FRONT, GL_SPECULAR, spec); \
		//размер блика
		glMaterialf(GL_FRONT, GL_SHININESS, sh);

	//чтоб было красиво, без квадратиков (сглаживание освещения)
	glShadeModel(GL_SMOOTH);
	//===================================
	//Прогать тут  
	figure();



   //Сообщение вверху экрана


	glMatrixMode(GL_PROJECTION);	//Делаем активной матрицу проекций. 
									//(всек матричные операции, будут ее видоизменять.)
	glPushMatrix();   //сохраняем текущую матрицу проецирования (которая описывает перспективную проекцию) в стек 				    
	glLoadIdentity();	  //Загружаем единичную матрицу
	glOrtho(0, ogl->getWidth(), 0, ogl->getHeight(), 0, 1);	 //врубаем режим ортогональной проекции

	glMatrixMode(GL_MODELVIEW);		//переключаемся на модел-вью матрицу
	glPushMatrix();			  //сохраняем текущую матрицу в стек (положение камеры, фактически)
	glLoadIdentity();		  //сбрасываем ее в дефолт

	glDisable(GL_LIGHTING);



	GuiTextRectangle rec;		   //классик моего авторства для удобной работы с рендером текста.
	rec.setSize(300, 150);
	rec.setPosition(10, ogl->getHeight() - 150 - 10);


	std::stringstream ss;
	ss << "T - вкл/выкл текстур" << std::endl;
	ss << "L - вкл/выкл освещение" << std::endl;
	ss << "F - Свет из камеры" << std::endl;
	ss << "G - двигать свет по горизонтали" << std::endl;
	ss << "G+ЛКМ двигать свет по вертекали" << std::endl;
	ss << "Коорд. света: (" << light.pos.X() << ", " << light.pos.Y() << ", " << light.pos.Z() << ")" << std::endl;
	ss << "Коорд. камеры: (" << camera.pos.X() << ", " << camera.pos.Y() << ", " << camera.pos.Z() << ")" << std::endl;
	ss << "Параметры камеры: R=" << camera.camDist << ", fi1=" << camera.fi1 << ", fi2=" << camera.fi2 << std::endl;

	rec.setText(ss.str().c_str());
	rec.Draw();

	glMatrixMode(GL_PROJECTION);	  //восстанавливаем матрицы проекции и модел-вью обратьно из стека.
	glPopMatrix();


	glMatrixMode(GL_MODELVIEW);
	glPopMatrix();

}

void figure()
{

	list <double> N;
	// Низ
	double A[] = { 0, 0, 0 };
	double B[] = { 3, 8, 0 };
	double C[] = { 7, 2, 0 };

	double A1[] = { 7, 2, 0 };
	double B1[] = { 6, 7, 0 };
	double C1[] = { 3, 8, 0 };

	double A2[] = { 3, 8, 0 };
	double B2[] = { 6, 7, 0 };
	double C2[] = { 5, 9, 0 };

	double A3[] = { 6, 7, 0 };
	double B3[] = { 5, 9, 0 };
	double C3[] = { 10, 10, 0 };

	double A4[] = { 6, 7, 0 };
	double B4[] = { 5, 9, 0 };
	double C4[] = { 10, 10, 0 };

	double A5[] = { 3, 8, 0 };
	double B5[] = { 5, 9, 0 };
	double C5[] = { 5, 17, 0 };

	double A6[] = { 5, 17, 0 };
	double B6[] = { -2, 13, 0 };
	double C6[] = { 3, 8, 0 };

	// Вверх
	double AA[] = { 0, 0, 2 };
	double BB[] = { 3, 8, 2 };
	double CC[] = { 7, 2, 2 };

	double AA1[] = { 7, 2, 2 };
	double BB1[] = { 6, 7, 2 };
	double CC1[] = { 3, 8, 2 };

	double AA2[] = { 3, 8, 2 };
	double BB2[] = { 6, 7, 2 };
	double CC2[] = { 5, 9, 2 };

	double AA3[] = { 6, 7, 2 };
	double BB3[] = { 5, 9, 2 };
	double CC3[] = { 10, 10, 2 };

	double AA4[] = { 6, 7, 2 };
	double BB4[] = { 5, 9, 2 };
	double CC4[] = { 10, 10, 2 };

	double AA5[] = { 3, 8, 2 };
	double BB5[] = { 5, 9, 2 };
	double CC5[] = { 5, 17, 2 };

	double AA6[] = { 5, 17, 2 };
	double BB6[] = { -2, 13, 2 };
	double CC6[] = { 3, 8, 2 };
	// Стенка 1
	double Z[] = { 0, 0, 0 };
	double X[] = { 0, 0, 2 };
	double W[] = { 7, 2, 2 };
	double Q[] = { 7, 2, 0 };
	// Стенка 2
	double Z1[] = { 0, 0, 0 };
	double X1[] = { 0, 0, 2 };
	double W1[] = { 3, 8, 2 };
	double Q1[] = { 3, 8, 0 };
	// Стенка 3
	double Z2[] = { 3, 8, 0 };
	double X2[] = { 3, 8, 2 };
	double W2[] = { -2, 13, 2 };
	double Q2[] = { -2, 13, 0 };
	// Стенка 4
	double Z3[] = { -2, 13, 0 };
	double X3[] = { -2, 13, 2 };
	double W3[] = { 5, 17, 2 };
	double Q3[] = { 5, 17, 0 };
	// Стенка 5
	double Z4[] = { 5, 17, 0 };
	double X4[] = { 5, 17, 2 };
	double W4[] = { 5, 9, 2 };
	double Q4[] = { 5, 9, 0 };
	// Стенка 6
	double Z5[] = { 5, 9, 0 };
	double X5[] = { 5, 9, 2 };
	double W5[] = { 10, 10, 2 };
	double Q5[] = { 10, 10, 0 };
	// Стенка 7
	double Z6[] = { 10, 10, 0 };
	double X6[] = { 10, 10, 2 };
	double W6[] = { 6, 7, 2 };
	double Q6[] = { 6, 7, 0 };
	// Стенка 8
	double Z7[] = { 6, 7, 0 };
	double X7[] = { 6, 7, 2 };
	double W7[] = { 7, 2, 2 };
	double Q7[] = { 7, 2, 0 };



	glBegin(GL_TRIANGLES);
	glColor3d(0, 0, 0);
	N = vectProz(A, B, C, 1);
	auto iter = N.begin();
	double a, b, c;
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(A);
	glVertex3dv(B);
	glVertex3dv(C);


	N = vectProz(A1, B1, C1, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(A1);
	glVertex3dv(B1);
	glVertex3dv(C1);

	N = vectProz(A2, B2, C2, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(A2);
	glVertex3dv(B2);
	glVertex3dv(C2);


	N = vectProz(A3, B3, C3, 1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(A3);
	glVertex3dv(B3);
	glVertex3dv(C3);


	N = vectProz(A4, B4, C4, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(A4);
	glVertex3dv(B4);
	glVertex3dv(C4);

	/*glVertex3dv(A5);
	glVertex3dv(B5);
	glVertex3dv(C5);*/

	//glVertex3dv(A6);
	//glVertex3dv(B6);
	//glVertex3dv(C6);

	glColor3d(1, 0, 0);
	N = vectProz(AA, BB, CC, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(AA);
	glVertex3dv(BB);
	glVertex3dv(CC);



	N = vectProz(AA1, BB1, CC1, 1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(AA1);
	glVertex3dv(BB1);
	glVertex3dv(CC1);



	N = vectProz(AA2, BB2, CC2, 1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(AA2);
	glVertex3dv(BB2);
	glVertex3dv(CC2);



	N = vectProz(AA3, BB3, CC3, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(AA3);
	glVertex3dv(BB3);
	glVertex3dv(CC3);



	N = vectProz(AA4, BB4, CC4, 1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(AA4);
	glVertex3dv(BB4);
	glVertex3dv(CC4);

	//glVertex3dv(AA5);
	//glVertex3dv(BB5);
	//glVertex3dv(CC5);

	//glVertex3dv(AA6);
	//glVertex3dv(BB6);
	//glVertex3dv(CC6);
	glEnd();

	glColor3d(0, 0, 1);

	glBegin(GL_QUADS);

	N = vectProz(Z, Q, W, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z);
	glVertex3dv(Q);
	glVertex3dv(W);
	glVertex3dv(X);

	glColor3d(0, 1, 1);
	N = vectProz(Z1, Q1, W1, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z1);
	glVertex3dv(Q1);
	glVertex3dv(W1);
	glVertex3dv(X1);

	glColor3d(0.5, 1, 1);
	N = vectProz(Z2, Q2, W2, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z2);
	glVertex3dv(Q2);
	glVertex3dv(W2);
	glVertex3dv(X2);

	//glColor3d(0.5, 0.5, 1);
	//glVertex3dv(Z3);
	//glVertex3dv(Q3);
	//glVertex3dv(W3);
	//glVertex3dv(X3);

	glColor3d(0.5, 0.5, 0.5);
	N = vectProz(Z4, Q4, W4, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z4);
	glVertex3dv(Q4);
	glVertex3dv(W4);
	glVertex3dv(X4);

	glColor3d(0.25, 0.25, 0.25);
	N = vectProz(Z5, Q5, W5, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z5);
	glVertex3dv(Q5);
	glVertex3dv(W5);
	glVertex3dv(X5);

	glColor3d(0.5, 0.25, 0.1);
	N = vectProz(Z6, Q6, W6, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z6);
	glVertex3dv(Q6);
	glVertex3dv(W6);
	glVertex3dv(X6);

	glColor3d(0.15, 0.3, 0.1);
	N = vectProz(Z7, Q7, W7, -1);
	iter = N.begin();
	a = *iter;
	b = *++iter;
	c = *++iter;
	glNormal3d(a, b, c);
	glVertex3dv(Z7);
	glVertex3dv(Q7);
	glVertex3dv(W7);
	glVertex3dv(X7);
	glEnd();

	roundOut(0.005, A, C, AA);
	double pointC[] = { 3,14,0 };
	roundIn(0.005, A6, B6, pointC, AA5, B5, A5);

	/*glBegin(GL_TRIANGLES);
	glVertex3dv(A6);
	glVertex3dv(pointC);
	glVertex3dv(B6);
	glEnd();*/
}




void roundOut(double step, double pointA[], double pointB[], double pointC[])
{
	glColor3d(0, 0, 0);

	double vect_AB[] = { pointA[0] - pointB[0], pointA[1] - pointB[1] };
	double centre[] = { (pointA[0] + pointB[0]) / 2,  (pointA[1] + pointB[1]) / 2 };

	double length = sqrt(vect_AB[0] * vect_AB[0] + vect_AB[1] * vect_AB[1]);

	double radius = length / 2;

	double Fi = acos(vect_AB[0] / (length + 1));

	glNormal3d(0, 0, -1);
	glBegin(GL_TRIANGLE_FAN);


	for (double i = -Fi - 0.285; i <= 3.14 - Fi - 0.28; i += step)
	{

		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointA[2] };
		glVertex3dv(point);

	}



	glEnd();

	glNormal3d(0, 0, 1);
	glBegin(GL_TRIANGLE_FAN);


	for (double i = -Fi - 0.285; i <= 3.14 - Fi - 0.28; i += step)
	{

		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointC[2] };
		glVertex3dv(point);

	}



	glEnd();

	list<double> N;
	double a, b, c;
	auto iter = N.begin();
	glColor3d(0.2, 0.2, 0.2);

	glBegin(GL_QUADS);


	for (double i = -Fi - 0.285 - step; i <= 3.2 - Fi + 0.2 + step; i += step)
	{
		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointA[2] };
		double point1[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointC[2] };
		double point2[] = { radius * cos(i + step) + centre[0], radius * sin(i + step) + centre[1], pointA[2] };
		double point3[] = { radius * cos(i + step) + centre[0], radius * sin(i + step) + centre[1], pointC[2] };

		N = vectProz(point, point2, point3, 1);

		iter = N.begin();
		a = *iter;
		b = *++iter;
		c = *++iter;
		glNormal3d(a, b, c);
		glVertex3dv(point);
		glVertex3dv(point2);
		glVertex3dv(point3);
		glVertex3dv(point1);



	}
	glEnd();
}

void roundIn(double step, double pointA[], double pointB[], double pointC[], double pointA1[], double E[], double H[])
{
	pairDD P = make_pair(pointA[0], pointA[1]);
	pairDD Q = make_pair(pointB[0], pointB[1]);
	pairDD R = make_pair(pointC[0], pointC[1]);
	pairDD pointO = findCircumCenter(P, Q, R);



	double c = sqrt(pow((pointB[0] - pointA[0]), 2) + pow((pointB[1] - pointA[1]), 2));//длины
	double a = sqrt(pow((pointC[0] - pointB[0]), 2) + pow((pointC[1] - pointB[1]), 2));//сторон
	double b = sqrt(pow((pointA[0] - pointC[0]), 2) + pow((pointA[1] - pointC[1]), 2));//треугольника
	double s = 0.5 * abs(pointA[0] * (pointB[1] - pointC[1]) - pointA[1] * (pointB[0] - pointC[0]) + pointB[0] * pointC[1] - pointB[1] * pointC[0]);//площадь треуг

	double radius = (a * b * c) / (4 * s);//радиус описанной окр

	double Fi1 = 0.54 - acos((-pointA[0]) / (sqrt(pow(pointA[0], 2) + pow(pointA[1], 2))));

	double Fi2 = 0.8 - acos((-pointB[0]) / (sqrt(pow(pointB[0], 2) + pow(pointB[1], 2))));





	glBegin(GL_TRIANGLE_FAN);

	glNormal3d(0, 0, -1);

	glVertex3dv(E);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA[2] };

		glVertex3dv(point);




	}
	glVertex3dv(H);
	glEnd();


	list <double> N;
	auto iter = N.begin();
	glBegin(GL_TRIANGLE_FAN);

	glNormal3d(0, 0, -1);

	glVertex3dv(H);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA[2] };

		
		glVertex3dv(point);




	}

	glEnd();	

	glBegin(GL_TRIANGLE_FAN);
	glNormal3d(0, 0, 1);
	double E1[3];
	E1[0] = E[0];
	E1[1] = E[1];
	E1[2] = pointA1[2];

	glVertex3dv(E1);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA1[2] };

		glVertex3dv(point);




	}

	double H1[3];
	H1[0] = H[0];
	H1[1] = H[1];
	H1[2] = pointA1[2];

	glVertex3dv(H1);
	glEnd();



	glBegin(GL_TRIANGLE_FAN);

	glNormal3d(0, 0, 1);
	E1[0] = E[0];
	E1[1] = E[1];
	E1[2] = pointA1[2];

	glVertex3dv(H1);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA1[2] };

		glVertex3dv(point);




	}


	glEnd();





	glColor3d(1.0, 0.2, 0.2);

	glBegin(GL_QUADS);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA[2] };
		double point1[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA1[2] };
		double point2[] = { radius * cos(i + step) + pointO.first, radius * sin(i + step) + pointO.second, pointA[2] };
		double point3[] = { radius * cos(i + step) + pointO.first, radius * sin(i + step) + pointO.second, pointA1[2] };

		N = vectProz(point, point2, point3, -1);

		iter = N.begin();
		a = *iter;
		b = *++iter;
		c = *++iter;
		glNormal3d(a, b, c);
		glVertex3dv(point);
		glVertex3dv(point2);
		glVertex3dv(point3);
		glVertex3dv(point1);



	}
	glEnd();
}




// Function to find the line given two points
void lineFromPoints(pairDD P, pairDD Q, double& a, double& b, double& c)
{
	a = Q.second - P.second;
	b = P.first - Q.first;
	c = a * (P.first) + b * (P.second);
}

// Function which converts the input line to its
// perpendicular bisector. It also inputs the points
// whose mid-point lies on the bisector
void perpendicularBisectorFromLine(pairDD P, pairDD Q, double& a, double& b, double& c)
{
	pairDD mid_point = make_pair((P.first + Q.first) / 2,
		(P.second + Q.second) / 2);

	// c = -bx + ay
	c = -b * (mid_point.first) + a * (mid_point.second);

	double temp = a;
	a = -b;
	b = temp;
}

// Returns the intersection point of two lines
pairDD lineLineIntersection(double a1, double b1, double c1, double a2, double b2, double c2)
{
	double determinant = a1 * b2 - a2 * b1;
	if (determinant == 0)
	{
		// The lines are parallel. This is simplified
		// by returning a pair of FLT_MAX
		return make_pair(FLT_MAX, FLT_MAX);
	}

	else
	{
		double x = (b2 * c1 - b1 * c2) / determinant;
		double y = (a1 * c2 - a2 * c1) / determinant;
		return make_pair(x, y);
	}
}

pairDD findCircumCenter(pairDD P, pairDD Q, pairDD R)
{
	// Line PQ is represented as ax + by = c
	double a, b, c;
	lineFromPoints(P, Q, a, b, c);

	// Line QR is represented as ex + fy = g
	double e, f, g;
	lineFromPoints(Q, R, e, f, g);

	// Converting lines PQ and QR to perpendicular
	// vbisectors. After this, L = ax + by = c
	// M = ex + fy = g
	perpendicularBisectorFromLine(P, Q, a, b, c);
	perpendicularBisectorFromLine(Q, R, e, f, g);

	// The point of intersection of L and M gives
	// the circumcenter
	pairDD circumcenter =
		lineLineIntersection(a, b, c, e, f, g);

	if (circumcenter.first == FLT_MAX &&
		circumcenter.second == FLT_MAX)
	{
		cout << "The two perpendicular bisectors "
			"found come parallel" << endl;
		cout << "Thus, the given points do not form "
			"a triangle and are collinear" << endl;
	}

	else
	{
		cout << "The circumcenter of the triangle PQR is: ";
		cout << "(" << circumcenter.first << ", "
			<< circumcenter.second << ")" << endl;
	}


	return circumcenter;
}



list<double> vectProz(double A[], double B[], double C[], int k)
{
	double A1[] = {B[0] - A[0], B[1] - A[1], B[2] - A[2]};
	double B1[] = { C[0] - A[0], C[1] - A[1], C[2] - A[2] };
	
	list <double> list_ = {k*(A1[1]*B1[2] - A1[2]*B1[1]), k*(A1[2]*B1[0] - A1[0]*B1[2]), k*(A1[0]*B1[1] - A1[1]*B1[0])};
	return list_;
}

