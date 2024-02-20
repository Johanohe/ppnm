CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

plots : Erf.gnuplot.svg Gamma.gnuplot.svg LnGamma.gnuplot.svg

Erf.gnuplot.svg : erfplotting.gpi Out.txt Makefile
	gnuplot $<

Gamma.gnuplot.svg : gammaplotting.gpi GammaOut.txt factorial.data.txt Makefile
	gnuplot $<

LnGamma.gnuplot.svg : lngammaplotting.gpi LnGammaOut.txt Makefile
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

GammaOut.txt : gammaMain.exe
	mono $< > $@

LnGammaOut.txt : lngammaMain.exe
	mono $< > $@

sfuns.dll : sfuns.cs ; $(MKLIB)

main.exe : main.cs sfuns.dll ; $(MKEXE)

gammaMain.exe : gammaMain.cs sfuns.dll ; $(MKEXE)

lngammaMain.exe : lngammaMain.cs sfuns.dll ; $(MKEXE)

clean: 
	$(RM) *Out.txt *.svg *.exe *.dll