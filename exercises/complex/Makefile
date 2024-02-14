Out.txt : main.exe Makefile
	mono $< > $@

main.exe : main.cs 
	mcs -target:exe -out:$@ -reference:System.Numerics.dll $<

clean:
	$(RM) main.exe Out.txt 