LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


plots/Plot.svg : Plot.gpi PlotData.txt ; gnuplot $<

data/PlotData.txt : PlotData.exe ; mono $< > $@

PlotData.exe : PlotData.cs LinInt.dll vector.dll ; $(MKEXE)

LinInt.dll : LinInt.cs vector.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*