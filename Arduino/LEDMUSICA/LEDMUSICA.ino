int D0 = 2;

int LED1 = 3;

int LED2 = 4;

int LED3 = 5;

int LED4 = 6;

int LED5 = 7;

int LED6 = 8;

int LED7 = 9;


int ESTADO = 0;



void setup(){

  pinMode(D0, INPUT);

  pinMode(LED1, OUTPUT);

  pinMode(LED2, OUTPUT);

  pinMode(LED3, OUTPUT);

  pinMode(LED4, OUTPUT);

  pinMode(LED5, OUTPUT);

  pinMode(LED6, OUTPUT);

  pinMode(LED7, OUTPUT);

  pinMode(LED8, OUTPUT);

  pinMode(LED9, OUTPUT);



}



void loop(){

  ESTADO = digitalRead(D0);

  if (ESTADO == 1){

    digitalWrite(LED1, HIGH);

    delay(10);

    digitalWrite(LED2, HIGH);

    delay(10);

    digitalWrite(LED3, HIGH);

    delay(10);

    digitalWrite(LED4, HIGH);

    delay(10);

    digitalWrite(LED5, HIGH);

    delay(10);

    digitalWrite(LED6, HIGH);

    delay(10);

    digitalWrite(LED7, HIGH);

    delay(10);

    digitalWrite(LED8, HIGH);

    delay(10);

    digitalWrite(LED9, HIGH);

    delay(10);

   

   

    digitalWrite(LED9, LOW);

    delay(10);

    digitalWrite(LED8, LOW);

    delay(10);

    digitalWrite(LED7, LOW);

    delay(10);

    digitalWrite(LED6, LOW);

    delay(10);

    digitalWrite(LED5, LOW);

    delay(10);

    digitalWrite(LED4, LOW);

    delay(10);

    digitalWrite(LED3, LOW);

    delay(10);

    digitalWrite(LED2, LOW);

    delay(10);

    digitalWrite(LED1, LOW);

    delay(10);

  }

  }