# Unity DirectInput Force Feedback

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity3d.com)
![GitHub issues open](https://img.shields.io/github/issues/MrTimcakes/Unity-DirectInput?style=for-the-badge)
![GitHub issues close](https://img.shields.io/github/issues-closed/MrTimcakes/Unity-DirectInput?style=for-the-badge)
![GitHub package.json version](https://img.shields.io/github/package-json/v/MrTimcakes/Unity-DirectInput?style=for-the-badge)
![GitHub](https://img.shields.io/github/license/MrTimcakes/Unity-DirectInput?style=for-the-badge)

![Unity-DirectInput Banner](https://github.com/MrTimcakes/Unity-DirectInput/blob/assets/UnityDirectInputBanner.png )

This package allows you to easily integrate both the input and ForceFeedback features of DirectX DirectInput from within Unity. This allows you to interface with HID peripherals with ForceFeedback capabilities. This can be used to build vivid simulated experiences.

The package will create a virtual device inside Unity's Input System. This device can then be used like any other device inside the Input System, allowing for easy rebinding. ForceFeedback capabilites can be accessed via the DIManager class. The [DirectInputExplorer](../../tree/main/DirectInputExplorer~) is a windows forms application built in parallel with the C++ library to enable quick development by avoiding the need to reload Unity after every change. It also functions as an easy way to examine DirectInput devices.

# Quick Start
![image](https://github.com/user-attachments/assets/5398f792-d075-41fc-a292-1a7a585dbdc8)

### Installation

This package requires use of Unity's new Input System, ensure [com.unity.inputsystem](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html) is installed in the project. Install it via the package manager via: 

`Window -> Package Manager => Input System`

Next, install (copy and paste) the Plugin folder of this repo into the Assets folder of your Unity project. You can copy and paste the whole content, and Unity will automatically exclude the unrelated contents as their folder names have "~" characters. Those unrelated folders have the source code of the native Direct Input FFB DLL that Unity uses. Open the Sample Scene there and play the scene to start working with this asset.


## Supported ForceFeedback Effects

| Effect        | Supported |
|---------------|-----------|
| ConstantForce | ✅ |
| CustomForce   | ℹ️ |
| Damper        | ✅ |
| Friction      | ✅ |
| Inertia       | ✅ |
| RampForce     | ✅ |
| SawtoothDown  | ✅ |
| SawtoothUp    | ✅ |
| Sine          | ✅ |
| Spring        | ✅ |
| Square        | ✅ |
| Triangle      | ✅ |

[comment]: <> (✅ ℹ️ 🔲)

Note that everything is adjustable in the native DLL, And the Custom Force effect exists but has not been fully done.

## Compatible Devices
### Note that all the devices that use Direct Input (from the old Logitech G wheels to the advanced Simcube ones) should work
The community has tested and verified these devices do indeed work. Albeit not all devices support all the FFB effects!

| Peripheral                         | Test Status    |
|------------------------------------|----------------|
| [Fanatec CSL DD (Both PC & Comp mode + 8NM Kit)](https://fanatec.com/eu-en/csl-dd-8-nm) | ✅ Verified    |
| [Fanatec CSL Elite](https://fanatec.com/eu-en/racing-wheels-wheel-bases/wheel-bases/csl-elite-wheel-base-officially-licensed-for-playstation) | ✅ Verified    |
| [Fanatec CSW V2.0](https://fanatec.com/eu-en/racing-wheels-wheel-bases/wheel-bases/clubsport-wheel-base-v2-servo) | ✅ Verified    |
| [Fanatec WRC Wheel Rim](https://fanatec.com/eu-en/steering-wheels/csl-elite-steering-wheel-wrc) | ✅ Verified    |
| [Fanatec Formula V2 Wheel Rim](https://fanatec.com/eu-en/steering-wheels/clubsport-steering-wheel-formula-v2) & [APM](https://fanatec.com/eu-en/shifters-others/podium-advanced-paddle-module) | ✅ Verified    |
| [Fanatec CSL LC Pedals](https://fanatec.com/eu-en/pedals/csl-elite-pedals) | ✅ Verified    |
| [Fanatec ClubSport Pedals V1](https://www.youtube.com/watch?v=jw52Dq3SZaA) | ✅ Verified    |
| [Fanatec ClubSport Pedals V3](https://fanatec.com/eu-en/pedals/clubsport-pedals-v3) | ✅ Verified    |
| [Fanatec ClubSport Shifter SQ V 1.5](https://fanatec.com/eu-en/shifters-others/clubsport-shifter-sq-v-1.5) | ✅ Verified    |
| [Logitech G29 / G920](https://www.logitechg.com/en-gb/products/driving/driving-force-racing-wheel.html) | ✅ Verified    |
| [Moza R9](https://mozaracing.com/wheel-base-r9/) | ✅ Verified    |
| [PRO Racing Wheel](https://www.logitechg.com/en-gb/products/driving/pro-racing-wheel.html) | ✅ Verified    |
| [Simagic Alpha-Mini](https://us.sim-motion.com/products/simagic-alpha-mini-wheel-base) | ✅ Verified    |
| [Thrustmaster TX](https://eshop.thrustmaster.com/en_us/tx-racing-wheel-leather-edition.html) | ✅ Verified    |


[comment]: <> (✅ 🔲)

Note for pedals, only input readings were guaranteed to *likely* work fine.

## Environment

This plugin only works on Windows 8+ 64-bit.

Latest verified Unity version: 2022.2.1f1

# Notice
Occasionally calls to EnumerateDevices will take orders of magnitude longer than usual to execute (up to 60 seconds), this is caused by a Windows bug attempting to load an absent hardware device. USB Audio DACs & Corsair keyboards are known the cause this issue, try disconnecting and reconnecting offending USB devices. For more information see [this](https://stackoverflow.com/questions/10967795/directinput8-enumdevices-sometimes-painfully-slow) StackOverflow post about the issue from 2012. See issue [#1](https://github.com/MrTimcakes/Unity-DirectInput/issues/1) for more info.

# Support

If you have problems, please [raise an issue](https://github.com/MrTimcakes/Unity-DirectInput/issues/new) on GitHub.

# License

This project is free Open-Source software released under the LGPL-3.0 License. Further information can be found under the terms specified in the [license](/../../blob/main/LICENSE).
