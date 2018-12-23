// glutInit(&argc, const_cast<char**>(argv));
//int main(int argc, const char * argv[])

#include <iostream>
#include <stdlib.h>
#include <GLUT/glut.h>

using namespace std;

GLUnurbsObj* nobj;

GLfloat ctlarray[7][2][4] = {
    -0.6, 0.3, -0.2, 1.0,
    -0.6, 0.0, -0.2, 1.0,
    
    -0.4, 0.3, 0.2, 1.0,
    -0.4, 0.0, 0.2, 1.0,
    
    -0.2, 0.3, -0.2, 1.0,
    -0.2, 0.0, -0.2, 1.0,
    
    0.0, 0.3, 0.2, 1.0,
    0.0, 0.0, 0.2, 1.0,
    
    0.2, 0.3, -0.2, 1.0,
    0.2, 0.0, -0.2, 1.0,
    
    0.4, 0.3, 0.2, 1.0,
    0.4, 0.0, 0.2, 1.0,

    0.6, 0.3, -0.2, 1.0,
    0.6, 0.0, -0.2, 1.0,
};

void init(void)

{
    
    glClearColor(1, 1, 1, 1);
    
    nobj = gluNewNurbsRenderer();
    
    gluNurbsProperty(nobj, GLU_SAMPLING_TOLERANCE, 25.0);
    
    glEnable(GL_TEXTURE_1D);
}

void Display()

{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glLineWidth(3.0);
    glRotatef(0.2, 1, 0, 0);
    glColor3f(5, 0.3, 1);
    
    GLfloat knot2[] = { 0.0, 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 6.0};
    GLfloat knot1[] = { 0.0, 0.0, 1.0, 1.0 };
    
    gluBeginSurface(nobj);
    gluNurbsSurface(nobj, 9, knot2, 4, knot1, 8, 4, &ctlarray[0][0][0], 2, 2, GL_MAP2_VERTEX_4);
    
    gluEndSurface(nobj);
    glutPostRedisplay();
    glutSwapBuffers();
    
}

int main(int argc, const char * argv[])

{
    glutInit(&argc, const_cast<char**>(argv));
    glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
    glutInitWindowSize(480, 480);
    glutInitWindowPosition(100, 100);
    glutCreateWindow(" ");
    init();
    glutDisplayFunc(Display);
    glutMainLoop();
    
    return 0;
    
}
