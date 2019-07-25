#include "pch.h"
#include "NT8.h"

constexpr auto PLUGIN_VERSION = 2;

namespace NT8
{
	DLLFUNC_C int BrokerOpen(char* Name, FARPROC fpError, FARPROC fpProgress)
	{
		strcpy_s(Name, 32, "NT8");
		(FARPROC&)BrokerError = fpError;
		(FARPROC&)BrokerProgress = fpProgress;
		return PLUGIN_VERSION;
	}

	DLLFUNC_C void BrokerHTTP(FARPROC fpSend, FARPROC fpStatus, FARPROC fpResult, FARPROC fpFree)
	{
	}

	DLLFUNC_C int BrokerLogin(char* User, char* Pwd, char* Type, char* Account)
	{
		return 0;
	}

	DLLFUNC_C int BrokerTime(DATE* pTimeGMT)
	{
		return 0;
	}
	
}