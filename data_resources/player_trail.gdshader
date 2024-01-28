shader_type canvas_item;

//Noise texture only used if useSpriteTexture is set to false
uniform sampler2D noiseTexture;

//Wether to use shader param noise or texture as noise
uniform bool useSpriteTexture = false; 

//The speed of the movement
uniform float speed : hint_range(0.01,1.0) = 0.1; 

//How much it can differ from circle
uniform float amplitude : hint_range(0.01,1.0) = 0.2; 

float circle(vec2 center, float radius, vec2 p){
    return length(p - center) - radius;
}

void fragment(){
	vec4 noise;

	if (useSpriteTexture){
		noise = texture(TEXTURE, UV + speed * TIME) - 0.5;
	}
	else{
		noise = texture(noiseTexture, UV + speed * TIME) - 0.5;
	}
	
	float sdf = circle(vec2(0.5, 0.5), 0.4, UV) + amplitude * noise.r;

	if (sdf > 0.0){
		COLOR = vec4(1.0, 1.0, 1.0, 0.0);
	}
	else{
		COLOR = vec4(1.0, 1.0, 1.0, min(sdf*-200.0, 1.0));
	}
}