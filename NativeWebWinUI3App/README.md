# NativeWebWinUI3App

Tutorials followed:  

[Call native-side WinRT code from web-side code](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/winrt-from-js)  
[Windows Runtime components with C++/WinRT](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt)  
[Custom (3rd-party) WinRT components](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/winrt-from-js?tabs=csharp#custom-3rd-party-winrt-components)  
[Generate a C# projection from a C++/WinRT component](https://docs.microsoft.com/en-us/windows/apps/develop/platform/csharp-winrt/net-projection-from-cppwinrt-component) (Up to and NOT including "Create a NuGet package with the projection")

Try these commands in the DevTools console:

```js
const Windows = chrome.webview.hostObjects.sync.Windows;
(new Windows.Globalization.Language("en-US")).displayName;
```
```js
const rc = chrome.webview.hostObjects.sync.CppWinrtRuntimeComponent;
const thermometer = new rc.Thermometer();
thermometer.adjustTemperature(1.0);
thermometer.adjustTemperature(1.0);
```
