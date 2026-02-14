## [1.1.0] - 2026-02-14

* Updated target framework from .NET 6 to .NET 10.
* Modernized `ColorLogger` implementation for safer terminal detection and color reset behavior.
* Improved string chunking extension with argument validation and backward-compatible alias.

## [1.0.3] - 2022-02-21

* README.md updated.
## [1.0.2] - 2022-02-21

* In default, internal console do not support window width. Now, algorithm convert output target to console from terminal automatically with simple try-catch block if window width undefined or equal to zero(internal console returns it).

## [1.0.1] - 2022-02-20

* Support for console with simple text option, if console width is 0 (Console, not a terminal).

## [1.0.0] - 2022-02-18

* Initial version.
