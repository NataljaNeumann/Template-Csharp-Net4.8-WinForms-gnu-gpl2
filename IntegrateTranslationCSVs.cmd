ResxVsCsv --directory Template\Forms --toresx CultureSelectionForm.csv
ResxVsCsv --directory Template\Forms --toresx NewMessageBox.csv
ResxVsCsv --directory Template\Forms --toresx MainForm.csv
ResxVsCsv --directory Template\Properties --toresx Resources.csv
cd Template\Forms
SortResourceKeys
cd ..\Properties
SortResourceKeys
pause
