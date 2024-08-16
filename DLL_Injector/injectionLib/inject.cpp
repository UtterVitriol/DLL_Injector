#include "inject.h"


DWORD GetProcId(const wchar_t* procName) {

	DWORD procId = 0;

	HANDLE hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

	if (hSnap != INVALID_HANDLE_VALUE) {

		PROCESSENTRY32 procEntry{};

		procEntry.dwSize = sizeof(procEntry);

		if (Process32First(hSnap, &procEntry)) {
			do {

				if (!_wcsicmp(procEntry.szExeFile, procName)) {

					procId = procEntry.th32ProcessID;
					break;
				}

			} while (Process32Next(hSnap, &procEntry));
		}
	}

	CloseHandle(hSnap);
	return procId;
}

__declspec (dllexport)
void inject(char *dllPath, DWORD procId) {
	HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, 0, procId);

	if (hProc && (hProc != INVALID_HANDLE_VALUE)) {
		void* loc = VirtualAllocEx(hProc, 0, MAX_PATH, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

		SIZE_T bWritten = 0;

		WriteProcessMemory(hProc, loc, dllPath, strlen(dllPath) + 1, &bWritten);

		HANDLE hThread = CreateRemoteThread(hProc, 0, 0, (LPTHREAD_START_ROUTINE)LoadLibraryA, loc, 0, 0);

		if (hThread) {
			CloseHandle(hThread);
		}
	}

	if (hProc) {
		CloseHandle(hProc);
	}
}
