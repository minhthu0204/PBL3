#include <main.h>
#use rs232(baud=9600,parity=N,xmit=pin_c6,rcv=pin_c7,bits=8) //TX_C6, RX_C7
#define LCD_ENABLE_PIN  PIN_C5                                    
#define LCD_RS_PIN      PIN_D2                                    
#define LCD_RW_PIN      PIN_D3                                   
#define LCD_DATA4       PIN_D4                                    
#define LCD_DATA5       PIN_D5                                    
#define LCD_DATA6       PIN_D6                                    
#define LCD_DATA7       PIN_D7   
#include <lcd.c>

#define DOUT PIN_A0
#define PD_SCK PIN_A1 

unsigned int32 ReadCount(){
   unsigned int32 Count = 0;
   unsigned int8 i, convert_1, convert_2, convert_3;
   output_high(DOUT);
   output_low(PD_SCK);
   Count = 0;
   while(input(DOUT));

   for (i = 0 ; i < 24 ; i++){
      output_high(PD_SCK);
      Count = Count << 1;
      output_low(PD_SCK);
      if(input(DOUT)) Count++;
   }

   output_high(PD_SCK);
   Count = Count|0x80;
   output_low(PD_SCK);
   convert_1 = MAKE8(Count, 0);
   convert_2 = MAKE8(Count, 1);
   convert_3 = MAKE8(Count, 2);
   convert_2 = (convert_2 & 0b11111000);
   Count = MAKE16(convert_3, convert_2);
   return(Count*1.49);
}
unsigned int donvi, chuc, tram, nghin;
unsigned int16 KHOI_LUONG, weigh;
void main(){ 
   set_tris_d(0);
   set_tris_c(0);
   set_tris_a(0xFF);
   lcd_init();
   lcd_gotoxy(1,1);
   printf(lcd_putc, " Can kg ");
   delay_ms(1000);
   weigh = ReadCount();

   while(TRUE){
      lcd_gotoxy(1,2);
      unsigned int32 KHOI_LUONG = ReadCount() - weigh;
      donvi = KHOI_LUONG % 10;
      chuc = (KHOI_LUONG / 10) % 10;
      tram = (KHOI_LUONG / 100) % 10;
      nghin = (KHOI_LUONG / 1000) % 10;
      printf(lcd_putc, " Weigh: %d.%d%d%d kg" , nghin, tram, chuc, donvi );
      printf("%d.%d%d%d\r", nghin, tram, chuc, donvi );
      delay_ms(1000);
}
}

