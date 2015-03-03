################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Each subdirectory must supply rules for building sources it contributes
audioSamplecfg.cmd: ../build/audioSample.tcf
	@echo 'Building file: $<'
	@echo 'Invoking: TConf'
	"C:/ti/xdctools_3_23_03_53/tconf" -b -Dconfig.importPath="C:/ti/bios_5_41_13_42/packages;" "$<"
	@echo 'Finished building: $<'
	@echo ' '

audioSamplecfg.s??: audioSamplecfg.cmd
audioSamplecfg_c.c: audioSamplecfg.cmd
audioSamplecfg.h: audioSamplecfg.cmd
audioSamplecfg.h??: audioSamplecfg.cmd
audioSample.cdb: audioSamplecfg.cmd

audioSamplecfg.obj: ./audioSamplecfg.s?? $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: C6000 Compiler'
	"C:/ti/ccsv5/tools/compiler/c6000_7.3.4/bin/cl6x" -mv6740 -g --define=c6747 --include_path="C:/ti/ccsv5/tools/compiler/c6000_7.3.4/include" --include_path="C:/Program Files/Texas Instruments/pspdrivers_01_20_00/packages" --include_path="U:/ucomp/Final Project/Debug" --include_path="C:/ti/bios_5_41_13_42/packages/ti/bios/include" --include_path="C:/ti/bios_5_41_13_42/packages/ti/rtdx/include/c6000" --display_error_number --diag_warning=225 --abi=coffabi --preproc_with_compile --preproc_dependency="audioSamplecfg.pp" $(GEN_OPTS__FLAG) "$<"
	@echo 'Finished building: $<'
	@echo ' '

audioSamplecfg_c.obj: ./audioSamplecfg_c.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: C6000 Compiler'
	"C:/ti/ccsv5/tools/compiler/c6000_7.3.4/bin/cl6x" -mv6740 -g --define=c6747 --include_path="C:/ti/ccsv5/tools/compiler/c6000_7.3.4/include" --include_path="C:/Program Files/Texas Instruments/pspdrivers_01_20_00/packages" --include_path="U:/ucomp/Final Project/Debug" --include_path="C:/ti/bios_5_41_13_42/packages/ti/bios/include" --include_path="C:/ti/bios_5_41_13_42/packages/ti/rtdx/include/c6000" --display_error_number --diag_warning=225 --abi=coffabi --preproc_with_compile --preproc_dependency="audioSamplecfg_c.pp" $(GEN_OPTS__FLAG) "$<"
	@echo 'Finished building: $<'
	@echo ' '


