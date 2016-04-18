/**
 *	Keil project for USB HID Device
 *
 *	Before you start, select your target, on the right of the "Load" button
 *
 *	@author 	Tilen Majerle
 *	@email		tilen@majerle.eu
 *	@website	http://stm32f4-discovery.com
 *	@ide		Keil uVision 5
 */
/* Include core modules */
#include "stm32f4xx.h"
/* Include my libraries here */
#include "defines.h"
#include "tm_stm32f4_usb_hid_device.h"
#include "tm_stm32f4_delay.h"
#include "tm_stm32f4_disco.h"
#include "stm32f4_discovery_lis302dl.h"
#include "stm32f4xx_spi.h"

int8_t acc_x, acc_y, acc_z;

void initLIS302DL()
{

        /*Set configuration of LIS302DL*/
            LIS302DL_InitTypeDef LIS302DL_InitStruct;
        	LIS302DL_InitStruct.Power_Mode=LIS302DL_LOWPOWERMODE_ACTIVE;
        	LIS302DL_InitStruct.Output_DataRate=LIS302DL_DATARATE_100;
        	LIS302DL_InitStruct.Axes_Enable=LIS302DL_X_ENABLE | LIS302DL_Y_ENABLE | LIS302DL_Z_ENABLE;
        	LIS302DL_InitStruct.Full_Scale=LIS302DL_FULLSCALE_2_3;
        	LIS302DL_InitStruct.Self_Test = LIS302DL_SELFTEST_NORMAL;
        	LIS302DL_Init(&LIS302DL_InitStruct);
}



int main(void) {

	/* Initialize system */
	SystemInit();
	initLIS302DL();
	/* Initialize leds */
	TM_DISCO_LedOn(LED_ALL);

	/* Initialize button */
	TM_DISCO_ButtonInit();

	/* Initialize delay */
	TM_DELAY_Init();

	/* Initialize USB HID Device */
	TM_USB_HIDDEVICE_Init();

	uint8_t already = 0;

	/* Set structs for all examples */
	TM_USB_HIDDEVICE_Keyboard_t Keyboard;

	/* Set default values for keyboard struct */
	TM_USB_HIDDEVICE_KeyboardStructInit(&Keyboard);


	while (1) {
		TM_DISCO_LedOn(LED_ALL);
		/* If we are connected and drivers are OK */

		if (TM_USB_HIDDEVICE_GetStatus() == TM_USB_HIDDEVICE_Status_Connected) {
			/* Turn on green LED */
			TM_DISCO_LedOn(LED_RED);


		LIS302DL_Read(&acc_x,LIS302DL_OUT_X_ADDR,1);

		 if(acc_x < -30)
		 {
			Keyboard.Key1 = 0x50; /* LEFT ARROW */
			TM_USB_HIDDEVICE_KeyboardSend(&Keyboard);
		}
		 else if(acc_x >30)
		 {
			 Keyboard.Key1 = 0x4F; /* RIGHT ARROW */
			 TM_USB_HIDDEVICE_KeyboardSend(&Keyboard);
		 }
		else if(acc_x >=-50 && acc_x<=50)
		{
			Keyboard.Key1 = 0x00; /* No key */
			TM_USB_HIDDEVICE_KeyboardSend(&Keyboard);
		}
					/* Simple sketch end */

				} else
				{
								/* Turn off green LED */
						TM_DISCO_LedOff(LED_GREEN);
							}
	}
}
