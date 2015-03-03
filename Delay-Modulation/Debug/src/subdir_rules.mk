################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Each subdirectory must supply rules for building sources it contributes
src/audioSample_io.obj: ../src/audioSample_io.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: C6000 Compiler'
	"C:/ti/ccsv5/tools/compiler/c6000_7.3.4/bin/cl6x" -mv6740 -g --define=c6747 --include_path="C:/ti/ccsv5/tools/compiler/c6000_7.3.4/include" --include_path="C:/Program Files/Texas Instruments/pspdrivers_01_20_00/packages" --include_path="G:/ECE3551 - 2012/My Workspace/Lab1/Debug" --include_path="C:/ti/bios_5_41_13_42/packages/ti/bios/include" --include_path="C:/ti/bios_5_41_13_42/packages/ti/rtdx/include/c6000" --display_error_number --diag_warning=225 --abi=coffabi --preproc_with_compile --preproc_dependency="src/audioSample_io.pp" --obj_directory="src" $(GEN_OPTS__FLAG) "$<"
	@echo 'Finished building: $<'
	@echo ' '

src/audioSample_main.obj: ../src/audioSample_main.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: C6000 Compiler'
	"C:/ti/ccsv5/tools/compiler/c6000_7.3.4/bin/cl6x" -mv6740 -g --define=c6747 --include_path="C:/ti/ccsv5/tools/compiler/c6000_7.3.4/include" --include_path="C:/Program Files/Texas Instruments/pspdrivers_01_20_00/packages" --include_path="G:/ECE3551 - 2012/My Workspace/Lab1/Debug" --include_path="C:/ti/bios_5_41_13_42/packages/ti/bios/include" --include_path="C:/ti/bios_5_41_13_42/packages/ti/rtdx/include/c6000" --display_error_number --diag_warning=225 --abi=coffabi --preproc_with_compile --preproc_dependency="src/audioSample_main.pp" --obj_directory="src" $(GEN_OPTS__FLAG) "$<"
	@echo 'Finished building: $<'
	@echo ' '


