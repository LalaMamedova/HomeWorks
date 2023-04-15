using AdapterPattern.Classes;

USBAdapter uSBAdapter = new();

Computer computer = new("Intel Core-i7", 8, uSBAdapter.InsertISensertable(new Headphones(), new MemoryCard()), new Mouse());
uSBAdapter.Remove(1);
uSBAdapter.Remove(0); 