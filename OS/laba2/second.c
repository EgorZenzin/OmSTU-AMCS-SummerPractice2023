#include <windows.h>
#include <stdio.h>

int main() {
    char buffer[100] = "";
    DWORD bytesRead;
    HANDLE hStdout, fileHandle, duplicateHandle, anotherFileHandle;
    char filename[] = "output.txt";
    BOOL rc;
    
    hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
    if (hStdout == INVALID_HANDLE_VALUE)
        return 1;

    fileHandle = CreateFile(filename, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
    if (fileHandle == INVALID_HANDLE_VALUE)
        return 1;

    DuplicateHandle(GetCurrentProcess(), fileHandle, GetCurrentProcess(), &duplicateHandle, 0, FALSE, DUPLICATE_SAME_ACCESS);
    
    anotherFileHandle = CreateFile(filename, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
    if (anotherFileHandle == INVALID_HANDLE_VALUE)
        return 1;

    printf("File Handle: %lu\nDuplicate Handle: %lu\nAnother File Handle: %lu\n", (unsigned long)fileHandle, (unsigned long)duplicateHandle, (unsigned long)anotherFileHandle);

    rc = SetFilePointer(fileHandle, 10, NULL, FILE_BEGIN);
    rc = ReadFile(fileHandle, buffer, 7, &bytesRead, NULL);
    if (!rc)
        return 1;
    WriteFile(hStdout, buffer, bytesRead, &bytesRead, NULL);

    rc = ReadFile(duplicateHandle, buffer, 7, &bytesRead, NULL);
    if (!rc)
        return 1;
    WriteFile(hStdout, buffer, bytesRead, &bytesRead, NULL);

    rc = ReadFile(anotherFileHandle, buffer, 7, &bytesRead, NULL);
    if (!rc)
        return 1;
    WriteFile(hStdout, buffer, bytesRead, &bytesRead, NULL);

    CloseHandle(fileHandle);
    CloseHandle(duplicateHandle);
    CloseHandle(anotherFileHandle);
    getchar();
    return 0;
}
