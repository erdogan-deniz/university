#include "Render.h"

#include <sstream>
#include <iostream>

#include <windows.h>
#include <GL\GL.h>
#include <GL\GLU.h>

#include "MyOGL.h"

#include "Camera.h"
#include "Light.h"
#include "Primitives.h"

#include "GUItextRectangle.h"
#include <math.h>          // Заголовочный файл для математической библиотеки
#include <stdio.h>         // Заголовочный файл для стандартного ввода/вывода
#include <stdlib.h>        // Заголовочный файл для стандартной библиотеки
#include <gl\glu.h>        // Заголовочный файл для библиотеки GLu32

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>


bool textureMode = true;
bool lightMode = true;

Vector3 points[4][4];
Vector3* dragablePoint = 0;

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

		pos.setCoords(camDist*cos(fi2)*cos(fi1),
			camDist*cos(fi2)*sin(fi1),
			camDist*sin(fi2));

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
		s.scale = s.scale*0.08;
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
			c.scale = c.scale*1.5;
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

void mouseEvent(OpenGL *ogl, int mX, int mY)
{
	int dx = mouseX - mX;
	int dy = mouseY - mY;
	mouseX = mX;
	mouseY = mY;

	//меняем углы камеры при нажатой левой кнопке мыши
	if (OpenGL::isKeyPressed(VK_RBUTTON))
	{
		camera.fi1 += 0.01*dx;
		camera.fi2 += -0.01*dy;
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

		x = k*r.direction.X() + r.origin.X();
		y = k*r.direction.Y() + r.origin.Y();

		light.pos = Vector3(x, y, z);
	}

	if (OpenGL::isKeyPressed('G') && OpenGL::isKeyPressed(VK_LBUTTON))
	{
		light.pos = light.pos + Vector3(0, 0, 0.02*dy);
	}

	if (dragablePoint && OpenGL::isKeyPressed(VK_LBUTTON)) {
		(*dragablePoint) = (*dragablePoint) + Vector3(0.02*dx, 0, 0.02 * dy);
	}

	
}

void mouseWheelEvent(OpenGL *ogl, int delta)
{

	if (delta < 0 && camera.camDist <= 1)
		return;
	if (delta > 0 && camera.camDist >= 100)
		return;

	camera.camDist += 0.01*delta;

}

void keyDownEvent(OpenGL *ogl, int key)
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

	if (key == VK_LBUTTON) {
		double mvMatrix[16], prMatrix[16];
		int viewPort[4];
		double x, y, z;
		glGetDoublev(GL_MODELVIEW_MATRIX, mvMatrix);
		glGetDoublev(GL_PROJECTION_MATRIX, prMatrix);
		glGetIntegerv(GL_VIEWPORT, viewPort);

		LPPOINT POINT = new tagPOINT();
		GetCursorPos(POINT);
		ScreenToClient(ogl->getHwnd(), POINT);
		POINT->y = ogl->getHeight() - POINT->y;

		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				int res = gluProject(points[i][j].X(), points[i][j].Y(), points[i][j].Z(), mvMatrix, prMatrix, viewPort, &x, &y, &z);
				if ((x - POINT->x) * (x - POINT->x) + (y - POINT->y) * (y - POINT->y) < 49) {
					dragablePoint = &points[i][j];
					break;
				}
			}
		}
		delete POINT;

	}

}

void keyUpEvent(OpenGL *ogl, int key)
{
	if (key == VK_LBUTTON) {
		dragablePoint = 0;
	}
}



GLuint texId;
GLuint tex2;

