#pragma once
#include "Thermometer.g.h"

// This file was created using the tutorial here:
// https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt

namespace winrt::ThermometerWRC::implementation
{
    struct Thermometer : ThermometerT<Thermometer>
    {
        Thermometer() = default;

        float AdjustTemperature(float deltaFahrenheit);

    private:
        float m_temperatureFahrenheit{ 0.f };
    };
}
namespace winrt::ThermometerWRC::factory_implementation
{
    struct Thermometer : ThermometerT<Thermometer, implementation::Thermometer>
    {
    };
}
