;SteelQuiz Setup Script
;NSIS Modern User Interface
;Based on Basic Example Script by Joost Verburg

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "SteelQuiz"
  OutFile "SteelQuizSetup.exe"

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\SteelQuiz"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\SteelQuiz" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "..\LICENSE_INCLUDING_3RD_PARTY"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "SteelQuiz" SecSteelQuiz

  ;Required
  SectionIn RO 
  
  SetOutPath "$INSTDIR"
  
  ;Files
  File "..\SteelQuiz\bin\Release\SteelQuiz.exe"
  File "..\SteelQuiz\bin\Release\Newtonsoft.Json.dll"
  File "..\SteelQuiz\bin\Release\AutoUpdater.NET.dll"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\SteelQuiz" "" $INSTDIR
  
  ;Write the uninstall keys for Windows
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "DisplayName" "SteelQuiz"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "NoModify" 1
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "NoRepair" 1
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

Section "Start Menu Shortcuts" SecStartMenuShortcuts
  ;Create start menu shortcuts
  CreateDirectory "$SMPROGRAMS\SteelQuiz"
  CreateShortcut "$SMPROGRAMS\SteelQuiz\SteelQuiz.lnk" "$INSTDIR\SteelQuiz.exe" "" "$INSTDIR\SteelQuiz.exe" 0
  CreateShortcut "$SMPROGRAMS\SteelQuiz\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecSteelQuiz ${LANG_ENGLISH} "SteelQuiz (required)"
  LangString DESC_SecStartMenuShortcuts ${LANG_ENGLISH} "Start Menu Shortcuts"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecSteelQuiz} $(DESC_SecSteelQuiz)
    !insertmacro MUI_DESCRIPTION_TEXT ${SecStartMenuShortcuts} $(DESC_SecStartMenuShortcuts)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;Delete shortcuts
  Delete "$SMPROGRAMS\SteelQuiz\*.*"
  RMDir "$SMPROGRAMS\SteelQuiz"
  
  ;Delete files
  Delete "$INSTDIR\SteelQuiz.exe"
  Delete "$INSTDIR\Newtonsoft.Json.dll"
  Delete "$INSTDIR\AutoUpdater.NET.dll"
  Delete "$INSTDIR\uninstall.exe"

  RMDir "$INSTDIR"

  ;Delete registry keys
  DeleteRegKey /ifempty HKCU "Software\SteelQuiz"
  DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz"

SectionEnd