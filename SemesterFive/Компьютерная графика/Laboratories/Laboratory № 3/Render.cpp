

#include "Render.h"

#include <Windows.h>
#include <GL\GL.h>
#include <GL\GLU.h>

int alg = 0;

double f(double p1, double p2, double p3, double p4, double t)
{
	return p1 * (1 - t) * (1 - t) * (1 - t) + 3 * p2 * t * (1 - t)*(1 - t) + p3*(1-t) * t * t*3 +t*t*t*p4;  //посчитанная формула
} 

double f1(double p1, double p4, double r1, double r4, double t)
{
	return p1 * (2*t*t*t - 3*t*t + 1) + p4*(-2*t*t*t + 3*t*t) + r1*(t*t*t -2*t*t +t) + r4*(t*t*t - t*t);  //посчитанная формула
}
void key()
{
	alg++;
	if (alg == 4) alg = 0;
}

	double t_max = 0; 
	void Render(double delta_time)
	{
		double P1[] = { 0,0,0 }; //Наши точки 
		double P2[] = { 0,6,7 };
		double P3[] = { 0,10,7 };
		double P4[] = { 0,10,0 };
		double vectR1[3];
		double vectR4[3];

		double P[3];
		switch (alg)
		{
		
		case 0:
			P1[0] = 0;
			P1[1] = 0;
			P1[2] = 0;

			P2[0] = 0;
			P2[1] = 6;
			P2[2] = 7;

			P3[0] = 0;
			P3[1] = 10;
			P3[2] = 7;

			P4[0] = 0;
			P4[1] = 10;
			P4[2] = 0;


			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P1);
			glVertex3dv(P2);
			glVertex3dv(P3);
			glVertex3dv(P4);
			glEnd();

			glLineWidth(3);  //ширина линии 

			glBegin(GL_LINE_STRIP);

			for (double t = 0; t <= 1.0001; t += 0.01) {
				
				P[0] = f(P1[0], P2[0], P3[0], P4[0], t);
				P[1] = f(P1[1], P2[1], P3[1], P4[1], t);
				P[2] = f(P1[2], P2[2], P3[2], P4[2], t);

				glVertex3dv(P);   //Рисуем точку P  
			}  glEnd();

			glColor3d(1, 0, 1);
			glLineWidth(1);  //возвращаем ширину линии = 1 
			break;


		case 1:
			P1[0] = 10;
			P1[1] = 0;
			P1[2] = 5;

			P2[0] = 0;
			P2[1] = 9;
			P2[2] = 10;

			P3[0] = 5;
			P3[1] = 10;
			P3[2] = 7;

			P4[0] = 6;
			P4[1] = 10;
			P4[2] = 1;
			

			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P1);
			glVertex3dv(P2);
			glVertex3dv(P3);
			glVertex3dv(P4);
			glEnd();

			glLineWidth(3);  //ширина линии 

			glBegin(GL_LINE_STRIP);

			for (double t = 0; t <= 1.0001; t += 0.01) {
				
				P[0] = f(P1[0], P2[0], P3[0], P4[0], t);
				P[1] = f(P1[1], P2[1], P3[1], P4[1], t);
				P[2] = f(P1[2], P2[2], P3[2], P4[2], t);

				glVertex3dv(P);   //Рисуем точку P  
			}  glEnd();

			glColor3d(1, 0, 1);
			glLineWidth(1);  //возвращаем ширину линии = 1 


			break;

		case 2:
			P1[0] = -10;
			P1[1] = 0;
			P1[2] = 5;

			P2[0] = -10;
			P2[1] = -9;
			P2[2] = 15;

			vectR1[0] = P2[0] - P1[0];
			vectR1[1] = P2[1] - P1[1];
			vectR1[2] = P2[2] - P1[2];

			
			P3[0] = -10;
			P3[1] = -9;
			P3[2] = 15;

			P4[0] = -6;
			P4[1] = 10;
			P4[2] = 1;

			vectR4[0] = P4[0] - P3[0];
			vectR4[1] = P4[1] - P3[1];
			vectR4[2] = P4[2] - P3[2];



			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P1);
			glVertex3dv(P2);
			glEnd();

			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P3);
			glVertex3dv(P4);
			glEnd();

			glLineWidth(3);  //ширина линии 

			glBegin(GL_LINE_STRIP);

			for (double t = 0; t <= 1.0001; t += 0.01) {

				P[0] = f1(P1[0], P4[0], vectR1[0], vectR4[0], t);
				P[1] = f1(P1[1], P4[1], vectR1[1], vectR4[1], t);
				P[2] = f1(P1[2], P4[2], vectR1[2], vectR4[2], t);

				glVertex3dv(P);   //Рисуем точку P  
			}  glEnd();

			glColor3d(1, 0, 1);
			glLineWidth(1);  //возвращаем ширину линии = 1 

			break;

		case 3:
			P1[0] = -1;
			P1[1] = 0;
			P1[2] = -5;

			P2[0] = 3;
			P2[1] = -9;
			P2[2] = 5;

			vectR1[0] = P2[0] - P1[0];
			vectR1[1] = P2[1] - P1[1];
			vectR1[2] = P2[2] - P1[2];


			P3[0] = -15;
			P3[1] = -9;
			P3[2] = 15;

			P4[0] = -6;
			P4[1] = 15;
			P4[2] = 1;

			vectR4[0] = P4[0] - P3[0];
			vectR4[1] = P4[1] - P3[1];
			vectR4[2] = P4[2] - P3[2];



			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P1);
			glVertex3dv(P2);
			glEnd();

			glBegin(GL_LINE_STRIP); //построим отрезки P1P2  и P2P3  
			glVertex3dv(P3);
			glVertex3dv(P4);
			glEnd();

			glLineWidth(3);  //ширина линии 

			glBegin(GL_LINE_STRIP);

			for (double t = 0; t <= 1.0001; t += 0.01) {

				P[0] = f1(P1[0], P4[0], vectR1[0], vectR4[0], t);
				P[1] = f1(P1[1], P4[1], vectR1[1], vectR4[1], t);
				P[2] = f1(P1[2], P4[2], vectR1[2], vectR4[2], t);

				glVertex3dv(P);   //Рисуем точку P  
			}  glEnd();

			glColor3d(1, 0, 1);
			glLineWidth(1);  //возвращаем ширину линии = 1 

			break;
		default:
			break;
		}
		}

