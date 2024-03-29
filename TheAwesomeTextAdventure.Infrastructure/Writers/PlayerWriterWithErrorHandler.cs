﻿using System;
using TheAwesomeTextAdventure.Domain.Characters;
using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Writers
{
    public class PlayerWriterWithErrorHandler : IPlayerWriter
    {
        public IPlayerWriter PlayerWriter { get; }

        public PlayerWriterWithErrorHandler(IPlayerWriter playerWriter)
        {
            PlayerWriter = playerWriter ?? throw new ArgumentNullException(nameof(playerWriter));
        }

        public void Write(Player player)
        {
            try
            {
                PlayerWriter.Write(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
