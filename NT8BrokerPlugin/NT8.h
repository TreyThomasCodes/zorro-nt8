#pragma once

typedef double DATE;

#include <windows.h>  // FARPROC
#include <string>
#include <sstream>
#include <vector>
#include "trading.h"

#define DLLFUNC extern __declspec(dllexport)
#define DLLFUNC_C extern "C" __declspec(dllexport)

namespace NT8
{
	int(__cdecl* BrokerError)(const char* txt) = NULL;
	int(__cdecl* BrokerProgress)(const int percent) = NULL;

	// zorro functions
	DLLFUNC_C int BrokerOpen(char* Name, FARPROC fpError, FARPROC fpProgress);
}