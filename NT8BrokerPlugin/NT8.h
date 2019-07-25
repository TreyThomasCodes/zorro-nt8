#pragma once

#include <windows.h>  // FARPROC
#include <string>
#include <sstream>
#include <vector>

typedef double DATE;

#include "trading.h"

#define DLLFUNC extern __declspec(dllexport)
#define DLLFUNC_C extern "C" __declspec(dllexport)

namespace NT8
{
	// zorro function pointers
	int(__cdecl* BrokerError)(const char* txt) = NULL;
	int(__cdecl* BrokerProgress)(const int percent) = NULL;
	int(__cdecl* http_send)(char* url, char* data, char* header) = NULL;
	long(__cdecl* http_status)(int id) = NULL;
	long(__cdecl* http_result)(int id, char* content, long size) = NULL;
	void(__cdecl* http_free)(int id);

	// zorro function exports
	DLLFUNC_C int BrokerOpen(char* Name, FARPROC fpError, FARPROC fpProgress);
	DLLFUNC_C void BrokerHTTP(FARPROC fpSend, FARPROC fpStatus, FARPROC fpResult, FARPROC fpFree);
	DLLFUNC_C int BrokerLogin(char* User, char* Pwd, char* Type, char* Account);
	DLLFUNC_C int BrokerTime(DATE* pTimeGMT);
}