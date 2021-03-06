#include "pch.h"
#include <GL/glut.h>

GLUnurbsObj * nobj;
GLfloat ctlarray[][3] = { {-0.9, -0.8, 0.0}, 
	{-0.4, 0.8, 0.0}, {0,-0.8,0}, {0.4, 0.8, 0.0},
	{0.9, -0.8, 0.0} };
GLfloat ctlarray1[][3] = { {-0.9, -0.8, 0.0},
	{-0.3, 1, 0.0}, {0,-2,0}, {0.3, 1, 0.0},
	{0.9, -0.8, 0.0} };

GLfloat ctlarray2[][3] = { {-0.9, -0.8, 0.0},
	{0.3, 1, 0.0}, {0,-3,0}, {-0.3, 1, 0.0},
	{0.9, -0.8, 0.0} };

void init()
{
	glClearColor(1, 1, 1, 1);
	nobj = gluNewNurbsRenderer();
	gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
}

void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3);

	glColor3f(0, 0.3, 1);
	GLfloat knot0[] = { 0,0,0,1,2,3,3,3 };
	gluNurbsCurve(nobj, 7, knot0, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);
	GLfloat knot01[] = { 0, 1, 2, 3, 4, 5, 6 };
	gluNurbsCurve(nobj, 7, knot01, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);

	glColor3f(1, 0.3, 0);
	GLfloat knot1[] = { 0,0,0,1,2,3,3,3 };
	gluNurbsCurve(nobj, 8, knot1, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	GLfloat knot11[] = { 0,0,0,1,2,3,3,3 };
	gluNurbsCurve(nobj, 8, knot11, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);

	glColor3f(1, 0.3, 1);
	GLfloat knot2[] = { 0, 0, 0, 0, 1, 2, 2, 2, 2 };
	gluNurbsCurve(nobj, 9, knot2, 3, &ctlarray1[0][0], 4, GL_MAP1_VERTEX_3);
	/*GLfloat knot21[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
	gluNurbsCurve(nobj, 9, knot21, 3, &ctlarray[0][0], 4, GL_MAP1_VERTEX_3);*/

	glColor3f(0.1, 1, 0.1);
	GLfloat knot3[] = { 0, 0, 0, 0, 0, 2, 2, 2, 2, 2 };
	gluNurbsCurve(nobj, 10, knot3, 3, &ctlarray2[0][0], 5, GL_MAP1_VERTEX_3);
	/*GLfloat knot31[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	gluNurbsCurve(nobj, 10, knot31, 3, &ctlarray[0][0], 5, GL_MAP1_VERTEX_3);
*/
	glPointSize(4);
	glColor3f(0, 0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 5; ++i)
	{
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();
	glFlush();
}

int main(int argc, char ** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(500, 500);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("openGL");
	// glClearColor(0.9, 0.2, 0, 1);
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
}