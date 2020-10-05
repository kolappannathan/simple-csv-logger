# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [3.0.0] - 2020-10-05
### Added
 - Unit tests
 - CI via GitHub actions
 - CD via GitHub actions

### Changed
 - Changed API to .Net core 3
 - Minor code optimizations

## [2.1.0] - 2019-08-06
### Added
 - Created new funtion in config that returns full file path
 - Directories absent in relative path are now created
 - Added NuGet desc into version control

### Changed
 - GetFullFilename function now uses GetFullFilePath method

### Removed
 - Old NuGet packages

## [2.0.1] - 2019-07-05
### Changed
 - Fixing issuse with assigning replacement value

## [2.0.0] - 2019-07-04
### Added
 - New logger config object
 - New API to test logger

### Changed
 - Multiple comma replacement are merged into one
 - Initialization steps are moved from constructor into a separate function
 - Paramets to Logger are now replaced by config
 - Converted some functions to expression
 - Moved Log levels into separate class

### Removed
 - Redunant null checks

## [1.0.2] - 2019-06-28
### Added
 - Added new icons
 - Added changelog
 - Added nuget spec
### Changed
 - Updated ReadMe
 - Small changes to assignment of values in constructor
 - Reorganized some folders
### Removed
 - Removed signing from packages

## [1.0.1] - 2018-10-24
### Changed
 - Replaced static readonly variable with constants

## [1.0.0] - 2018-09-20
### Added
- Intial release