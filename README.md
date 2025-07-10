# 🌌 Solar-System-MR

**A Mixed Reality tour around the Solar System**, built in Unity, offering an interactive, immersive experience to explore planets, moons, and more in MR.

## 🚀 Features

- **Accurate orbital mechanics**: Planets orbit realistically based on scaled velocity and distance.
- **hand distance grab**: Pinch and move planets with one hand
- **two hand scale** : Scale planets with two hands to open planet view
- **Planet info UI**: Scaling a planet opens a panel with essential facts (mass, radius, day/year length, etc.).

## 🎯 Why this project?

Educational and exploratory MR experience to spark curiosity and understanding of our Solar System—ideal for STEM educators, MR developers, and astronomy enthusiasts.

## 🛠️ Getting Started

### Requirements

- Unity 2022+ (tested on 2022.3 LTS)
- Supported MR headset Quest 3 and Quest Pro
- XR Interaction Toolkit & corresponding XR plugin (OpenXR recommended)

### Installation

1. Clone this repo:
   ```bash
   git clone https://github.com/ngiani/Solar-System-MR.git
   cd Solar-System-MR
   ```
2. Open in Unity and let it resolve packages.
3. Ensure **XR Interaction Toolkit** and your headset plugin are installed via Package Manager.
4. Assign correct XR settings in **Project Settings → XR Plug-in Management**.


## 🧹 Architecture

- `Assets/` – Contains models, textures, shaders.
- `Scripts/` – C# logic for orbital movement, interactions, UI.
- `Shaders/` – Custom shading for planetary surfaces.
- `Scenes/` – Main scene for solar system tour.
- `ProjectSettings/` – Unity configuration files.


https://github.com/user-attachments/assets/a569e896-0e96-4bf5-850e-85422772b4b5

Used third party assets: 

-Planets of the Solar System 3D by Evgenii Nikolskii: https://assetstore.unity.com/packages/3d/environments/planets-of-the-solar-system-3d-90219

-Background music is Project Ex - Neo Nebula (freetouse.com).mp3 : https://freetouse.com/music/project-ex/neo-nebula

-Text font Nazalizatiion : https://www.fontmirror.com/nasalization

