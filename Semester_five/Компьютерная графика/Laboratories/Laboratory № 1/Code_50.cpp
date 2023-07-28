#include "Render.h"
#include <Windows.h>
#include <GL\GL.h>
#include <GL\GLU.h>
#include <corecrt_math.h>
#include <iostream>

#define pairDD pair<double, double>

using namespace std;

void roundOut(double step, double pointA[], double pointB[], double pointC[]);
void roundIn(double step, double pointA[], double pointB[], double pointC[], double pointA1[], double E[], double H[]);
pairDD findCircumCenter(pairDD P, pairDD Q, pairDD R);
pairDD lineLineIntersection(double a1, double b1, double c1, double a2, double b2, double c2);
void perpendicularBisectorFromLine(pairDD P, pairDD Q, double& a, double& b, double& c);
void lineFromPoints(pairDD P, pairDD Q, double& a, double& b, double& c);
void figure();

void Render(double delta_time)
{
	figure();
}


void figure()
{
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
	glVertex3dv(A);
	glVertex3dv(B);
	glVertex3dv(C);

	glVertex3dv(A1);
	glVertex3dv(B1);
	glVertex3dv(C1);

	glVertex3dv(A2);
	glVertex3dv(B2);
	glVertex3dv(C2);

	glVertex3dv(A3);
	glVertex3dv(B3);
	glVertex3dv(C3);

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
	glVertex3dv(AA);
	glVertex3dv(BB);
	glVertex3dv(CC);

	glVertex3dv(AA1);
	glVertex3dv(BB1);
	glVertex3dv(CC1);

	glVertex3dv(AA2);
	glVertex3dv(BB2);
	glVertex3dv(CC2);

	glVertex3dv(AA3);
	glVertex3dv(BB3);
	glVertex3dv(CC3);

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
	glVertex3dv(Z);
	glVertex3dv(Q);
	glVertex3dv(W);
	glVertex3dv(X);

	glColor3d(0, 1, 1);
	glVertex3dv(Z1);
	glVertex3dv(Q1);
	glVertex3dv(W1);
	glVertex3dv(X1);

	glColor3d(0.5, 1, 1);
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
	glVertex3dv(Z4);
	glVertex3dv(Q4);
	glVertex3dv(W4);
	glVertex3dv(X4);

	glColor3d(0.25, 0.25, 0.25);
	glVertex3dv(Z5);
	glVertex3dv(Q5);
	glVertex3dv(W5);
	glVertex3dv(X5);

	glColor3d(0.5, 0.25, 0.1);
	glVertex3dv(Z6);
	glVertex3dv(Q6);
	glVertex3dv(W6);
	glVertex3dv(X6);

	glColor3d(0.15, 0.3, 0.1);
	glVertex3dv(Z7);
	glVertex3dv(Q7);
	glVertex3dv(W7);
	glVertex3dv(X7);
	glEnd();

	roundOut(0.005, A, C, AA);
	double pointC[] = {3,14,0};
	roundIn(0.005,A6,B6,pointC,AA5,B5,A5);

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


	glBegin(GL_TRIANGLE_FAN);


	for (double i = -Fi - 0.285; i <= 3.14 - Fi - 0.28; i += step)
	{

		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointA[2] };
		glVertex3dv(point);

	}



	glEnd();


	glBegin(GL_TRIANGLE_FAN);


	for (double i = -Fi - 0.285; i <= 3.14 - Fi - 0.28; i += step)
	{

		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointC[2] };
		glVertex3dv(point);

	}



	glEnd();


	glColor3d(0.2, 0.2, 0.2);

	glBegin(GL_QUADS);


	for (double i = -Fi - 0.285 - step; i <= 3.2 - Fi + 0.2 + step; i += step)
	{
		double point[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointA[2] };
		double point1[] = { radius * cos(i) + centre[0], radius * sin(i) + centre[1], pointC[2] };
		double point2[] = { radius * cos(i + step) + centre[0], radius * sin(i + step) + centre[1], pointA[2] };
		double point3[] = { radius * cos(i + step) + centre[0], radius * sin(i + step) + centre[1], pointC[2] };
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

	double Fi1 = 0.54 -acos((-pointA[0]) / (sqrt(pow(pointA[0], 2) + pow(pointA[1], 2))));

	double Fi2 = 0.8-acos((-pointB[0]) / (sqrt(pow(pointB[0], 2) + pow(pointB[1], 2))));




	glBegin(GL_TRIANGLE_FAN);

	glVertex3dv(E);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA[2] };

		glVertex3dv(point);




	}
	glVertex3dv(H);
	glEnd();



	glBegin(GL_TRIANGLE_FAN);

	glVertex3dv(H);

	for (double i = Fi1 - step - 0.515; i <= Fi2 - step + 0.35; i += step)
	{
		double point[] = { radius * cos(i) + pointO.first, radius * sin(i) + pointO.second, pointA[2] };

		glVertex3dv(point);




	}

	glEnd();


	glBegin(GL_TRIANGLE_FAN);

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

	


	return circumcenter;
}