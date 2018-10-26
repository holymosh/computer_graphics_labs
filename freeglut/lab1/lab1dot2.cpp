// glutInit(&argc, const_cast<char**>(argv));
//int main(int argc, const char * argv[])

#include "pch.h"
#include "GL/glut.h"
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 1, 0);
	glBegin(GL_LINES);
	glVertex2d(0, 0);
	glVertex2d(0.5, 0.0);
	glEnd();
	glutPostRedisplay();
	glutSwapBuffers();
}

int main(int argc, char* argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(0, 0);
	glutCreateWindow(" ");
	glClearColor(0.9, 0.5, 0.75, 1);
	glutDisplayFunc(Display);
	glutMainLoop();
	return 0;
}

