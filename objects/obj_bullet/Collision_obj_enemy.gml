/// @description Insert description here
// You can write your code in this editor
obj_enemy.hp = obj_enemy.hp - 1;

with(other)
{
	hp = hp - 1;
}

instance_destroy();
