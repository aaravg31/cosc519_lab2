# COSC 519 (J) – Lab 2
**Project Title:** UBCO Courtyard VR Interactions

---

## 🎮 Project Description 
This project is a VR experience developed for **COSC 519 (J)(Lab 2)** using Unity 6000.2.6f2 (URP) and the XR Interaction Toolkit for Meta Quest.

The environment is based on the UBCO Courtyard v2 asset, where the player can freely explore and interact with the scene using VR controllers.
The assignment goal was to create at least 3 interactions that demonstrate effective VR mechanics such as movement, grabbing, and in-world UI interaction.

---

## ✨ Interactive Elements  

1. **Movement & Locomotion (Controller Joysticks)**  
   - The player can navigate around the courtyard using the **left and right controller joysticks**.  
   - Implemented with the **XR Interaction Toolkit’s Action-Based Controller** system for smooth locomotion and rotation.  

2. **Visual Hand Representation (Grab & Pinch Animations)**  
   - Each controller displays a **ghostly hand model** that visually responds to **trigger inputs**.  
   - The hands animate to **grab and pinch** when interacting with physical objects.  

3. **Basic UI – Cube Color Change Buttons**  
   - A floating **UI panel** allows the user to **change the color of a cube** by selecting different buttons.  
   - Demonstrates world-space UI interaction through the XR ray interactor system.  

4. **Notification & Phone UI System** *(work-in-progress)*  
   - A small **notification UI** appears at the **top-right of the camera view**.  
   - Clicking it hides the notification and opens a **holographic phone interface** that displays “tasks.”  
   - Tasks can be **dragged and dropped** between sections (drag logic partially functional, further logic in progress).  

---

## 🔹 Additional Details  
- Environment: **UBCO_Courtyard_v2.unitypackage**  
- Render Pipeline: **Universal Render Pipeline (URP)**  
- XR Setup: **XR Interaction Toolkit**, **OpenXR Plugin**, **XR Hands/Controllers Package**  
- Platform Target: **Android – Meta Quest 2/3**  
- Scripts Implemented:  
  - `TaskPhoneManager.cs` – Manages Phone UI and drag-drop logic  
  - `customButtonEvent.cs` – Handles button interactions and color changes  
  - `notificationScript.cs` – Positions the notification relative to camera rotation  
  - `NotificationUIHandler.cs` – Opens the Phone UI on notification click  

---

## 📂 Repository Contents  
### 📁 Scripts  
Located under `Assets/Scripts/`  
- `TaskPhoneManager.cs` – Manages Phone UI and drag-drop logic  
- `NotificationUIHandler.cs` – Opens the Phone UI when notification is clicked  
- `notificationScript.cs` – Positions the notification relative to camera rotation  
- `UIButtonHandler.cs` – Useless test file
- `customButtonEvent.cs` – Controls cube color change button interactions  
- `animateHandOnScript.cs` – Controls hand animation behavior  

### 🧭 UI & Styles  
Located under `Assets/UI/` and `Assets/Stylesheets/`  
- `.uxml` → UI layout documents for the phone interface and buttons  
- `.uss` → Stylesheets defining colors, grid layouts, and UI transitions  

### 🗺 Scenes
- `Assets/UBCO Courtyard Assets/Courtyard Setup.unity` → Main scene featuring the UBCO Courtyard  

---

## 🎥 Demo Video
<a href="https://www.youtube.com/shorts/CaXHpj8y2Ik" target="_blank">
  <img src="https://img.youtube.com/vi/CaXHpj8y2Ik/hqdefault.jpg" alt="Demo video thumbnail" />
</a> 

**YouTube Short - demo of all interactions.**

---

## 👤 Author  
**Aarav Gosalia**  
University of British Columbia – Okanagan  