//выполняется перед первым рендером
void initRender(OpenGL *ogl)
{
	//настройка текстур

	//4 байта на хранение пикселя
	glPixelStorei(GL_UNPACK_ALIGNMENT, 4);

	//настройка режима наложения текстур
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);

	//включаем текстуры
	glEnable(GL_TEXTURE_2D);
	

	//массив трехбайтных элементов  (R G B)
	RGBTRIPLE *texarray;

	//массив символов, (высота*ширина*4      4, потомучто   выше, мы указали использовать по 4 байта на пиксель текстуры - R G B A)
	char *texCharArray;
	int texW, texH;
	OpenGL::LoadBMP("texture.bmp", &texW, &texH, &texarray);
	OpenGL::RGBtoChar(texarray, texW, texH, &texCharArray);

	
	
	//генерируем ИД для текстуры
	glGenTextures(1, &texId);

	//OpenGL::LoadBMP("floppa.bmp", &texW, &texH, &texarray);
	//OpenGL::RGBtoChar(texarray, texW, texH, &texCharArray);

	//glGenTextures(2, &tex2);

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


	srand(time(0));

	
	for (int i = 0; i < 4; i++) {
		for (int j = 0; j < 4; j++) {
			points[i][j] = Vector3(10.0 * i / 4 - 1, 10.0 * j / 4 - 1, rand() % 5 - 2.5);
		}
	}

}

double fact(int num) {
	int r = 1;
	for (int i = 2; i <= num; i++)
		r *= i;
	return r;
}

double bern(int i, int n, double u) {
	return 1.0 * fact(n) * pow(u, i) * pow(1-u, n - i) / fact(i) / fact(n - i);
}

inline Vector3 bez(Vector3 *p, int n, int m, double u, double v) {
	Vector3 res(0, 0, 0);
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			double Bi = bern(i, n - 1, u);
			double Bj = bern(j, m - 1, v);
			res = res + p[i*m+j] * Bi * Bj;
		}
	}
	return res;
}

#define PI 3.14

inline double f1(double p1, double p2, double p3, double p4, double t)
{
	return p1 * (1 - t) * (1 - t) * (1 - t) + 3 * p2 * t * (1 - t) * (1 - t) + 3 * p3 * t * t * (1 - t) + t * t * t * p4; //���������� �������
}

void bez(Vector3 P1, Vector3 P2, Vector3 P3, Vector3 P4) {
	glLineWidth(1);

	glBegin(GL_LINES);
	glVertex3dv(P1.toArray());
	glVertex3dv(P2.toArray());
	glVertex3dv(P2.toArray());
	glVertex3dv(P3.toArray());
	glVertex3dv(P3.toArray());
	glVertex3dv(P4.toArray());

	glEnd();



	glBegin(GL_LINE_STRIP);
	glColor3f(1, 1, 0);
	for (double t = 0; t <= 1.0001; t += 0.01)
	{
		double P[3];
		P[0] = f1(P1.X(), P2.X(), P3.X(), P4.X(), t);
		P[1] = f1(P1.Y(), P2.Y(), P3.Y(), P4.Y(), t);
		P[2] = f1(P1.Z(), P2.Z(), P3.Z(), P4.Z(), t);
		glVertex3dv(P);
	}
	glEnd();
	glLineWidth(1);
}



void rocket(GLfloat x, GLfloat y, GLfloat z, GLfloat h) {
	z = 0;
	x = 0;
	y = 0;
	GLfloat cube[][6][4] = {
		{ {x + h / 2, y + h / 2, z + h / 2}, {x + h / 2, y - h / 2, z + h / 2}, {x - h / 2, y - h / 2, z + h / 2}, {x - h / 2, y + h / 2, z + h / 2} }, // top
		{ {x + h / 2, y + h / 2, z - h / 2}, {x + h / 2, y - h / 2, z - h / 2}, {x - h / 2, y - h / 2, z - h / 2}, {x - h / 2, y + h / 2, z - h / 2} }, // bottom
		{ {x + h / 2, y - h / 2, z + h / 2}, {x + h / 2, y - h / 2, z - h / 2}, {x - h / 2, y - h / 2, z - h / 2}, {x - h / 2, y - h / 2, z + h / 2} },
		{ {x - h / 2, y - h / 2, z - h / 2}, {x - h / 2, y - h / 2, z + h / 2}, {x - h / 2, y + h / 2, z + h / 2}, {x - h / 2, y + h / 2, z - h / 2} },
		{ {x - h / 2, y + h / 2, z + h / 2}, {x - h / 2, y + h / 2, z - h / 2}, {x + h / 2, y + h / 2, z - h / 2}, {x + h / 2, y + h / 2, z + h / 2} },
		{ {x + h / 2, y + h / 2, z - h / 2}, {x + h / 2, y + h / 2, z + h / 2}, {x + h / 2, y - h / 2, z + h / 2}, {x + h / 2, y - h / 2, z - h / 2} } //sides
	};

	glBegin(GL_QUADS);
	for (int i = 0; i < 6; i++) {
		for (int j = 0; j < 4; j++) {
			glVertex3fv(cube[i][j]);
		}
	}
	glEnd();
}

