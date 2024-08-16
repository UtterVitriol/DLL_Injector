#include "inject.h"

DWORD inject(char* dllPath, DWORD procId) {
	HANDLE hProc = INVALID_HANDLE_VALUE;
	DWORD dwError = ERROR_SUCCESS;
	LPVOID loc = NULL;
	SIZE_T bWritten = 0;
	BOOL bError = FALSE;
	HANDLE hThread = INVALID_HANDLE_VALUE;
	DWORD dwExitCode = 0;

	hProc = OpenProcess(PROCESS_ALL_ACCESS, 0, procId);
	if (!hProc)
	{
		dwError = GetLastError();
		goto END;
	}

	loc = VirtualAllocEx(hProc, 0, MAX_PATH, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
	if (!loc)
	{
		dwError = GetLastError();
		goto END;
	}


	bError = WriteProcessMemory(hProc, loc, dllPath, strlen(dllPath) + 1, &bWritten);
	if (!bError)
	{
		dwError = GetLastError();
		goto END;
	}

	hThread = CreateRemoteThread(hProc, 0, 0, (LPTHREAD_START_ROUTINE)LoadLibraryA, loc, 0, 0);
	if (!hThread)
	{
		dwError = GetLastError();
		goto END;
	}

	if (WAIT_OBJECT_0 == WaitForSingleObject(hThread, INFINITE))
	{
		GetExitCodeThread(hThread, &dwExitCode);
	}
	else
	{
		dwError = GetLastError();
		goto END;
	}


	if (dwExitCode == 0)
	{
		dwError = ERROR_BAD_EXE_FORMAT;
	}

END:

	if (hThread) {
		CloseHandle(hThread);
	}


	if (hProc) {
		CloseHandle(hProc);
	}

	return dwError;
}
