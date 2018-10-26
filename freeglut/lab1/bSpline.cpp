// glutInit(&argc, const_cast<char**>(argv));
//int main(int argc, const char * argv[])

#include "pch.h"
#include <GL/glut.h>
GLUnurbsObj* nobj;
GLfloat ctlarray[4][3] = {
	{-0.9,-0.8,0.0,},
	{-0.2,0.8,0.0},
	{0.2,-0.5,0.0},
	{0.9,0.8,0.0}};

void init()
{
	glClearColor(1, 1, 1, 1);
	nobj = gluNewNurbsRenderer();
	gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
}

void Display()
{
	GLfloat knot[] = {0.0,0.0, 0.0, 1.0,2.0,2.0,2.0 };
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3.0);
	glColor3f(0, 0.3, 1);
	gluNurbsCurve(nobj, 7, knot, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 4; ++i)
	{
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();
	glFlush();
}

int main(int argc, char* argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(0, 0);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display);
	glutMainLoop();
	return 0;
}

