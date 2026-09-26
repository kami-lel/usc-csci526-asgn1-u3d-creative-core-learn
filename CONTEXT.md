# Unity Creative Core Learn CONTEXT

## Project Overview

CSCI-526 Assignment 1 offers a choice between a Beginner Sequence and an Advanced Sequence; this repo backs the Advanced Sequence choice. The Advanced Sequence requires completing any two units of Unity's Creative Core Pathway, tutorials and quiz included, and publishing each unit's Playable Deliverable (a standalone scene, not the pathway's "guided project," which the assignment explicitly waives) as a public url on GitHub Pages or Unity Play. This repo holds both halves of that requirement: the source Unity project itself, and the two exported WebGL build subfolders GitHub Pages serves.

| | |
|---|---|
| Course | CSCI-526, Advanced Mobile Devices and Game Consoles |
| Assignment | Assignment 1, Section 1, Advanced Sequence |
| Pathway | Unity Creative Core (`learn.unity.com/pathway/creative-core`) |
| Units chosen | Cameras, UI |
| Hosting | GitHub Pages, one subfolder per unit |

## Repository Layout

```
.
├── Assets/                 Unity source project: scenes, scripts, imported assets
│   └── _CreativeCoreLearn/    authored-asset root
│       ├── Scenes/
│       │   ├── ChallengeCamerasScene.unity   source scene for the Cameras Playable Deliverable
│       │   └── ChallengeUIScene.unity        source scene for the UI Playable Deliverable (planned)
│       ├── Cameras/           assets used only by the Cameras scene (planned)
│       ├── UI/                assets used only by the UI scene (planned)
│       ├── Shared/            assets reused by both scenes, created only if needed (planned)
│       └── Settings/          URP assets, input actions, shared by both scenes
├── Packages/                Unity package manifest and lock file
├── ProjectSettings/         Unity project settings (versioned; Library/ and Temp/ are not)
├── index.html                landing page, links both builds below
├── ChallengeCameras/          WebGL export of the Cameras Playable Deliverable
│   ├── index.html
│   ├── Build/
│   ├── TemplateData/
│   └── StreamingAssets/    if present
└── ChallengeUI/               WebGL export of the UI Playable Deliverable
    ├── index.html
    ├── Build/
    ├── TemplateData/
    └── StreamingAssets/    if present
```

The Unity source project and its two exported WebGL builds now live in the same repo. One project, one scene per chosen unit, since Creative Core units share no state between them; each scene builds independently into its matching subfolder.

### Scene Organization

Two scenes for two units, decided over a single combined scene: the units share no state, each ships as its own WebGL export, and the UI rubric ("regular UI isn't disrupted by the worldspace UI") would be muddied by Cameras content sharing the space.

- Scene Naming: `Challenge<Unit>Scene`, mirroring the `Challenge<Unit>/` build folder
- Asset Placement: unit-only assets in `Cameras/` or `UI/`, cross-scene assets in `Shared/`, render pipeline config in `Settings/`
- Build Settings: enable only the unit's own scene per export, so each build starts on the right scene
- UI Scene Origin: converted duplicate of the screen space UI scene, the screen space original stays untouched
- Cameras Reference: keep the reference screenshot inside `Cameras/`, so the comparison shot travels with the source

## Domain Model

Not applicable: no data layer. The "entities" here are the two Playable Deliverable scenes, each independent and self-contained.

## Build & Run Commands

See [`AGENTS.md`](AGENTS.md) Setup Commands for the exact export and publish steps. In brief: build each scene to WebGL from the Unity Editor directly into its matching subfolder, then commit and push; GitHub Pages serves the committed output with no server-side build step.

## Deliverable Rubric (per unit)

**Cameras, "Recreate the scene":**

- set roughly resembles the set of the source shot
- camera position resembles that of the source shot
- camera FOV and perspective resemble those of the source shot

Unity's own challenge criterion (the lesson's "Criteria" step): the scene is recognizable when placed next to a screenshot of the original scene.

Lesson setup notes that shape the scene:

- pick a favorite shot from media (a dynamic scene) and screenshot it as the reference image
- rebuild the set pieces from primitives, or from Unity Asset Store assets
- then recreate the camera setup (position, FOV, projection) to match the reference
- screenshot the finished shot to compare against the reference
- optional bonus: apply the Lighting and VFX skills to match the reference more closely
- expected effort: at least 30 minutes

**UI, "Make a worldspace UI":**

- worldspace UI is present with a world position
- regular UI isn't disrupted by the worldspace UI

Unity's own challenge criteria (the lesson's "Challenge criteria" step); the world space UI must:

- use the World Space canvas render mode
- be designed and positioned in interesting ways in world space
- retain its full functionality (settings button shows the settings menu, all menu items work)

Lesson setup notes that shape the scene:

- the lesson builds on the screen space UI from the earlier UI tutorials (title, anchors, menu background, buttons, toggles, sliders); duplicate that scene, then convert the copy, so the original screen space UI stays intact
- Canvas Render Mode → World Space, with the Main Camera assigned to Event Camera
- Canvas Rect Transform: scale `0.03, 0.03, 0.03`, position reset to `0, 0, 0` as a starting point
- the camera and scene objects may need reorienting so the UI reads well
- optional stretch: smooth camera movement that highlights the world space aspect
- expected effort: at least 30 minutes

## Known Gaps & Constraints

- the pathway's "guided project" tutorials (any lesson titled with "guided project") are intentionally skipped per the assignment's own note; no guided-project scene exists in this repo or the source Unity project
- WebGL builds will not run over `file://`; always verify locally with a static file server (see [`AGENTS.md`](AGENTS.md) Testing Instructions) before trusting a build works
- GitHub Pages caches aggressively; after pushing a rebuilt subfolder, allow a few minutes and hard-refresh before assuming a stale build is a broken build
