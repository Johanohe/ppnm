LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


plots/Plot.svg : Plot.gpi DebugData.txt ; gnuplot $<

data/DebugData.txt : DebugData.exe ; mono $< > $@

DebugData.exe : DebugData.cs RK.dll vector.dll ; $(MKEXE)

RK.dll : RK.cs vector.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*