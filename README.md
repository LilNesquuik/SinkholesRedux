# SinkholesRedux
SinkholesRedux is a plugin designed to make Lcz dangerous, be careful where you step, Features : a chasm fall effect to give a realistic look, the plugin has also been updated to fix all bugs and the plugin also has a configurable mini blackout when a player falls to mimic interference, it can be disabled as well as amplified, if you have any problems please contact me via the category from Github or discord : LilNesquuik#1028

## Requirements
- This plugin uses [EXILED](https://github.com/galaxy119/EXILED/).
- Make sure the config option in `config_gameplay.txt` called `sinkhole_spawn_chance` is set to higher than 0.

Note: **SinkholesRedux is only guaranteed to work with Exiled 5.2.2 (+) and SCP:SL 12(+)!**

```yml
sinkholes_redux:
  is_enabled: true
  # The distance from the center of a sinkhole where a player gets teleported. This is limited to inside the sinkhole's range. 3.3 recommanded
  teleport_distance: 3.29999995
  # Creates interference in the site's electrical system when passing through a sinkhole.
  blackout_on_corroding: true
  # The number of seconds of the blackout when passing through a sinkhole.
  turn_off_duration: 0.899999976
  # The distance from the center of a sinkhole where a player gets teleported. This is limited to inside the sinkhole's range. 2.3 recommanded
  teleport_message:
  # The broadcast content
    content: You've fallen into the pocket dimension!
    # The broadcast duration
    duration: 5
    # The broadcast type
    type: Normal
    # Indicates whether the broadcast should be shown or not
    show: false
```

Here is the documentation concerning the config.yml to simplify your task 

### Configs (/Exiled/Configs/<your.server.port>-config.yml)

| Config option | Value type | Default value | Description |
| --- | --- | --- | --- |
| `IsEnabled` | bool | true | Enables the SinkholesRedux plugin. Set it to false to disable it. |
| `TeleportDistance` | float | 3.2f | Max collision distance (Default recommended) Not to put below 3. |
| `BlackoutOnCorroding` | float | true | If the light blackout when player fall in sinkhole. |
| `TurnOffDuration` | float | 0.8 | The time in the secondes of the blackout. |
| `KillCorroding` | bool | false | If the player dies necessarily in the dimension. |
| `TeleportMessage` | float | false | if you want to add a broadcast when a player in sinkhole |

### Credits
 - `bladuk.#7777` A big thank you to him for helping me with the code
