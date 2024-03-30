IFurnitureFactory modernFactory = new ModernFurnitureFactory();
Client modernClient = new Client(modernFactory);
modernClient.SitAndRelax();

IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
Client victorianClient = new Client(victorianFactory);
victorianClient.SitAndRelax();