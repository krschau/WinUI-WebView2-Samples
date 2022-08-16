# NativeWebWinUI2App

Tutorials followed:  
[Get started with WebView2 in WinUI 2 (UWP) apps](https://docs.microsoft.com/en-us/microsoft-edge/webview2/get-started/winui2)  
[Call native-side WinRT code from web-side code](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/winrt-from-js)  
[Windows Runtime components with C++/WinRT](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt)  
[Custom (3rd-party) WinRT components](https://docs.microsoft.com/en-us/microsoft-edge/webview2/how-to/winrt-from-js?tabs=csharp#custom-3rd-party-winrt-components)

Try these commands in the DevTools console:

```js
const Windows = chrome.webview.hostObjects.sync.Windows;
(new Windows.Globalization.Language("en-US")).displayName;
```
```js
const rc = chrome.webview.hostObjects.sync.ThermometerWRC;
const thermometer = new rc.Thermometer();
thermometer.adjustTemperature(1.0);
thermometer.adjustTemperature(1.0);
```

You can see another example here: https://github.com/MicrosoftEdge/WebView2Samples/tree/main/SampleApps/webview2_sample_uwp
