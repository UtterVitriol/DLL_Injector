#pragma once
#include <Windows.h>
#include <TlHelp32.h>

extern "C" {
	__declspec (dllexport)
		DWORD inject(char* dllPath, DWORD procId);
}