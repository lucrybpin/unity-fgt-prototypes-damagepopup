# FGT - Prototypes - Damage Popup (floating text)

A fast and lightweight prototyping tool for adding a simple and flexible damage popups to your game.


## How to use

### 1. Call the static method `Create` from the `DamagePopup` class. Use different Constructors for different results:

```csharp
DamagePopup.Create($"100", 2.5f * Vector3.up, targetTransform, Color.red, 25);
```

## 📦 Installation

You can import this system as a Unity package via UPM.

[Github] - Button "<> Code" -> Tab Local -> Tab HTTPS -> Copy url displayed in the field.

[Unity] - Window -> Package Manager -> + -> Add Package from git URL... -> Paste the github https code.