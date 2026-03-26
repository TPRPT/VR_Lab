<p align="center">
  <a href="https://youtu.be/ezs79PpAFS0">
    <img src="http://img.youtube.com/vi/ezs79PpAFS0/0.jpg" alt="Demo">
  </a>
</p>

# 🍕 Ding Dong, Pizza!

A VR motorcycle delivery game developed during an exchange program in Germany.  
Players ride through a virtual city and deliver pizzas to designated locations within a limited time.

---

## 🎥 Demo Video
https://youtu.be/ezs79PpAFS0

---

## 🧠 Project Background
This project was developed as part of  
**HKA VR Lab – Virtual Reality for Industrial Application (IP 426, Summer 2024)**.

Originally designed as a team project, the final implementation was completed individually.

The goal was to create an immersive VR experience simulating motorcycle driving and delivery tasks.

---

## 🎮 Gameplay
- Navigate a small city using a motorcycle  
- Use an in-game **map** to locate delivery points  
- Delivery targets are marked with **blue pillars**  
- Reach the destination before time runs out  

### ✅ Success
- Deliver all pizzas within the time limit  

### ❌ Failure
- Time runs out before completing deliveries  

---

## 🎮 VR Interaction Design

### 🕹️ Movement
- **Right Trigger** → Move Forward  
- **Left Trigger** → Move Backward  

### 🏍️ Steering (Key Feature)
- Steering is calculated based on the **relative position of both hands**  
- Simulates real motorcycle handle movement  

This interaction is implemented using vector projection and dot product calculations in VR space.

---

## 🛠️ Technical Implementation

### VR Input System
- Built using **VIVE Input Utility**  
- Trigger input controls acceleration and deceleration  

### Motorcycle Physics
- Arcade-style physics using Rigidbody  
- Includes:
  - Acceleration and braking  
  - Tilt and steering dynamics  
  - Wheel rotation and engine sound feedback  

### UI System
- Center message display with timed reset  

### Game Reset
- Scene restart using VR controller input  

---

## 🧩 Assets & Environment
- Motorcycle model from Unity Asset Store  
- City environment package for urban layout  
- Custom placement of delivery points and UI elements  

---

## 🚀 How to Run

### Requirements
- Unity (2022.3 or later recommended)  
- VR Headset (HTC Vive or compatible)  
- SteamVR  

### Steps
1. Clone the repository  
2. Open the project in Unity Hub  
3. Open the main scene  
4. Press Play or build for VR  

---

## ⚠️ Notes
- Originally built with an older Unity version  
- Upgrading may require:
  - API updates  
  - VR plugin compatibility fixes  
