The issue is in BotsController.Init().

At the time of calling:
[EventsController = new BotsEventsController(BotGame.GameDateTime, Bots, ZonesLeaveController, _botSpawner, CoversData.AIPlaceInfoHolder, events, CoversData)](#122)
_botSpawner had not been initialized yet.

The initialization of _botSpawner happens here:
[_botSpawner = new GClass1661(botCreator, botGame, botZones, Bots, spawnSystem, _maxCount, freeForAll, dictionary, openZones);](#150)

Since _botSpawner was not initialized before the EventsController was created, I reinitialized EventsController using a PatchPostfix.

To prevent the usage of BotsEventsController.Activate() inside BotsController.Init(), I made sure that it is skipped if _botSpawner is null.