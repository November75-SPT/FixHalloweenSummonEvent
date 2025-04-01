The issue is in BotsController.Init().

At the time of calling:
[EventsController = new BotsEventsController(BotGame.GameDateTime, Bots, ZonesLeaveController, _botSpawner, CoversData.AIPlaceInfoHolder, events, CoversData)](https://github.com/November75-SPT/FixHalloweenSummonEvent/blob/ea10d03d90652eee4c217d73d4fee794773384d9/Patches/BotHalloweenEventPatch.cs#L122)
_botSpawner had not been initialized yet.

The initialization of _botSpawner happens here:
[_botSpawner = new GClass1661(botCreator, botGame, botZones, Bots, spawnSystem, _maxCount, freeForAll, dictionary, openZones);](https://github.com/November75-SPT/FixHalloweenSummonEvent/blob/ea10d03d90652eee4c217d73d4fee794773384d9/Patches/BotHalloweenEventPatch.cs#L150)

Since _botSpawner was not initialized before the EventsController was created, I reinitialized EventsController using a PatchPostfix.

To prevent the usage of BotsEventsController.Activate() inside BotsController.Init(), I made sure that it is skipped if _botSpawner is null.