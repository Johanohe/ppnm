Out.txt : main.exe Makefile
	mono $< > $@

main.exe : main.cs vec.dll
	mcs -target:exe -out:$@ -reference:vec.dll $<

vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	$(RM) main.exe Out.txt vec.dll