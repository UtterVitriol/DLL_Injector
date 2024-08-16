#pragma once
#include <Windows.h>
#include <TlHelp32.h>

extern "C" {
	__declspec (dllexport)
		void inject(char* dllPath, DWORD procId);
}