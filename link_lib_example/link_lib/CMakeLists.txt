cmake_minimum_required(VERSION 3.0)
project(untitled2)

set(CMAKE_CXX_STANDARD 14)
set(SOURCE_EXE main.cpp)
include_directories(libMock)
add_executable(main ${SOURCE_EXE})
add_subdirectory(libMock)
target_link_libraries(main libMockLib)