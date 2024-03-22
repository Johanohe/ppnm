LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : all plots

all : directories plots

plots : HydrogenDrData.gnuplot.svg HydrogenRmData.gnuplot.svg WavefunctionData.gnuplot.svg

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

HydrogenDrData.gnuplot.svg : HydrogenDrData.gpi HydrogenDrData.txt ; gnuplot $<

HydrogenRmData.gnuplot.svg : HydrogenRmData.gpi HydrogenRmData.txt ; gnuplot $<

WavefunctionData.gnuplot.svg : WavefunctionData.gpi WavefunctionData.txt ; gnuplot $<

data/Out.txt : main.exe
	mono $< > $@

data/HydrogenExact.txt : HydrogenExact.exe
	mono $< > $@
data/WavefunctionData.txt : WavefunctionData.exe
	mono $< > $@

data/HydrogenDrData.txt : HydrogenData.exe
	mono HydrogenData.exe -dr:0 -rmax:10 > $@

data/HydrogenRmData.txt : HydrogenData.exe
	mono HydrogenData.exe -dr:0.1 -rmax:0 > $@


HydrogenExact.exe : HydrogenExact.cs ; $(MKEXE)

WavefunctionData.exe : WavefunctionData.cs Hydrogen.dll matrix.dll vector.dll ; $(MKEXE)

HydrogenData.exe : HydrogenData.cs Hydrogen.dll ; $(MKEXE)

Hydrogen.dll : Hydrogen.cs Jacobi.dll matrix.dll vector.dll ; $(MKLIB)

main.exe : Main.cs matrix.dll vector.dll Jacobi.dll ; $(MKEXE)

Jacobi.dll : Jacobi.cs matrix.dll vector.dll ; $(MKLIB)

clean :
	rm -f *.dll *.exe data/* plots/*