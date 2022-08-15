#pragma once
#include "Thermometer.g.h"

// Note: Remove this static_assert after copying these generated source files to your project.
// This assertion exists to avoid compiling these generated source files directly.
//static_assert(false, "Do not compile generated C++/WinRT source files directly");

namespace winrt::CppWinrtRuntimeComponent::implementation
{
    struct Thermometer : ThermometerT<Thermometer>
    {
        Thermometer() = default;

        void AdjustTemperature(float deltaFahrenheit);

    private:
        float m_temperatureFahrenheit{ 0.f };
    };
}
namespace winrt::CppWinrtRuntimeComponent::factory_implementation
{
    struct Thermometer : ThermometerT<Thermometer, implementation::Thermometer>
    {
    };
}
