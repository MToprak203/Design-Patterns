Light livingRoomLight = new Light();
ICommand turnOnCommand = new TurnOnLightCommand(livingRoomLight);
ICommand turnOffCommand = new TurnOffLightCommand(livingRoomLight);

RemoteControl remote = new RemoteControl();

// Turning on the light
remote.SetCommand(turnOnCommand);
remote.PressButton();

// Undoing turning on the light
remote.PressUndoButton();

// Turning off the light
remote.SetCommand(turnOffCommand);
remote.PressButton();

// Undoing turning off the light
remote.PressUndoButton();