Out.txt : main.exe input_table.txt Makefile
	mono $< < input_table.txt 1> Out.txt 2>> log

main.exe : main.cs genlist.dll
	mcs -out:$@ -target:exe -reference:genlist.dll main.cs

genlist.dll : genlist.cs
	mcs -out:$@ -target:library genlist.cs
clean:
	$(RM) *.dll *.exe log* [Oo]ut*