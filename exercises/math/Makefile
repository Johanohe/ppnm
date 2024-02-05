Out.txt : main.exe # Depends on main.exe, tries to find how to build main.exe
	mono main.exe > Out.txt

main.exe : main.cs sfuns.dll
	mcs -target:exe -reference:sfuns.dll -out:main.exe main.cs # target can be exe or library. Target, out arguments are standard

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

clean:
	$(RM) sfuns.dll main.exe Out.txt # built in rm -f
