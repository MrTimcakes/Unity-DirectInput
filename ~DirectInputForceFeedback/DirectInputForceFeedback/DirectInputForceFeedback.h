#pragma once

#ifdef DIRECTINPUTFORCEFEEDBACK_EXPORTS
#define DIRECTINPUTFORCEFEEDBACK_API __declspec(dllexport)
#else
#define DIRECTINPUTFORCEFEEDBACK_API __declspec(dllimport)
#endif

extern "C" double DIRECTINPUTFORCEFEEDBACK_API add(double a, double b);