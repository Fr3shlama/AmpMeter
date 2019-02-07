#include <Wire.h>
#include <Adafruit_INA219.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

Adafruit_INA219 ina219;
Adafruit_SSD1306 display; 


void setup(void) 
{
  Serial.begin(115200);
  while (!Serial) {
      delay(1);
  }
  uint32_t currentFrequency;
  ina219.begin();

  delay(100);
  display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
  display.clearDisplay(); 
  display.setTextColor(WHITE);
  display.setRotation(0);  
  display.setTextWrap(false);
  display.dim(0); 
}

void loop(void) 
{
  int current_mA = 0;
  float power_mW = 0;

  current_mA = ina219.getCurrent_mA();
  power_mW = current_mA * 0.001;

  
  Serial.print("Current:       "); Serial.print(current_mA); Serial.println(" mA");
  Serial.print("Power:         "); Serial.print(power_mW); Serial.println(" mW");
  Serial.println("");

  display.clearDisplay();  
  display.setCursor(0, 3);  
  display.print("Current: "); display.print(current_mA); display.println(" mA");

  display.setCursor(0, 15); 
  display.print("Power: "); display.print(power_mW); display.println(" W");
  display.display();
  delay(100);
}
