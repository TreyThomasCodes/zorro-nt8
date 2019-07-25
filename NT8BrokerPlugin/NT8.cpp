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
}