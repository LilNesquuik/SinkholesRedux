# SinkholesRedux
A simple plugin based on BuildBoy's BetterSinkholes2 with some bonus features, and updated code

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

### Config Help
Config | Settings | Description
:---: | :---: | :---: 
is_enabled: | true | If plugin is enabled
teleport_distance: | 3.2 | Max collision distance (Default recommended)
blackout_on_corroding: | true | If the light blink when player fall in sinkhole
turn_off_duration: | 0.8 | The time in the secondes of the blackout
teleport_message: | empty(false) | if you want to add a broadcast when a player in sinkhole

### Credits
 - Build#8971 For the original plugin
