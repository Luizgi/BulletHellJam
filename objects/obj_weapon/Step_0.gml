//Rotaciona Imagem aonde o direcional estiver apontando
image_angle = point_direction(x, y, mouse_x, mouse_y);

//Seguir personagem
var weapon_distance = 0;

var plr_x = obj_player.x;
var plr_y = obj_player.y;

var weapon_x = plr_x + lengthdir_x(weapon_distance, obj_player.image_angle);
var weapon_y = plr_y + lengthdir_y(weapon_distance, obj_player.image_angle);

x = weapon_x;
y = weapon_y;


//Atirando
if(mouse_check_button(mb_left)) && (cooldown < 1)
{
	instance_create_layer(x, y, "BulletLayer", obj_bullet);
	cooldown = 3;
}
cooldown = cooldown - 1;