void jet() {
	GLfloat jetCoords[][4][3] = {
		{{1,0,0}, { 0, 0, 0.25}, {0, -0.5, 0} },
		{{1, 0,0}, {0, 0, 0.25}, {0, 0.5, 0}},
		{{1,0,0}, {0, 0,-0.25}, {0, -0.5,0}},
		{{1, 0,0}, {0, 0, -0.25}, {0, 0.5, 0}}
	};
	GLfloat jetBack[][4] = { {0,0,0.25}, {0,0.5,0}, {0,0,-0.25},{0, 0.5, 0} };

	glPushMatrix();
	glTranslated(-0.5, 0, 0);
	glBegin(GL_TRIANGLES);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				glVertex3fv(jetCoords[i][j]);
			}
		}
	glEnd();
	
	glBegin(GL_QUADS);
	for (int i = 0; i < 4; i++)
		glVertex3fv(jetBack[i]);
	glEnd();
	glPopMatrix();
}


void draw_normals(double x, double y, double z) {
	glBegin(GL_LINES);

	glColor3f(1, 0, 0);
	glVertex3f(0, 0, 0);
	glVertex3f(1, 0, 0);

	glColor3f(0, 1, 0);
	glVertex3f(0, 0, 0);
	glVertex3f(0, 0.75, 0);

	glColor3f(0, 0, 1);
	glVertex3f(0, 0, 0);
	glVertex3f(0, 0, 0.75);

	glEnd();
}

double increment_delta_time = 0.005;
double t_max = 0;

void Render(OpenGL *ogl)
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

	
	
	glColor3f(0, 0.5, 0.5);
	t_max += increment_delta_time; //t_max становится = 1 за 5 секунд
	if (t_max >= 1)
		increment_delta_time = -increment_delta_time;
	if (t_max <= 0)
		increment_delta_time = -increment_delta_time;


	Vector3 p[4];
	p[0] = Vector3(0, 0, 0);
	p[1] = Vector3(0, 10, 10);
	p[2] = Vector3(20, 5, -10);
	p[3] = Vector3(-1, -1, 5);
	
	bez(p[0], p[1], p[2], p[3]);
	glBegin(GL_LINE_STRIP); //построим отрезки P1P2 и P2P3
	glVertex3dv(p[0].toArray());
	glVertex3dv(p[1].toArray());
	glVertex3dv(p[2].toArray());
	glVertex3dv(p[3].toArray());
	glEnd();

	glPushMatrix();
	
	Vector3 pos (
		f1(p[0].X(), p[1].X(), p[2].X(), p[3].X(), t_max),
		f1(p[0].Y(), p[1].Y(), p[2].Y(), p[3].Y(), t_max),
		f1(p[0].Z(), p[1].Z(), p[2].Z(), p[3].Z(), t_max)
	);
	
	Vector3 pre_pos (
		f1(p[0].X(), p[1].X(), p[2].X(), p[3].X(), t_max - increment_delta_time),
		f1(p[0].Y(), p[1].Y(), p[2].Y(), p[3].Y(), t_max - increment_delta_time),
		f1(p[0].Z(), p[1].Z(), p[2].Z(), p[3].Z(), t_max - increment_delta_time)
	);

	Vector3 dir = (pos - pre_pos).normolize();

	Vector3 orig(1, 0, 0);
	Vector3 rotX(dir.X(), dir.Y(), 0);
	rotX = rotX.normolize();
	double cosU = orig.scalarProisvedenie(rotX);
	Vector3 vecpr = orig.vectProisvedenie(rotX);

	double sinSign = vecpr.Z() / abs(vecpr.Z());
	double yaw = acos(cosU) * 180 / PI * sinSign; // рыскание

	double tanXU = Vector3(1, 0, 0).scalarProisvedenie(dir);
	double roll = atan(dir.Y()) * 180 / PI * tanXU; // крен

	double cosZU = Vector3(0, 0, 1).scalarProisvedenie(dir);
	double pitch = acos(dir.Z()) * 180 / PI - 90; // тангаж

	glTranslated(pos.X(), pos.Y(), pos.Z());
	glRotated(yaw, 0, 0, 1);
	glRotated(pitch, 0, 1, 0);
	glRotated(roll, 1, 0, 0);

	draw_normals(0, 0, 0);
	jet();
	glPopMatrix();

	
