// glutInit(&argc, const_cast<char**>(argv));
//int main(int argc, const char * argv[])

#include "pch.h"
#include "GL/glut.h"
void Display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 1, 0);
	glPushMatrix(); // без этих функций едет 
	glTranslatef(0.001, 0, 0);
	glutWireSphere(1.0, 100, 100);
	glPopMatrix();// без этих функций едет
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

