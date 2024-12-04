const int PIN_LED=13;
void setup() 
{
Serial.begin(9600);
pinMode(PIN_LED, OUTPUT);
}

void loop() 
{
if(Serial.available()>0){
int LeerCaracter=Serial.read();
if (LeerCaracter == 'E')
{
digitalWrite(PIN_LED,HIGH);
}
else if (LeerCaracter == 'F'){
digitalWrite(PIN_LED,LOW);
}
else{}
}
}