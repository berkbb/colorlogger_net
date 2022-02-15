// See https://aka.ms/new-console-template for more information
using ColorLoggerLibrary;

ColorLogger logger = new ColorLogger();
logger.Print("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", LogLevel.debug);
logger.Print("hello world !", LogLevel.verbose);
logger.Print("love dotnet :)", LogLevel.info);
logger.Print("hey check that!", LogLevel.warning);
logger.Print("please use c# !", LogLevel.error);
logger.Print("dotnet rocks !", LogLevel.unknown);
