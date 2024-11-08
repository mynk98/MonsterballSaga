#!/bin/bash

# Create the main Assets directory
mkdir -p Assets

# Create the Scripts directory and its subdirectories
mkdir -p Assets/Scripts/{Components,Systems,Authoring,Bootstrap}

# Create Component scripts
touch Assets/Scripts/Components/BallComponents.cs
touch Assets/Scripts/Components/InputComponents.cs
touch Assets/Scripts/Components/GameComponents.cs

# Create System scripts
touch Assets/Scripts/Systems/BallSystem.cs
touch Assets/Scripts/Systems/CameraSystem.cs
touch Assets/Scripts/Systems/InputSystem.cs

# Create Authoring script
touch Assets/Scripts/Authoring/BallAuthoring.cs

# Create Bootstrap script
touch Assets/Scripts/Bootstrap/GameBootstrap.cs

# Create Prefabs directory and Ball prefab
mkdir -p Assets/Prefabs
touch Assets/Prefabs/Ball.prefab

# Create Scenes directory and MainScene
mkdir -p Assets/Scenes
touch Assets/Scenes/MainScene.unity

# Create Materials directory and BallMaterial
mkdir -p Assets/Materials
touch Assets/Materials/BallMaterial.mat

echo "Unity ECS project structure created successfully!"