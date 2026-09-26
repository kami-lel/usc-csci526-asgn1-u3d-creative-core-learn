# Unity Creative Core Learn AGENTS

## Project Overview & Pointers

This repo (`github.com/kami-lel/usc-csci526-asgn1-u3d-creative-core-learn`) holds both the source Unity project and the two exported WebGL builds it serves via GitHub Pages, one per Unity Creative Core Playable Deliverable. See [`CONTEXT.md`](CONTEXT.md) for the full layout and [`README.md`](README.md) for the live urls.

## Layout & Naming

- `Assets/`, `Packages/`, `ProjectSettings/` at repo root: the Unity source project. `Library/`, `Temp/`, `Logs/`, `.vs/`, `obj/` stay gitignored, never committed
- `Assets/_CreativeCoreLearn/Scenes/ChallengeCamerasScene.unity` and `Assets/_CreativeCoreLearn/Scenes/ChallengeUIScene.unity`: exactly one scene per chosen unit, never both units in one scene; PascalCase, `Challenge` prefix matching the build subfolder, `Scene` suffix; all authored assets live under the `Assets/_CreativeCoreLearn/` root
- unit-specific assets go in `Assets/_CreativeCoreLearn/Cameras/` or `Assets/_CreativeCoreLearn/UI/`; create `Assets/_CreativeCoreLearn/Shared/` only when both scenes truly reuse an asset; `Settings/` (URP assets, input actions) is shared by both
- keep the original screen space UI intact: the UI unit's world space scene is a converted duplicate, never an overwrite
- one build subfolder per unit at repo root, PascalCase, prefixed `Challenge` (`ChallengeCameras/`, `ChallengeUI/`), matching Unity's own "Challenge: ..." naming for the Playable Deliverable lesson
- each `Challenge*/` subfolder is a complete, self-contained WebGL export: never share a `Build/` folder or `TemplateData/` between units, each export is independent
- a root `index.html` links to both `Challenge*/` urls; this sits alongside the Unity project files, not inside `Assets/`

## Setup Commands

Export a unit's WebGL build (run from the Unity Editor, from this repo's own Unity project):

1. open this repo as the Unity project, switch the active scene to the unit's scene (e.g. `Assets/_CreativeCoreLearn/Scenes/ChallengeCamerasScene.unity`)
2. `File > Build Settings`: enable only that unit's scene in the scene list, so the other unit's scene never lands in the export
3. `File > Build Settings > WebGL > Build`, output directly into this repo's matching `Challenge*/` subfolder (e.g. `ChallengeCameras/`)
4. confirm the subfolder now contains `index.html`, `Build/`, `TemplateData/`, `StreamingAssets/` (if used)

Publish (run from this repo):

```bash
git add ChallengeCameras/ Assets/_CreativeCoreLearn/Scenes/ChallengeCamerasScene.unity  # or whichever unit was rebuilt
git commit
git push
```

GitHub Pages serves automatically once enabled (`Settings > Pages > Deploy from branch`, root of `main`). No build step runs on GitHub; the committed WebGL export is served as-is, unrelated to the versioned `Assets/` source.

## Code Style

Scene and script conventions follow standard Unity C# practice; this repo carries no other source language. Never hand-edit a file inside a `Challenge*/` build subfolder; re-export from Unity and re-commit instead.

## Testing Instructions

Before pushing a rebuilt `Challenge*/` subfolder, serve it locally and load it in a browser (WebGL will not run from `file://`):

```bash
python3 -m http.server 8000 --directory ChallengeCameras
```

Confirm the scene loads, runs without console errors, and meets that unit's Playable Deliverable rubric criteria (see [`CONTEXT.md`](CONTEXT.md)) before committing.

## PR & Commit Instructions

Solo submission repo; commit directly to `main`. Commit message states which unit changed, source scene or build, and why (e.g. "Cameras: adjust FOV to match source shot, rebuild ChallengeCameras"). Never mix a source-scene edit or a rebuilt subfolder for one unit with an unrelated unit's changes in one commit.

## Security Considerations

- never commit `UserSettings/`, Unity license files, or personal Unity Hub credentials
- both `Assets/` and the `Challenge*/` builds are public once pushed; do not include personal information, API keys, or unpublished coursework from other assignments in a scene before committing or exporting

## Documentation Maintenance

Update [`README.md`](README.md)'s Live Deliverables urls if a `Challenge*/` subfolder or the repo itself is renamed. Update [`CONTEXT.md`](CONTEXT.md) if a third unit is added or a unit is swapped for a different one.
