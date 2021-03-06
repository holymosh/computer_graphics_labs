#include "pch.h"
#include <stdio.h>
#include <windows.h>
#include <gl/freeglut.h>


GLfloat ctlarrayfirst[3][2][4] = 
{ 0.5,0.0,-0.3,1.0,0.5,0.0,
0.3,1.0,0.0,0.866*0.55,-0.3*0.55, 0.55,
0.0,0.866*0.55,0.3*0.55, 0.55, -0.5,0.0,
-0.3,1.0,-0.5,0.0,0.3,1.0 };

GLfloat ctlarraysecond[3][2][4] =
{ 0.5,0.0,-0.5,1.0,0.5,0.0,
0.5,1.0,0.0,0.866*0.55,-0.5*0.55, 0.55,
0.0,0.866*0.55,0.5*0.55, 0.55, -0.5,0.0,
-0.5,1.0,-0.5,0.0,0.5,1.0 };
GLfloat TexP[] = { 1.0,0.0,0.0,0.0 };
GLfloat TexP1[] = { 0.0,1.0,0.0,0.0 };
GLfloat TexP2[] = { 0.0,0.0,1.0,0.0 };
GLubyte TexI[] = { 255,0,0,255,0,0,255,255,0,255,255,0,0,255,0,0,255,0,0,0,255,0,0,255 };
GLfloat texptsfirst[2][2][2] = { 0,0,0,1,1,0,1,1 };
GLfloat texptssecond[2][2][2] = { 0,0,0,1,1,0,1,1 };
GLUnurbsObj *theNurb;
GLUquadricObj* theqw; GLubyte *Iz_RGB;




void file_read() {
	FILE* stream;
	BITMAPFILEHEADER FileHeader;
	BITMAPINFOHEADER InfoHeader;
	errno_t err = fopen_s(&stream, "C:\\holymosh\\study\\c0mp_gr4ph\\file1.bmp", "rb");
	fread(&FileHeader, sizeof(FileHeader), 1, stream);
	fread(&InfoHeader, sizeof(InfoHeader), 1, stream);
	fseek(stream, FileHeader.bfOffBits, SEEK_SET);
	int w = InfoHeader.biWidth;
	int h = InfoHeader.biHeight;
	Iz_RGB = (GLubyte*)malloc(w*h * 3);
	fread(Iz_RGB, w*h * 3, 1, stream);
	fclose(stream);
	for (int i = 0; i < w*h * 3; i += 3) {
		GLubyte m1 = Iz_RGB[i];
		Iz_RGB[i] = Iz_RGB[i + 2];
		Iz_RGB[i + 2] = m1;
	}
}

void initsecond() {
	glClearColor(0.1, 0.98, 0.3, 1);
	theNurb = gluNewNurbsRenderer();
	theqw = gluNewQuadric();
	glEnable(GL_DEPTH_TEST);
	gluNurbsProperty(theNurb, GLU_SAMPLING_TOLERANCE, 25.0);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, 64, 64, 0, GL_RGB, GL_UNSIGNED_BYTE, Iz_RGB);
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);
	gluQuadricTexture(theqw, true);
	glEnable(GL_TEXTURE_2D);
	free(Iz_RGB);
}

void Displaysecond() {
	GLfloat knot[] = { 0.0,0.0,0.0,1.0,1.0,1.0 };
	GLfloat knot1[] = { 0.0,0.0,1.0,1.0 };
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glRotatef(1.5, 1.0, 1.0, 1.0);
	glColor3f(1, 0, 0);
	glMap2f(GL_MAP2_TEXTURE_COORD_2, 0, 1, 2, 2, 0, 1, 4, 2, &texptsfirst[0][0][0]);
	glEnable(GL_MAP2_TEXTURE_COORD_2);
	gluSphere(theqw, 0.3, 50, 50);
	gluBeginSurface(theNurb);
	gluNurbsSurface
	(theNurb,
		6, knot,
		4, knot1,
		2 * 4,
		4,
		&ctlarraysecond[0][0][0],
		3, 2,
		GL_MAP2_VERTEX_4);
	gluEndSurface(theNurb);
	glutPostRedisplay(); glutSwapBuffers();
}




void main(int argc, char* argv[]) {
	glutInit(&argc, argv);
	file_read();
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(480, 480);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(" ");
	initsecond();
	glutDisplayFunc(Displaysecond);
	glutMainLoop();
}