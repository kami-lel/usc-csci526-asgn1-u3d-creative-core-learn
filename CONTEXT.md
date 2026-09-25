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
│   └── Scenes/
│       ├── Cameras.unity   source scene for the Cameras Playable Deliverable
│       └── UI.unity        source scene for the UI Playable Deliverable
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

## Domain Model

Not applicable: no data layer. The "entities" here are the two Playable Deliverable scenes, each independent and self-contained.

## Build & Run Commands

See [`AGENTS.md`](AGENTS.md) Setup Commands for the exact export and publish steps. In brief: build each scene to WebGL from the Unity Editor directly into its matching subfolder, then commit and push; GitHub Pages serves the committed output with no server-side build step.

## Deliverable Rubric (per unit)

**Cameras, "Recreate the scene":**

- set roughly resembles the set of the source shot
- camera position resembles that of the source shot
- camera FOV and perspective resemble those of the source shot

**UI, "Make a worldspace UI":**

- worldspace UI is present with a world position
- regular UI isn't disrupted by the worldspace UI

## Known Gaps & Constraints

- the pathway's "guided project" tutorials (any lesson titled with "guided project") are intentionally skipped per the assignment's own note; no guided-project scene exists in this repo or the source Unity project
- WebGL builds will not run over `file://`; always verify locally with a static file server (see [`AGENTS.md`](AGENTS.md) Testing Instructions) before trusting a build works
- GitHub Pages caches aggressively; after pushing a rebuilt subfolder, allow a few minutes and hard-refresh before assuming a stale build is a broken build
