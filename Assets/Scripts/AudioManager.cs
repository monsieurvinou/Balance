using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance = null;
	public static AudioManager Instance {
		get { return instance; }
	}

	public AudioClip clipToPlay;

	void Awake() {
		if (instance == null || instance == this) {
			instance = this;
			instance.PlaySong();
		} else {
			if ( AudioManager.instance.audio.clip == this.clipToPlay) {
				// Verify the volume
				if ( instance.audio.volume != PlayerPrefs.GetFloat("BGM")) {
					iTween.AudioTo(instance.gameObject, PlayerPrefs.GetFloat("BGM"),1f, 0.5f);
				}
				Destroy(this.gameObject);
				return;
			} else {

				AudioClip newAudioClip = clipToPlay;
				Hashtable args = new Hashtable(){
					{"volume", 0f},
					{"time", 0.3f},
					{"oncomplete", "ChangeSong"},
					{"oncompletetarget",instance.gameObject},
					{"oncompleteparams",newAudioClip}
				};
				iTween.AudioTo(instance.gameObject, args);
				Destroy ( this.gameObject );
			}
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void PlaySong() {
		instance.audio.clip = instance.clipToPlay;
		instance.audio.Play ();
		instance.audio.volume = 0.001f;
		iTween.AudioTo (this.gameObject, PlayerPrefs.GetFloat("BGM"), 1f, 1f);

	}

	void ChangeSong(AudioClip newSong) {
		instance.audio.Stop ();
		instance.audio.clip = newSong;
		instance.audio.Play ();
		iTween.AudioTo (this.gameObject, PlayerPrefs.GetFloat("BGM"), 1f, 1f);
	}
}
