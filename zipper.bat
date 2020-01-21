del "C:\Proyectos VB.Net\AzzeramentoTrilogis\*.zip" /s /q
xcopy /s "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output" "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\"
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.config" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.application" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.manifest" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.pdb" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.ini" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.xml" /s /q
del "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.lnk" /s /q
@RD /S /Q "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\Logs"
@RD /S /Q "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\app.publish"
"C:\Program Files\7-Zip\7z" a -tzip "C:\Proyectos VB.Net\AzzeramentoTrilogis\AzzeramentoTrilogis.zip" "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2\*.*" -mx5
"C:\Program Files\7-Zip\7z" x "C:\Proyectos VB.Net\AzzeramentoTrilogis\AzzeramentoTrilogis.zip" -o"C:\Proyectos VB.Net\AzzeramentoTrilogis\AzzeramentoTrilogis" -aoa
@RD /S /Q "C:\Proyectos VB.Net\AzzeramentoTrilogis\Output2"
echo File AzzeramentoTrilogis.zip / Cartella AzzeramentoTrilogis creati
start %windir%\explorer.exe "C:\Proyectos VB.Net\AzzeramentoTrilogis\AzzeramentoTrilogis" 