// Create an Adaptee instance
Adaptee adaptee = new Adaptee();

// Create an Adapter instance, passing the Adaptee instance to it
ITarget adapter = new Adapter(adaptee);

// Create a Client instance
Client client = new Client();

// Client makes a request to the Adapter
client.MakeRequest(adapter);

/*
Output:
Adaptee's specific request
*/