//poverhnost ==============

	
	double h = 0.1;
	Vector3 prev1, prev2;
	Vector3 p1, p2, p3, p4;

	glBindTexture(GL_TEXTURE_2D, 1);
	glBegin(GL_TRIANGLES);
	for (double u = h; u <= 1; u += h) {
		prev1 = bez((Vector3*)points, 4, 4, u, 0);
		prev2 = bez((Vector3*)points, 4, 4, u - h, 0);
		for (double v = h; v <= 1; v += h) {
			p1 = bez((Vector3*)points, 4, 4, u, v);   
			p2 = bez((Vector3*)points, 4, 4, u - h, v);
			p3 = prev2;
			p4 = prev1;

			glNormal3dv((p2 - p3).vectProisvedenie(p2 - p1).toArray());
			glTexCoord2d(u, v);
			glVertex3dv(p1.toArray());
			glTexCoord2d(u - h, v - h);
			glVertex3dv(p3.toArray());
			glTexCoord2d(u - h, v);
			glVertex3dv(p2.toArray());

			glNormal3dv((p4 - p1).vectProisvedenie(p4 - p3).toArray());
			glTexCoord2d(u, v);
			glVertex3dv(p1.toArray());
			glTexCoord2d(u, v - h);
			glVertex3dv(p4.toArray());
			glTexCoord2d(u - h, v - h);
			glVertex3dv(p3.toArray());
	
			prev1 = p1;
			prev2 = p2;
			
		}
		
	}
	glEnd();
	

	/*glDisable(GL_LIGHTING);
	glColor3d(1, 0.7, 0);

	for (int i = 1; i < 4; i++) {
		for (int j = 1; j < 4; j++) {
			glBegin(GL_LINE_LOOP);
			glVertex3dv(points[i][j].toArray());
			glVertex3dv(points[i - 1][j].toArray());
			glVertex3dv(points[i - 1][j - 1].toArray());
			glVertex3dv(points[i][j - 1].toArray());
			glEnd();
		}
	}
	

	glDisable(GL_DEPTH_TEST);
	glEnable(GL_POINT_SMOOTH);
	glPointSize(10);
	glBegin(GL_POINTS);
	glColor3d(0, 1, 0);
	for (int i = 0; i < 4; i++) {
		for (int j = 0; j < 4; j++) {
			if (dragablePoint && dragablePoint == &points[i][j])
				continue;
			glVertex3dv(points[i][j].toArray());
		}

	}
	if (dragablePoint) {
		glColor3d(1, 0, 0);
		glVertex3dv(dragablePoint->toArray());
	}
	glEnd();
	glLineWidth(1);*/

	
		
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
	ss << "Параметры камеры: R="  << camera.camDist << ", fi1=" << camera.fi1 << ", fi2=" << camera.fi2 << std::endl;
	
	rec.setText(ss.str().c_str());
	rec.Draw();

	glMatrixMode(GL_PROJECTION);	  //восстанавливаем матрицы проекции и модел-вью обратьно из стека.
	glPopMatrix();


	glMatrixMode(GL_MODELVIEW);
	glPopMatrix();

}