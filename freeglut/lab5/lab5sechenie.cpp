#include "glut.h"
GLUnurbsObj* nobj;
GLUnurbsObj* nobj1;
GLUnurbsObj* nobj2;
GLfloat ctlarray[][3] = { { 0.25,0.433,0.0 },{ 0.5, 0.866 , 0.0 },{ 0.75,0.433,0.0 } };
GLfloat ctlarray3[][3] = { { 0.25,0.433,0.0 },{ 0.5, 0.866 *0.5, 0.0 },{ 0.75,0.433,0.0 } };
GLfloat ctlarray4[][3] = { { 0.25,0.433,0.0 },{ 0.5, 0.866 *0.75, 0.0 },{ 0.75,0.433,0.0 } };
GLfloat ctlarray1[][3] = { { 0.5,0.0,0.0 },{ 0.0, 0.0 , 0.0 },{ 0.25,0.433,0.0 } };
GLfloat ctlarray2[][3] = { { 0.75,0.433,0.0}, { 1.0, 0.0 , 0.0 },{ 0.5,0.0,0.0 } };
void init(void)
{
	glClearColor(1, 1, 1, 1);
	nobj = gluNewNurbsRenderer();
	nobj1 = gluNewNurbsRenderer();
	nobj2 = gluNewNurbsRenderer();
	gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
	gluNurbsProperty(nobj1, GLU_SAMPLING_TOLERANCE, 25.0);
	gluNurbsProperty(nobj2, GLU_SAMPLING_TOLERANCE, 25.0);
}


void Display1()
{
	GLfloat knot[] = { 0.0,0.0,1.0,2.0,3.0, 3.0 };
	GLfloat knot1[] = { 0.0,0.0,0.0,1.0,1.0,1.0 };
	glClear(GL_COLOR_BUFFER_BIT);
	glLineWidth(3.0);
	glColor3f(0.2, 0.1, 0.5);
	gluNurbsCurve(nobj, 5, knot, 3, &ctlarray[0][0], 2, GL_MAP1_VERTEX_3);
	gluNurbsCurve(nobj, 6, knot1, 3, &ctlarray[0][0], 3, GL_MAP1_VERTEX_3);
	gluNurbsCurve(nobj, 6, knot1, 3, &ctlarray3[0][0], 3, GL_MAP1_VERTEX_3);
	gluNurbsCurve(nobj, 6, knot1, 3, &ctlarray4[0][0], 3, GL_MAP1_VERTEX_3);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++) {
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
		glVertex3f(ctlarray3[i][0], ctlarray3[i][1], ctlarray3[i][2]);
		glVertex3f(ctlarray4[i][0], ctlarray4[i][1], ctlarray4[i][2]);
	}
	glEnd();

	GLfloat knot2[] = { 0.0,0.0,1.0,2.0,3.0, 3.0 };
	GLfloat knot3[] = { 0.0,0.0,0.0,1.0,1.0,1.0 };
	glLineWidth(3.0);
	glColor3f(0.2, 0.1, 0.5);
	gluNurbsCurve(nobj1, 5, knot2, 3, &ctlarray1[0][0], 2, GL_MAP1_VERTEX_3);
	gluNurbsCurve(nobj1, 6, knot3, 3, &ctlarray1[0][0], 3, GL_MAP1_VERTEX_3);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++) {
		glVertex3f(ctlarray1[i][0], ctlarray1[i][1], ctlarray1[i][2]);
		glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();

	GLfloat knot4[] = { 0.0,0.0,1.0,2.0,3.0, 3.0 };
	GLfloat knot5[] = { 0.0,0.0,0.0,1.0,1.0,1.0 };
	glLineWidth(3.0);
	glColor3f(0.2, 0.1, 0.5);
	gluNurbsCurve(nobj2, 5, knot4, 3, &ctlarray2[0][0], 2, GL_MAP1_VERTEX_3);
	gluNurbsCurve(nobj2, 6, knot5, 3, &ctlarray2[0][0], 3, GL_MAP1_VERTEX_3);
	glPointSize(4.0);
	glColor3f(0.0, 0.0, 1);
	glBegin(GL_POINTS);
	for (int i = 0; i < 3; i++) {
		glVertex3f(ctlarray2[i][0], ctlarray2[i][1], ctlarray2[i][2]);
		//glVertex3f(ctlarray[i][0], ctlarray[i][1], ctlarray[i][2]);
	}
	glEnd();
	glFlush();
}


void main()
{
	glutInitDisplayMode(GLUT_RGBA | GLUT_SINGLE);
	glutInitWindowSize(680, 680);
	glutInitWindowPosition(200, 200);
	glutCreateWindow(" ");
	init();
	glutDisplayFunc(Display1);
	glutMainLoop();
}