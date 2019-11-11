# Infernal Robotics :: Change Log

* 2018-0403: 3.0.0-beta2p1 (Rudolf Meier) for KSP 1.2.2 PRE-RELEASE
	+ No changelog provided
* 2018-0330: 3.0.0-beta2 (Rudolf Meier) for KSP 1.2.2 PRE-RELEASE
	+ Beta of project "Next", almost done...
	+ Includes the "rework" parts but not KJR. For best results use my version of KJR at version 3.4.0 or higher.
* 2017-1023: 2.0.14 (ZiwKerman) for KSP 1.2 compatible release
	+ This is just a GUI bugfix by @SpannerMonkey
* 2017-1013: 2.0.13 (ZiwKerman) for KSP 1.2 compatible release
	+ Just a recompile.
* 2017-0606: 2.0.12 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ Thanks to @matthewreiter
* 2017-0530: 2.0.11 (ZiwKerman) for KSP 1.2 compatible release
	+ (Almost) No code changes, just a recompile for 1.3
	+ Turn off auto-struts, or the parts won't move in flight. If you want to use KJR, make sure you have latest version that supports IR. For more trouble shooting visit the forum page.
* 2016-1215: 2.0.10 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ Fixes bugs introduced in 2.0.9. Might still have issues, but we're getting there.
	+ As usual, if you need parts - get them here: https://github.com/MagicSmokeIndustries/InfernalRobotics/releases/download/2.0.0/IR-LegacyParts.zip
* 2016-1213: 2.0.9 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ BETA VERSION, USE WITH CAUTION
	+ Get the parts here if you need them: https://github.com/MagicSmokeIndustries/InfernalRobotics/releases/download/2.0.0/IR-LegacyParts.zip
* 2016-1124: 2.0.8 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ Requires more testing, but it seems I've found a proper workaround.
	+ BETA RELEASE, NO PARTS HERE, USE YOUR OLD PARTS
* 2016-1030: 2.0.7 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ Requires Clean-ish Install
	+ Leave the Parts subfolder, but please delete the MagicSmokeIndustries/AssetBundles subfolder before installing.
* 2016-1018: 2.0.6 (ZiwKerman) for KSP 1.2 compatible release PRE-RELEASE
	+ Update for KSP 1.2
	+ It might still have some glitches, that is why it is beta and needs more testing.
	+ No new features, but some annoying bugs fixed in this release.
	+ PLEASE REMEMBER TO TURN OFF AUTO-STRUTS OR PARTS WON'T MOVE
* 2016-0709: 2.0.5 (ZiwKerman) for KSP 1.1.3
	+ Recompile for KSP 1.1.3
* 2016-0515: 2.0.4 (ZiwKerman) for KSP 1.1.2
	+ Fixes mirror symmetry movement direction inconsistency between SPH/VAB and Flight mode. Thanks to Auranapse
	+ Fixes servo range not showing right after toggling in UI for rotating parts, thanks to @Mogeley on github.
	+ More auto-struts handling fixes. Thanks to Mine_Turtle and Nimelrian
* 2016-0511: 2.0.3 (ZiwKerman) for KSP 1.1.2
	+ Proper approach for handling wheel auto-struts
	+ Fix some log spam from UI
	+ Fix the Group name bug, where newly created groups needed to be renamed first to be properly saved in the craft.
* 2016-0505: 2.0.2 (ZiwKerman) for KSP 1.1.2
	+ Fix for unnecessary EC consumption for uncontrolled parts.
* 2016-0505: 2.0.2 (ZiwKerman) for KSP 1.1.2
	+ Fix for unnecessary EC consumption for uncontrolled parts.
* 2016-0504: 2.0.1 (ZiwKerman) for KSP 1.1.2
	+ This small patch addresses some small UI and QoL related issues. Compiled for KSP 1.1.2
		- UI Windows are now clamped to screen on initialisation, so you will not loose them if you change resolution or move them of the screen accidentally
		- IR Build Aid now shows all the presets in a more clean way
		- IR Build Aid color scheme is now more in line with IR color scheme
		- Added option to toggle IR Build Aid for the group of servos
		- Fixed a bug that made Settings window invisible
		- Fixed a bug with uncontrolled hinges loosing orientation after scene change
		- Fixes to avoid wheel auto-struts get in the way of IR moving parts
		- Fixes for mirror symmetry parts not working. This fix might invert some Legacy parts' default movement direction, but it is easily fixed by inverting the axis where needed.
		- Some other very minor changes.
	+ Core zip only includes an updated version of plugin and related files and is a recommended way of updating.
	+ Full zip also includes Legacy Parts in case you need them.
