#include <windows.h>

int main() {
    char text[100] = "Text received: ";
    DWORD length, bytesRead;
    HANDLE hStdin, fileHandle;
    char filename[] = "output.txt";
    BOOL success;

    length = strlen(text);

    hStdin = GetStdHandle(STD_INPUT_HANDLE);
    if (hStdin == INVALID_HANDLE_VALUE) return 1;

    fileHandle = CreateFile(filename, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
    if (fileHandle == INVALID_HANDLE_VALUE) return 1;

    success = ReadFile(hStdin, text + length, 80, &bytesRead, NULL);
    if (!success) return 1;

    WriteFile(fileHandle, text, length + bytesRead, &bytesRead, NULL);
    CloseHandle(fileHandle);

    return 0;
}
