# Unity DirectInput Force Feedback
> Unity Native Plugin to expose DirectX DirectInput ForceFeedback

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity3d.com)
![GitHub issues](https://img.shields.io/github/issues/MrTimcakes/Unity-ForceFeedback?style=for-the-badge)
![GitHub package.json version](https://img.shields.io/github/package-json/v/MrTimcakes/Unity-ForceFeedback?style=for-the-badge)
![GitHub](https://img.shields.io/github/license/MrTimcakes/Unity-ForceFeedback?style=for-the-badge)

This package allows you to easily integrate both the input and ForceFeedback features of DirectX DirectInput from within Unity. This allows you to interface with HID peripherals with ForceFeedback capabilities. This can be used to build vivid simulated experiences.

The package will create a virtual device inside Unity's Input System. This device can then be used like any other device inside the Input System, allowing for easiy rebinding. ForceFeedback capabilites can be acceced via the DIManager class.

## Quick Start

### Installation

This package requires use of Unity's new Input System, ensure [com.unity.inputsystem](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html) is installed in the project. Install it via the package manager via: 

`Window -> Package Manager => Input System`

Next, install this package:

`Package Manager => + => "Add package from git URL..." => ` `https://github.com/MrTimcakes/Unity-ForceFeedback.git` 


## Supported ForceFeedback Effects

| Effect        | Supported |
|---------------|-----------|
| ConstantForce | 🔲 |
| CustomForce   | 🔲 |
| Damper        | 🔲 |
| Friction      | 🔲 |
| Inertia       | 🔲 |
| RampForce     | 🔲 |
| SawtoothDown  | 🔲 |
| SawtoothUp    | 🔲 |
| Sine          | 🔲 |
| Spring        | 🔲 |
| Square        | 🔲 |
| Triangle      | 🔲 |

[comment]: <> (✅ 🔲)

## Compatible Devices

| Peripheral                         | Test Status    |
|------------------------------------|----------------|
| Fanatec CSL Elite                  | ✅ Verified    |
| Fanatec CSW V2.0                   | ✅ Verified    |
| Fanatec WRC Wheel Rim              | ✅ Verified    |
| Fanatec Formula V2 Wheel Rim       | ✅ Verified    |
| Fanatec CSL LC Pedals              | ✅ Verified    |
| Fanatec ClubSport Pedals V3        | ✅ Verified    |
| Fanatec ClubSport Shifter SQ V 1.5 | ✅ Verified    |
| Logitech G29 / G920                | 🔲 Untested    |

[comment]: <> (✅ 🔲)


## Environment

This plugin only works on Windows 64 bit.

Unity Version: 2021.1.7f1

# Support

If you're having any problem, please [raise an issue](https://github.com/MrTimcakes/Unity-ForceFeedback/issues/new) on GitHub.

## License

This project is free Open-Source software, and is released under the GPL-3.0 License, further information can be found under the terms specified in the [license](https://github.com/MrTimcakes/Unity-ForceFeedback/blob/master/LICENSE).