#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <unistd.h>
#include <string.h>
#define RED "\033[1;31m" // красный цвет
#define GREEN "\033[4;32m"	// зеленый цвет
int main() {
	char name[] = "file";	// название файла для открытия
	char buffer[255]; // буфер
    int file;	// хэндл файла
	int lenght;	// размер полученной строки чтения
	struct flock lock={F_WRLCK, SEEK_SET, 0, 0};
	file = open(name, O_RDWR, 0600);	// открываем файл
	while (fcntl(file, F_SETLK, &lock) == -1){ // проверяем на ошибку доступа		
			sprintf(buffer,"\033[15;40H%sError",RED);
			write(1, buffer, strlen(buffer));	// выводим ошибку
			sleep(1+(rand()%3));				// случайная задержка перед следующей проверкой файла
	}    
    sprintf(buffer,"\033[15;40H%sReaded from file:\033[16;40H",GREEN); // указываем что прочитали файл, записавая это в буфер
    write(1,buffer,strlen(buffer));	// выводим буфер в который записали что прочитан файл
	lenght = read(file, buffer, 80); // чтение с файла
    write(1, buffer, lenght);	// вывод в консоль
	sleep(7);	// задержка в 7 секунд
	close(file);	// закрытие файла
	return 0;	
}
