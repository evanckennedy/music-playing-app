# Music Playing App

This is a simple console application that simulates a music player. It allows you to add songs to a playlist, play the next song, skip the next song, and rewind to the previous song.

## Features

1. **Add a song to your playlist:** You can add a song to your playlist by entering the song name.
2. **Play the next song in your playlist:** You can play the next song in your playlist. The app will show the name of the song that is currently playing and the next song in the playlist.
3. **Skip the next song:** You can skip the next song in your playlist. The app will show the name of the song that was skipped.
4. **Rewind one song:** You can rewind to the previous song. The app will show the name of the song that is currently playing and the next song in the playlist.

## Challenges Overcome

The main challenge in developing this application was managing the playlist functionality. The requirements were to use a `Queue<string>` to represent the playlist and a `Stack<string>` to keep track of played songs for the rewind functionality.

To overcome this challenge, I created a `currentSong` variable. This variable is used to keep track of the song that is currently playing. When a song is played, it's removed from the `playlist` queue and set as the `currentSong`. If there's already a song playing, it's added to the `playedSongs` stack before the `currentSong` is updated.

The rewind functionality was particularly challenging. When a song is rewound, the `currentSong` should become the next song, and the last song that was played should become the `currentSong`. To achieve this, I had to create a new queue and add the `currentSong` to the front of this queue. Then, I added the rest of the songs from the `playlist` queue to the new queue. Finally, I replaced the `playlist` queue with the new queue. This ensured that the `currentSong` became the next song when a song was rewound.

## How to Run

To run the application, simply run the `Program.cs` file in your IDE.