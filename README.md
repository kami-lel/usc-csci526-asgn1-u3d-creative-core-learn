# Unity Creative Core Learn

<!--
Todo camera challenge
Todo UI challenge
-->

Playable builds for CSCI-526 Assignment 1's *Advanced Sequence*: two Unity Creative Core units, each with a browser-playable WebGL deliverable hosted from this repository via GitHub Pages.

## Project Overview

This repository holds both the source Unity project and the exported WebGL builds for two Unity Creative Core Playable Deliverables, submitted as part of Assignment 1's Advanced Sequence. Each unit's Playable Deliverable has its own scene under `Assets/` and its own published build subfolder, reachable at its own public url.

## Units Covered

- Cameras: recreate the scene, matching set, camera position, FOV, and perspective
- UI: worldspace UI, placed at a world position without disrupting regular UI

## Live Deliverables

- Cameras: `https://kami-lel.github.io/usc-csci526-asgn1-u3d-creative-core-learn/ChallengeCameras/`
- UI: `https://kami-lel.github.io/usc-csci526-asgn1-u3d-creative-core-learn/ChallengeUI/`

## Tech Stack

- Unity 6, Universal Render Pipeline (URP)
- WebGL build target
- GitHub Pages, static hosting

## Getting Started

- clone this repo (`git clone https://github.com/kami-lel/usc-csci526-asgn1-u3d-creative-core-learn.git`) and open it as a Unity project to edit either scene
- each `Challenge*/` subfolder is a self-contained WebGL build; open its `index.html` locally over a simple http server (WebGL builds do not run from `file://`) to preview before publishing

## Setup

Open the repo as a Unity project, switch the active scene to the unit being rebuilt, then export via `File > Build Settings > WebGL > Build` directly into that unit's `Challenge*/` subfolder before committing and pushing.

## Usage

- visit either live url above to play a deliverable directly in the browser
- no install needed for viewers; WebGL runs in any modern browser

## Contributing

This is a solo coursework submission; no external contributions expected.
