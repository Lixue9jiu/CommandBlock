# 命令方块
Survivalcraft的c# mod，在游戏里加入了命令方块（Command Block)；
你可以：
1. 编辑命令方块（Command Block）来更改它的命令
2. 利用命令助手（Command Helper）点击方块来获得方块的id，点击动物来获得动物的名字
# 目前可以使用的命令
additem <vector3> <int> [int=1] [vector=0,0,0]
execute @a/r/p/e <another command>
fill <point3> <point3>
gameinfo <info name> <info value>
give @a/r/p/e <int> [int=1]
health heal/injure [float=1] [string=magic]
kill @a/r/p/e [string=magic]
msg @a/r/p/e <string> [bool=true] [bool=true]
msgl @a/r/p/e <string> <string> <string> [float=5] [float=0]
place <point3> <int> [bool=false] [bool=false]
setblock <point3> <int>
setdata <creature data> <data type>
strike <vector3>
summon <animal name> <vector3> [float=0]
time add/set <float>
tp <vector3>
