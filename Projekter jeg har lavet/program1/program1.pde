// programmet er lavet med processing 3.5.4

int count = 16; // antallet af cirkler der skal laves
Module[] mods;

void setup() {
  size(1000, 1000);
  noStroke();


  mods = new Module[count];


// laver alle cirkler og gemmer dem i listen mods
  int index = 0;
  for (int i = 0; i < count; i++) {
      mods[index++] = new Module(index * 50, index * 20);
  }
  frameRate(60);
}


void draw() {
  background(0);
  for (Module mod : mods) {
    mod.update();
    mod.display();
  }
}


class Module {
  float posX;
  float posY;
  float r;
  
  
  
  
  Module(float x, float y) {
    posX = x;
    posY = y;
    r = 50;
    
    ellipse(posX, posY, r, r);
    
  }
  // updatere cirklernes positioner
  void update() {
    posX = posX + 10;
    if (posX >= width) {
      posY = posY + 50;
      posX = 0;
    }
    if (posY >= height) {
     posX = 0;
     posY = 0;
    }
  }
  // tegner cirklerne på deres ny positioner
  void display() {
    ellipse(posX, posY, r, r);
  }
}