* 2016-0424: 2.0.0 (ZiwKerman) for KSP 1.1
	+ Upgrading from 0.21.x REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 (built for KSP 1.1 build 1230)
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay, with current and default positions and all the presets.
		- Change servo position in editor by Ctrl-Click-Dragging the parts on the craft.
		- Settings window to control UI scale and transparency and some other options.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Added HostPart to the API for Servo
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
* 2016-0424: 2.0.0-rc3 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ In this version:
		- IR Build Aid improvements: now shows preset positions and indicates Positive direction via line color (from orange to greenish yellow)
		- Fixed a bug when dragging and dropping a servo to the very end of the last group did not register as group change.
		- Made an explicit button in flight editor to return to control window.
		- Some other cosmetic changes.
	+ Known Issue:
		- Uncontrolled parts (docking washer) seem to freeze in flight mode when placed in Mirror Symmetry mode. Use Radial symmetry or place them separately to avoid this bug.
	+ Reminder: parts are not packed, use the separate link in RC1 release or use alternative packs.
* 2016-0422: 2.0.0-rc2 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ Bugfixes mostly.
* 2016-0421: 2.0.0-rc1 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ Upgrading from 0.21.x REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 release candidate, built for KSP 1.1 build 1230
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay
		- Drag and Move servos in editor by holding Left-Ctrl while clicking on a servo and dragging.
		- Settings window to control UI scale and transparency.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Changes from beta4:
		- A bit less log spam
		- Different approach to loading a bundle
		- Added HostPart to the API for Servo
		- Fix inverted Servo movement with Ctrl-Grab
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
* 2016-0420: 2.0.0-beta4 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ No changelog provided
* 2016-0417: 2.0.0-beta3 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ No changelog provided
* 2016-0416: 2.0.0-beta2 (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ Here is a quick rebuild for 1209  with a couple of minor bugs fixed.
* 2016-0415: 2.0.0-beta (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 open beta release, built for KSP 1.1-pre build 1203
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay
		- Drag and Move servos in editor by holding Left-Ctrl while clicking on a servo and dragging.
		- Settings window to control UI scale and transparency.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
	+ This is a beta version for a pre-release version 1.1 of KSP, so there WILL be bugs. Please report bugs and ask questions in the official thread on KSP forums.
* 2016-0330: 2.0.0-alpha (ZiwKerman) for KSP 1.1 PRE-RELEASE
	+ This is purely to test out the main code for compatibility with KSP 1.1 pre-release while I re-do all the UI stuff.
	+ Legacy Parts are NOT included, please copy them over from 0.21.4 or (better) use Zodius Rework parts (except for wheels, they are broken in 1.1).
* 2016-0302: 0.21.5-pre (ZiwKerman) for KSP 1.0.2 PRE-RELEASE
	+ Replace your MagicSmokeIndustries/Plugins/InfernalRobotics.dll with this one.
	+ Also fixes Interpolation snapping error ea high accelerations
* 2015-1111: 0.21.4 (ZiwKerman) for KSP 1.0.2
	+ Recompile for 1.0.5
* 2015-0626: 0.21.3 (ZiwKerman) for KSP 1.0.2
	+ Bugfix release
		- Recompile for 1.0.4
		- Fixes for tweakscale interaction for transalting IR parts
		- Better handling of symmetry for presets and other settings.
		- FAR compatibility: FAR is notified when the IR parts have changed their position so it can recalculate voxel model accordingly.
		- Better input handling for all textfields, makes typing in desired values much easier.
		- Proper handling of New button in editor.
		- Fixes for KIS/KAS attached IR parts to function properly.
		- Minor changes to API implementation of UID field.
* 2015-0515: 0.21.3-rc (ZiwKerman) for KSP 1.0.2 PRE-RELEASE
	+ New Features:
		- Apply Symmetry button to apply servo limits to symmetry counterparts
		- nuFAR compatibility - Infernal Robotic parts will now inform nuFar of the position changes, so it can rebuild the voxel model
	+ Fixes:
		- TweakScale interaction fixes for translating parts
		- Very minor API implementation fix for IRServo.UID
		- Preset editing is a bit more user-friendly now (values are parsed on focus change instead of every frame).
* 2015-0506: 0.21.2 (ZiwKerman) for KSP 1.0.2
	+ v 0.21.2 Changes
		- Made our AppLauncher icon follow the same behaviour as when blizzy's toolbar installed and only show when there are robotic parts on the craft in flight. Editor button is still always visible.
		- Fixed .version file
		- Updated KSPAPIExtensions.dll dependency
		- Converted Legacy parts textures to DDS
		- Rearranged Legacy parts position in tech tree.
		- Added support for CTT for Legacy parts.
* 2015-0430: 0.21.1 (ZiwKerman) for KSP 1.0 compatibility
	+ Includes hotfix for toolbar button.
* 2015-0428: 0.00 (ZiwKerman) for KSP 0.7.3 PRE-RELEASE
	+ Works with 1.0!
		- New part category icons
		- Bugfix for engage limits
* 2016-0504: 2.0.1 (sirkut) for KSP 1.1.2
	+ This small patch addresses some small UI and QoL related issues. Compiled for KSP 1.1.2
		- UI Windows are now clamped to screen on initialisation, so you will not loose them if you change resolution or move them of the screen accidentally
		- IR Build Aid now shows all the presets in a more clean way
		- IR Build Aid color scheme is now more in line with IR color scheme
		- Added option to toggle IR Build Aid for the group of servos
		- Fixed a bug that made Settings window invisible
		- Fixed a bug with uncontrolled hinges loosing orientation after scene change
		- Fixes to avoid wheel auto-struts get in the way of IR moving parts
		- Fixes for mirror symmetry parts not working. This fix might invert some Legacy parts' default movement direction, but it is easily fixed by inverting the axis where needed.
		- Some other very minor changes.
	+ Core zip only includes an updated version of plugin and related files and is a recommended way of updating.
	+ Full zip also includes Legacy Parts in case you need them.
* 2016-0424: 2.0.0 (sirkut) for KSP 1.1
	+ Upgrading from 0.21.x REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 (built for KSP 1.1 build 1230)
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay, with current and default positions and all the presets.
		- Change servo position in editor by Ctrl-Click-Dragging the parts on the craft.
		- Settings window to control UI scale and transparency and some other options.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Added HostPart to the API for Servo
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
* 2016-0424: 2.0.0-rc3 (sirkut) for KSP 1.1 PRE-RELEASE
	+ In this version:
		- IR Build Aid improvements: now shows preset positions and indicates Positive direction via line color (from orange to greenish yellow)
		- Fixed a bug when dragging and dropping a servo to the very end of the last group did not register as group change.
		- Made an explicit button in flight editor to return to control window.
		- Some other cosmetic changes.
	+ Known Issue:
		- Uncontrolled parts (docking washer) seem to freeze in flight mode when placed in Mirror Symmetry mode. Use Radial symmetry or place them separately to avoid this bug.
	+ Reminder: parts are not packed, use the separate link in RC1 release or use alternative packs.
* 2016-0422: 2.0.0-rc2 (sirkut) for KSP 1.1 PRE-RELEASE
	+ Bugfixes mostly.
* 2016-0421: 2.0.0-rc1 (sirkut) for KSP 1.1 PRE-RELEASE
	+ Upgrading from 0.21.x REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 release candidate, built for KSP 1.1 build 1230
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay
		- Drag and Move servos in editor by holding Left-Ctrl while clicking on a servo and dragging.
		- Settings window to control UI scale and transparency.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Changes from beta4:
		- A bit less log spam
		- Different approach to loading a bundle
		- Added HostPart to the API for Servo
		- Fix inverted Servo movement with Ctrl-Grab
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
* 2016-0420: 2.0.0-beta4 (sirkut) for KSP 1.1 PRE-RELEASE
	+ No changelog provided
* 2016-0417: 2.0.0-beta3 (sirkut) for KSP 1.1 PRE-RELEASE
	+ No changelog provided
* 2016-0416: 2.0.0-beta2 (sirkut) for KSP 1.1 PRE-RELEASE
	+ Here is a quick rebuild for 1209  with a couple of minor bugs fixed.
* 2016-0415: 2.0.0-beta (sirkut) for KSP 1.1 PRE-RELEASE
	+ REQUIRES CLEAN INSTALL (Delete old MagicSmokeIndustries Folder in your GameData folder)
	+ Infernal Robotics 2.0 open beta release, built for KSP 1.1-pre build 1203
	+ New Features:
		- Redesigned UI to Unity5 UI
		- IR Build Aid - turn on visual aid in VAB/SPH to see servo range overlay
		- Drag and Move servos in editor by holding Left-Ctrl while clicking on a servo and dragging.
		- Settings window to control UI scale and transparency.
	+ Minor changes:
		- Uncontrolled servos can be moved to position (VAB/SPH only)
		- Servo movement in VAB/SPH now obeys speed settings for servo.
		- Module renamed to ModuleIRServo, but has an alias for MuMechToggle for backwards compatibility. We encourage all part makers to change the name in part.cfg at their earliest convenience.
	+ Important notice!
	+ Legacy Parts are now a separate download. Core of the mod is distributed partless.
	+ This is a beta version for a pre-release version 1.1 of KSP, so there WILL be bugs. Please report bugs and ask questions in the official thread on KSP forums.
* 2016-0330: 2.0.0-alpha (sirkut) for KSP 1.1 PRE-RELEASE
	+ This is purely to test out the main code for compatibility with KSP 1.1 pre-release while I re-do all the UI stuff.
	+ Legacy Parts are NOT included, please copy them over from 0.21.4 or (better) use Zodius Rework parts (except for wheels, they are broken in 1.1).
* 2016-0302: 0.21.5-pre (sirkut) for KSP 1.0.2 PRE-RELEASE
	+ Replace your MagicSmokeIndustries/Plugins/InfernalRobotics.dll with this one.
	+ Also fixes Interpolation snapping error ea high accelerations
* 2015-1111: 0.21.4 (sirkut) for KSP 1.0.2
	+ Recompile for 1.0.5
* 2015-0626: 0.21.3 (sirkut) for KSP 1.0.2
	+ Bugfix release
		- Recompile for 1.0.4
		- Fixes for tweakscale interaction for transalting IR parts
		- Better handling of symmetry for presets and other settings.
		- FAR compatibility: FAR is notified when the IR parts have changed their position so it can recalculate voxel model accordingly.
		- Better input handling for all textfields, makes typing in desired values much easier.
		- Proper handling of New button in editor.
		- Fixes for KIS/KAS attached IR parts to function properly.
		- Minor changes to API implementation of UID field.
* 2015-0515: 0.21.3-rc (sirkut) for KSP 1.0.2 PRE-RELEASE
	+ New Features:
		- Apply Symmetry button to apply servo limits to symmetry counterparts
		- nuFAR compatibility - Infernal Robotic parts will now inform nuFar of the position changes, so it can rebuild the voxel model
	+ Fixes:
		- TweakScale interaction fixes for translating parts
		- Very minor API implementation fix for IRServo.UID
		- Preset editing is a bit more user-friendly now (values are parsed on focus change instead of every frame).
* 2015-0506: 0.21.2 (sirkut) for KSP 1.0.2
	+ v 0.21.2 Changes
		- Made our AppLauncher icon follow the same behaviour as when blizzy's toolbar installed and only show when there are robotic parts on the craft in flight. Editor button is still always visible.
		- Fixed .version file
		- Updated KSPAPIExtensions.dll dependency
		- Converted Legacy parts textures to DDS
		- Rearranged Legacy parts position in tech tree.
		- Added support for CTT for Legacy parts.
* 2015-0430: 0.21.1 (sirkut) for KSP 1.0 compatibility
	+ Includes hotfix for toolbar button.
* 2015-0428: 0.00 (sirkut) for KSP 0.7.3 PRE-RELEASE
	+ Works with 1.0!
		- New part category icons
		- Bugfix for engage limits
