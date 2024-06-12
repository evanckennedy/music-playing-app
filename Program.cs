namespace music_playing_app
{
    internal class Program
    {
        static Queue<string> playlist = new Queue<string>();
        static Stack<string> playedSongs = new Stack<string>();
        static string currentSong = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Playlist App!");
            
            while (true)
            {
                ShowMenu();
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Console.Write("Enter song name: ");
                        string songName = Console.ReadLine();
                        AddSongToPlaylist(songName);
                        break;
                    case '2':
                        PlayNextSong();
                        break;
                    case '3':
                        SkipNextSong();
                        break;
                    case '4':
                        RewindToPreviousSong();
                        break;
                    case '5':
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }   
        }

        static void ShowMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a song to your playlist");
            Console.WriteLine("2. Play the next song in your playlist");
            Console.WriteLine("3. Skip the next song");
            Console.WriteLine("4. Rewind one song");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        // Adds a song to the playlist queue and prints a message to the console.
        static void AddSongToPlaylist(string songName)
        {
            playlist.Enqueue(songName);
            Console.WriteLine($"{songName} added to your playlist");
        }

        static void PlayNextSong()
        {
            if (playlist.Count > 0)
            {
                // If there's already a song playing, then add it to the played songs stack
                if (currentSong != null) 
                {
                    playedSongs.Push(currentSong);
                }
                // Dequeue the next song from the playlist and set it as the current song
                currentSong = playlist.Dequeue();
                Console.WriteLine($"Now playing: {currentSong}");
                // If there are any more songs in the playlist, peek at the next song and print it
                if (playlist.Count > 0)
                {
                    string nextSong = playlist.Peek();
                    Console.WriteLine($"Next song: {nextSong}");
                }
                else
                {
                    Console.WriteLine("Next song: none");
                }
            }
            else
            {
                Console.WriteLine("The playlist is empty.");
            }
        }

        static void SkipNextSong()
        {
            if (playlist.Count > 0)
            {
                // Get the next song without removing it from the playlist
                string nextSong = playlist.Peek();
                // Add the next song to the playedSongs stack
                playedSongs.Push(nextSong);
                // Remove the next song from the playlist
                string skippedSong = playlist.Dequeue();
                Console.WriteLine($"Skipped: {skippedSong}");
            }
            else
            {
                Console.WriteLine("The playlist is empty.");
            }
        }

        static void RewindToPreviousSong()
        {
            if (playedSongs.Count > 0)
            {
                // Store the current song as the next song
                string nextSong = currentSong;

                // If there songs in the playedSongs stack, pop the last song and set it as the current song.
                currentSong = playedSongs.Pop();
                Console.WriteLine($"Now playing: {currentSong}");

                // Add the stored next song back to the front of the playlist
                if (nextSong != null)
                {
                    Queue<string> auxQueue = new Queue<string>();
                    auxQueue.Enqueue(nextSong);
                    while (playlist.Count > 0)
                    {
                        auxQueue.Enqueue(playlist.Dequeue());
                    }
                    playlist = auxQueue;

                    // Print the next song
                    Console.WriteLine($"Next song: {nextSong}");
                }
                else
                {
                    // If there are no more songs in the playlist, print a message saying there are no more songs
                    Console.WriteLine("Next song: None");
                }
            }
            else
            {
                if (playlist.Count > 0)
                {
                    // If there are songs in the playlist, print a message saying no songs have been played yet
                    Console.WriteLine("No songs have been played yet.");
                }
                else
                {
                    // If there are no songs in the playlist, print a message saying the playlist is empty
                    Console.WriteLine("The playlist is empty.");
                }
            }
        }
    }
}
