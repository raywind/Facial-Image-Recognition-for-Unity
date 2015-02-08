#pragma strict
import UnityEngine.UI;
import System.IO;

/**
* Take the screen buffer and spit out a JPG
*/
public function SShotJS(filePath:String)
{
	// wait for graphics to render
	yield WaitForEndOfFrame();
	
	// create a texture to pass to encoding
	var texture:Texture2D = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
	
	// put buffer into texture
	texture.ReadPixels(Rect(0.0, 0.0, Screen.width, Screen.height), 0.0, 0.0);
	texture.Apply();

	// split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
	yield;
	
	// create our encoder for this texture
	var encoder:JPGEncoder = new JPGEncoder(texture, 75.0);
	
	// encoder is threaded; wait for it to finish
	while(!encoder.isDone)
		yield;
	
	// save our test image (could also upload to WWW)
	File.WriteAllBytes(filePath, encoder.GetBytes());
}