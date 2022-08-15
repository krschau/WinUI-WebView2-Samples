#include "pch.h"
#include "Thermometer.h"
#include "Thermometer.g.cpp"

// This file was created using the tutorial here:
// https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt

namespace winrt::ThermometerWRC::implementation
{
    float Thermometer::AdjustTemperature(float deltaFahrenheit)
    {
        m_temperatureFahrenheit += deltaFahrenheit;
        return m_temperatureFahrenheit;
    }
}
